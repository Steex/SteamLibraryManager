using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Diagnostics;
using Microsoft.Win32;

namespace SteamLibraryManager
{
	public static class Utils
	{
		public static readonly char[] DirectorySeparators = { '/', '\\' };
		public static readonly char[] ListSeparators = { ',', ' ', ';' };
		public static readonly char[] LineSeparators = { '\r', '\n' };


		public static void ShowErrorMessage(IWin32Window owner, Exception exception)
		{
			string message = "An error has occurred with the message:\n\n" + exception;
			MessageBox.Show(owner, message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static void ShowErrorMessage(IWin32Window owner, string message)
		{
			MessageBox.Show(owner, message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static void ShowWarningMessage(IWin32Window owner, string message)
		{
			MessageBox.Show(owner, message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		public static DialogResult ShowQuestion(IWin32Window owner, string message, MessageBoxButtons buttons)
		{
			return MessageBox.Show(owner, message, Application.ProductName, buttons, MessageBoxIcon.Question);
		}


		public static bool ParseBool(string str, bool defaultValue)
		{
			return str == "1";
		}

		public static string BoolToString(bool value)
		{
			return value ? "1" : "0";
		}


		public static T ReadRegistryValue<T>(RegistryKey key, string name, T defaultValue)
		{
			try
			{
				string strValue = (string)key.GetValue(name, InvariantConverter.ToString(defaultValue));
				return InvariantConverter.FromString<T>(strValue);
			}
			catch
			{
				return defaultValue;
			}
		}

		public static IEnumerable<string> ReadRegistryList(RegistryKey key, string baseName)
		{
			return ReadRegistryList<string>(key, baseName);
		}

		public static IEnumerable<T> ReadRegistryList<T>(RegistryKey key, string baseName)
		{
			for (int index = 1; ; ++index)
			{
				object value = key.GetValue(baseName + index.ToString());
				if (value != null)
				{
					yield return InvariantConverter.FromString<T>(value.ToString());
				}
				else
				{
					break;
				}
			}
		}

		public static void WriteRegistryValue<T>(RegistryKey key, string name, T value)
		{
			if (value != null)
			{
				key.SetValue(name, InvariantConverter.ToString(value));
			}
			else
			{
				key.SetValue(name, "");
			}
		}

		public static void WriteRegistryList<T>(RegistryKey key, string baseName, IEnumerable<T> list)
		{
			if (list != null)
			{
				int index = 1;
				foreach (T item in list)
				{
					Utils.WriteRegistryValue(key, baseName + index.ToString(), InvariantConverter.ToString(item));
					++index;
				}
			}
		}


		public static T DeserializeValueFromRegistry<T>(RegistryKey key, string name, T defaultValue)
		{
			try
			{
				string strValue = (string)key.GetValue(name, InvariantConverter.ToString(defaultValue));
				return DeserializeValue<T>(strValue);
			}
			catch
			{
				return defaultValue;
			}
		}

		public static IEnumerable<T> DeserializeListFromRegistry<T>(RegistryKey key, string baseName)
		{
			for (int index = 1; ; ++index)
			{
				object strValue = key.GetValue(baseName + index.ToString());
				if (strValue is string)
				{
					yield return DeserializeValue<T>((string)strValue);
				}
				else
				{
					break;
				}
			}
		}

		public static void SerializeValueToRegistry<T>(RegistryKey key, string name, T value)
		{
			key.SetValue(name, SerializeValue(value));
		}

		public static void SerializeListToRegistry<T>(RegistryKey key, string baseName, IEnumerable<T> list)
		{
			if (list != null)
			{
				int index = 1;
				foreach (T item in list)
				{
					key.SetValue(baseName + index.ToString(), SerializeValue(item));
					++index;
				}
			}

		}


		public static string SerializeValue(object value)
		{
			if (value == null)
			{
				return "";
			}

			using (MemoryStream stream = new MemoryStream())
			{
				DataContractJsonSerializer serialzer = new DataContractJsonSerializer(value.GetType());
				serialzer.WriteObject(stream, value);
				return Encoding.UTF8.GetString(stream.GetBuffer(), 0, (int)stream.Length);
			}
		}

		public static T DeserializeValue<T>(string data)
		{
			if (string.IsNullOrEmpty(data))
			{
				return default(T);
			}

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
			{
				DataContractJsonSerializer serialzer = new DataContractJsonSerializer(typeof(T));
				return (T)serialzer.ReadObject(stream);
			}
		}


		public static float EnsureRange(float value, float min, float max)
		{
			if (value < min)
			{
				return min;
			}
			else if (value > max)
			{
				return max;
			}
			else
			{
				return value;
			}
		}

		public static int EnsureRange(int value, int min, int max)
		{
			if (value < min)
			{
				return min;
			}
			else if (value > max)
			{
				return max;
			}
			else
			{
				return value;
			}
		}

	
		public static string GetRelativePath(string path, string root)
		{
			if (root == null || root.Length == 0)
			{
				return path;
			}

			path = path.Replace('/', '\\');
			root = root.Replace('/', '\\');

			if (!root.EndsWith("\\"))
			{
				root += '\\';
			}

			if (path.StartsWith(root, StringComparison.InvariantCultureIgnoreCase))
			{
				return path.Substring(root.Length);
			}
			else
			{
				return path;
			}
		}

		public static string RemoveExtension(string path)
		{
			if (path == null || path.Length == 0)
			{
				return path;
			}

			for (int i = path.Length - 1; i >= 0; --i)
			{
				char symbol = path[i];
				if (symbol == '\\' || symbol == '/')
				{
					return path;
				}
				else if (symbol == '.')
				{
					return path.Substring(0, i);
				}
			}

			return path;
		}

		public static void MoveFile(string sourcePath, string targetPath)
		{
			if (File.Exists(targetPath))
			{
				File.Copy(sourcePath, targetPath, true);
				File.Delete(sourcePath);
			}
			else
			{
				File.Move(sourcePath, targetPath);
			}
		}

		/// <summary>
		/// Starts a new process from the provided path.
		/// </summary>
		public static void OpenPath(string path)
		{
			ProcessStartInfo processInfo = new ProcessStartInfo();
			processInfo.FileName = path;
			Process.Start(processInfo);
		}

		/// <summary>
		/// Opens a file manager and selects the provided object in it.
		/// If the provided path is not exists, opens the most nested existing directory of the path.
		/// </summary>
		public static void ExplorePath(string path)
		{
			if (File.Exists(path) || Directory.Exists(path))
			{
				ProcessStartInfo processInfo = new ProcessStartInfo();
				processInfo.FileName = "explorer";
				processInfo.Arguments = string.Format("/select,{0}", path);
				Process.Start(processInfo);
			}
			else
			{
				OpenPath(FindExistaingPathPart(path));
			}
		}

		/// <summary>
		/// Starts a new process from the provided path.
		/// If the provided path is not exists, opens the most nested existing directory of the path.
		/// </summary>
		public static void OpenOrExplorePath(string path)
		{
			if (File.Exists(path) || Directory.Exists(path))
			{
				OpenPath(path);
			}
			else
			{
				ExplorePath(path);
			}
		}

		/// <summary>
		/// Returns the most nested existing part (a file or a directory) of the path.
		/// </summary>
		public static string FindExistaingPathPart(string path)
		{
			if (string.IsNullOrWhiteSpace(path))
			{
				return null;
			}

			if (File.Exists(path))
			{
				return path;
			}

			while (!string.IsNullOrEmpty(path) && !Directory.Exists(path))
			{
				path = Path.GetDirectoryName(path);
			}

			return !string.IsNullOrEmpty(path) ? path : null;
		}


		public static string AbbreviateString(string value)
		{
			if (value == null)
			{
				return null;
			}

			// Normalize the string: remove leading whitespace, replace all whitespace symbols with a single space.
			string normalizedValue = "";

			bool separatorIsAllowed = false;
			foreach (char chr in value)
			{
				bool isSeparator = Char.IsSeparator(chr);

				if (!isSeparator)
				{
					normalizedValue += chr;
					separatorIsAllowed = true;	
				}
				else if (separatorIsAllowed)
				{
					normalizedValue += ' ';
					separatorIsAllowed = false;
				}
			}

			// Some custom logic: remove English articles from the start of the string.
			if (normalizedValue.StartsWith("a ", StringComparison.OrdinalIgnoreCase))
			{
				normalizedValue = normalizedValue.Substring(2);
			}
			else if (normalizedValue.StartsWith("an ", StringComparison.OrdinalIgnoreCase))
			{
				normalizedValue = normalizedValue.Substring(3);
			}
			else if (normalizedValue.StartsWith("the ", StringComparison.OrdinalIgnoreCase))
			{
				normalizedValue = normalizedValue.Substring(4);
			}

			// Make an abbreviation of the cleared string by including only essential symbols.
			// A symbol is consider essential if
			// - it is a digit
			// - it is an uppercase letter
			// - it is a lowercase letter in the beginning of word
			string abbreviation = "";

			bool waitForNewWord = true;
			foreach (char chr in normalizedValue)
			{
				bool acceptAllways = Char.IsUpper(chr) || Char.IsDigit(chr);
				bool acceptAtWordStart = Char.IsLetter(chr);

				if (acceptAllways ||
					acceptAtWordStart && waitForNewWord)
				{
					abbreviation += Char.ToUpper(chr);
					waitForNewWord = false;
				}

				waitForNewWord = !acceptAllways && !acceptAtWordStart;
			}

			return abbreviation;
		}

		public static string ExtractFirstLine(string text)
		{
			if (text == null)
			{
				return null;
			}

			int lineSeparatorPos = text.IndexOfAny(LineSeparators);
			return lineSeparatorPos == -1 ? text : text.Substring(0, lineSeparatorPos);
		}

		public static string ExtractLastNotEmptyLine(string text)
		{
			if (text == null)
			{
				return null;
			}

			int lineEnd = text.Length;
			int lineBegin = text.LastIndexOfAny(LineSeparators, lineEnd - 1);

			while (true)
			{
				if (lineBegin < 1 || lineBegin < lineEnd - 1)
				{
					return text.Substring(lineBegin + 1, lineEnd - (lineBegin + 1));
				}

				lineEnd = lineBegin;
				lineBegin = text.LastIndexOfAny(LineSeparators, lineEnd - 1);
			}
		}

		public static string ExtractFileNameAtPosition(string text, int searchPosition)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return "";
			}

			if (searchPosition < 0 || searchPosition >= text.Length)
			{
				return "";
			}


			// Check for a double-quoted path.
			int leftQuotePos = text.LastIndexOf('\"', searchPosition == 0 ? searchPosition : searchPosition - 1);
			int rightQuotePos = text.IndexOf('\"', searchPosition == text.Length - 1 ? searchPosition : searchPosition + 1);

			if (leftQuotePos != -1 && rightQuotePos != -1)
			{
				string quotedText = text.Substring(leftQuotePos + 1, rightQuotePos - leftQuotePos - 1);
				if (File.Exists(quotedText))
				{
					return quotedText;
				}
			}

			// Check for a single-quoted path.
			leftQuotePos = text.LastIndexOf('\'', searchPosition == 0 ? searchPosition : searchPosition - 1);
			rightQuotePos = text.IndexOf('\'', searchPosition == text.Length - 1 ? searchPosition : searchPosition + 1);

			if (leftQuotePos != -1 && rightQuotePos != -1)
			{
				string quotedText = text.Substring(leftQuotePos + 1, rightQuotePos - leftQuotePos - 1);
				if (File.Exists(quotedText))
				{
					return quotedText;
				}
			}

			// Check for a delimited path.
			char[] fileNameDelimiters = { ' ', ',', ';', '(', ')' };

			int leftDelimiterPos = text.LastIndexOfAny(fileNameDelimiters, searchPosition == 0 ? searchPosition : searchPosition - 1);
			int rightDelimiterPos = text.IndexOfAny(fileNameDelimiters, searchPosition == text.Length - 1 ? searchPosition : searchPosition + 1);

			int pathBegin = leftDelimiterPos != -1 ? leftDelimiterPos + 1 : 0;
			int pathEnd = rightDelimiterPos != -1 ? rightDelimiterPos - 1 : text.Length - 1;

			if (pathBegin < pathEnd)
			{
				string delimitedText = text.Substring(pathBegin, pathEnd - pathBegin + 1);
				if (File.Exists(delimitedText))
				{
					return delimitedText;
				}
			}

			// Nothing is found.
			return "";
		}


		public static string FormatGbSize(long size)
		{
			double gbSize = size / 1024.0 / 1024.0 / 1024.0;
			return string.Format("{0:0.00} GB", gbSize);
		}
	}
}
