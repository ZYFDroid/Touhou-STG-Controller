using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MetaData
{
	internal class CDD
	{
		[DllImport("Kernel32")]
		private static extern IntPtr LoadLibrary(string dllfile);
		
		[DllImport("Kernel32")]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
		
		[DllImport("kernel32.dll")]
		public static extern bool FreeLibrary(IntPtr hModule);
		
		[DllImport("kernel32.dll")]
		private static extern int GetLastError();
		
		~CDD()
		{
			if (!this.m_hinst.Equals(IntPtr.Zero))
			{
				CDD.FreeLibrary(this.m_hinst);
			}
		}
		
		public int Load(string dllfile)
		{
			this.m_hinst = CDD.LoadLibrary(dllfile);
			if (this.m_hinst.Equals(IntPtr.Zero))
			{
				MessageBox.Show("Error while loading library, code=" + CDD.GetLastError().ToString());
				return -2;
			}
			return this.GetDDfunAddress(this.m_hinst);
		}
		
		private int GetDDfunAddress(IntPtr hinst)
		{
			IntPtr procAddress = CDD.GetProcAddress(hinst, "DD_key");
			this.key = (Marshal.GetDelegateForFunctionPointer(procAddress, typeof(CDD.pDD_key)) as CDD.pDD_key);
			if (procAddress.Equals(IntPtr.Zero))
			{
				return -1;
			}
			return 1;
		}
		
		public CDD.pDD_key key;
		
		private IntPtr m_hinst;

		public delegate int pDD_key(int ddcode, int flag);
	}
}
