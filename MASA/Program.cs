using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MASA
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Program.DataFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MASA Contact Extractor");
			if (!Directory.Exists(Program.DataFolderPath))
			{
				try
				{
					Directory.CreateDirectory(Program.DataFolderPath);
				}
				catch
				{
				}
			}
			Program.AppSettingsFile = string.Format("{0}\\settings.cfg", Program.DataFolderPath);
			Program.AppDataFile = string.Format("{0}\\data.dat", Program.DataFolderPath);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}

		public static string SettingsFileName;

		public static bool IsDemoVersion = false;

		public static Random Rnd;

		public static Settings AppSettings;

		public static string DataFolderPath;

		public static string AppSettingsFile;

		public static Data AppData;

		public static string AppDataFile;

		public static List<string> Countries;

		public static List<string> Languages;

		public static List<ProxyServer> ProxyServers = new List<ProxyServer>();

		public static int QueryDelay = 5000;

		public static bool LogOn = false;
	}
}
