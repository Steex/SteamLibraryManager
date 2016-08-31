using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Text;
using System.Drawing.Imaging;

namespace SteamLibraryManager
{
	public enum LogLevel
	{
		Debug,
		Info,
		Warning,
		Error,
	}

	public static class Logger
	{
		public delegate void ClearHandler();
		public delegate void WriteHandler(LogLevel level, string message);

		public static event ClearHandler OnClear;
		public static event WriteHandler OnWrite;


		private static object locker = new object();


		public static void WriteDebug(string message)
		{
			PerformWrite(LogLevel.Debug, message + "\r\n");
		}

		public static void WriteDebug(string message, params object[] args)
		{
			PerformWrite(LogLevel.Debug, string.Format(message + "\r\n", args));
		}

		public static void WriteWarning(string message)
		{
			PerformWrite(LogLevel.Warning, message + "\r\n");
		}

		public static void WriteWarning(string message, params object[] args)
		{
			PerformWrite(LogLevel.Warning, string.Format(message + "\r\n", args));
		}

		public static void WriteError(string message)
		{
			PerformWrite(LogLevel.Error, message + "\r\n");
		}

		public static void WriteError(string message, params object[] args)
		{
			PerformWrite(LogLevel.Error, string.Format(message + "\r\n", args));
		}

		public static void WriteLine()
		{
			PerformWrite(LogLevel.Info, "\r\n");
		}

		public static void WriteLine(string message)
		{
			PerformWrite(LogLevel.Info, message + "\r\n");
		}

		public static void WriteLine(string message, params object[] args)
		{
			PerformWrite(LogLevel.Info, string.Format(message + "\r\n", args));
		}

		public static void Write(string message)
		{
			PerformWrite(LogLevel.Info, message);
		}

		public static void Write(string message, params object[] args)
		{
			PerformWrite(LogLevel.Info, string.Format(message, args));
		}


		private static void PerformWrite(LogLevel level, string message)
		{
			lock (locker)
			{
				if (OnWrite != null)
				{
					OnWrite(level, message);
				}
			}
		}


		public static void Clear()
		{
			lock (locker)
			{
				if (OnClear != null)
				{
					OnClear();
				}
			}
		}
	}
}
