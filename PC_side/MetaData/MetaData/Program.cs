using System;
using System.IO;
using System.Windows.Forms;

namespace MetaData
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if (!File.Exists("acceptDDKey.lic") || !File.Exists("DD85590.32.dll"))
			{
				if (new LicenseForm().ShowDialog() != DialogResult.OK)
				{
					return;
				}
				File.WriteAllText("acceptDDKey.lic", "");
			}
			Application.Run(new Form1());
		}
		private const string licfilename = "acceptDDKey.lic";
	}
}
