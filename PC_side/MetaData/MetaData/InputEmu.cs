using System;
using System.IO;
using System.Windows.Forms;

namespace MetaData
{
	public class InputEmu
	{
		public Boolean forceStop = false;

		public InputEmu()
		{
			this.dd = new CDD();
			this.LoadDllFile(Path.GetFullPath("DD85590.32.dll"));
		}
		
		public void keyDown(int key)
		{
			if (forceStop) { return; }
			this.dd.key(key, 1);
		}
		
		public void keyUp(int key)
		{
			if (forceStop) { return; }
			this.dd.key(key, 2);
		}
		
		private void LoadDllFile(string dllfile)
		{
			if (!new FileInfo(dllfile).Exists)
			{
				MessageBox.Show("找不到DLL文件，请确保DLL文件在程序目录下。如果从快捷方式启动程序，请检查启动路径是否和程序目录一致", "加载dll时发生错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Application.Exit();
				return;
			}
			int num = this.dd.Load(dllfile);
			if (num == -2)
			{
				MessageBox.Show("无法装载库文件。如果看到了网络连接相关的提示框，请检查网络连接", "加载dll时发生错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Application.Exit();
				return;
			}
			if (num == -1)
			{
				MessageBox.Show("无法找到函数路径", "加载dll时发生错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Application.Exit();
				return;
			}
			this.available = true;
		}
		
		private CDD dd;
		
		public bool available;
		
		public const int VK_UP = 709;
		public const int VK_LEFT = 710;
		public const int VK_DOWN = 711;
		public const int VK_RIGHT = 712;

		public const int VK_Z = 501;
		public const int VK_X = 502;
		public const int VK_C = 503;
		public const int VK_SHIFT = 500;
		public const int VK_ENTER = 313;
		public const int VK_ESC = 100;
		public const int VK_P = 310;
	}
}
