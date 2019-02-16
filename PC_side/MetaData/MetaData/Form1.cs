using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MetaData
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			this.InitializeComponent();
		}
		

		[DllImport("user32.dll")]
		public static extern int SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        private static extern bool GetAsyncKeyState(int vKey);

        public int velU;
        public int velD;
        public int velL;
        public int velR;

        private int step = 1;

        private int fps;
        private int vsec;
        private int gccd = 800;
        private bool hkey;

        private int mx;
        private int my;

        private InputEmu ipe = new InputEmu();

        private void calculatePolar()
        {
            float dx = Control.MousePosition.X - mx;
            float dy = Control.MousePosition.Y - my;
            float length = (float)Math.Sqrt(dx * dx + dy * dy);
            float vx = 0, vy = 0;
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                vx = dx / dx; vy = dy / dx;
                if (dx <= 0 && dy >= 0) { vx = -vx; vy = -vy; }
            }
            else
            {
                vy = dy / dy; vx = dx / dy;
                if (dy <= 0 && dx >= 0) { vx = -vx; vy = -vy; }
            }
            if (dx < 0 && dy < 0) { vx = -vx; vy = -vy; }

            if (dx == 0 && dy == 0) { vx = 0; vy = 0; }
            if (checkBox1.Checked)
            {
                SetCursorPos(mx, my);
                if (vx == 0)
                {
                    velL = 0; velR = 0;
                }
                else if (vx > 0)
                {
                    velL = 0; velR = (int)Math.Round((float)level((int)length) * vx);
                }
                else
                {
                    velR = 0; velL = (int)Math.Round((float)level((int)length) * -vx);
                }

                if (vy == 0)
                {
                    velU = 0; velD = 0;
                }
                else if (vy > 0)
                {
                    velU = 0; velD = (int)Math.Round((float)level((int)length) * vy);
                }
                else
                {
                    velD = 0; velU = (int)Math.Round((float)level((int)length) * -vy);
                }
            }
        }


        private void timer2_Tick(object sender, EventArgs e)
		{
			this.step++;
			if (this.step > 3)
			{
				this.step = 1;
				if (checkBox1.Checked)
				{
					this.calculatePolar();
				}
			}
			if (this.velU >= this.step)
			{
				this.kbdUp.BackColor = Color.SkyBlue;
			}
			else
			{
				this.kbdUp.BackColor = Color.White;
			}
			if (this.velD >= this.step)
			{
				this.kbdDown.BackColor = Color.SkyBlue;
			}
			else
			{
				this.kbdDown.BackColor = Color.White;
			}
			if (this.velL >= this.step)
			{
				this.kbdLeft.BackColor = Color.SkyBlue;
			}
			else
			{
				this.kbdLeft.BackColor = Color.White;
			}
			if (this.velR >= this.step)
			{
				this.kbdRight.BackColor = Color.SkyBlue;
			}
			else
			{
				this.kbdRight.BackColor = Color.White;
			}
			bool flag = Form1.GetAsyncKeyState(18) && Form1.GetAsyncKeyState(16) && Form1.GetAsyncKeyState(80);
			if (flag != this.hkey && flag)
			{
				this.checkBox1.Checked = !this.checkBox1.Checked;
			}
			this.hkey = flag;
			this.fps++;
			this.gccd--;
			int second = DateTime.Now.Second;
			if (this.vsec != second)
			{
				this.vsec = second;
				this.label1.Text = "AFPS:" + this.fps;
				this.fps = 0;
			}
			if (this.gccd <= 0)
			{
				this.gccd = 800;
				GC.Collect();
			}
		}
		
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkBox1.Checked)
			{
				this.mx = Control.MousePosition.X;
				this.my = Control.MousePosition.Y;
			}
		}
		
		private void kbdUp_BackColorChanged(object sender, EventArgs e)
		{
			if (this.kbdUp.BackColor == Color.SkyBlue)
			{
				this.ipe.keyDown(709);
				return;
			}
			this.ipe.keyUp(709);
		}
		
		private void kbdLeft_BackColorChanged(object sender, EventArgs e)
		{
			if (this.kbdLeft.BackColor == Color.SkyBlue)
			{
				this.ipe.keyDown(710);
				return;
			}
			this.ipe.keyUp(710);
		}
		
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			base.TopMost = this.checkBox2.Checked;
		}
		
		private void kbdDown_BackColorChanged(object sender, EventArgs e)
		{
			if (this.kbdDown.BackColor == Color.SkyBlue)
			{
				this.ipe.keyDown(711);
				return;
			}
			this.ipe.keyUp(711);
		}
		
		private void kbdRight_BackColorChanged(object sender, EventArgs e)
		{
			if (this.kbdRight.BackColor == Color.SkyBlue)
			{
				this.ipe.keyDown(712);
				return;
			}
			this.ipe.keyUp(712);
		}

		int[] lowsensitive = {32,8,2};
		int[] medsensitive = { 16, 4, 1 };
		int[] highsensitive = { 7, 3, 1 };

		private int level(int i)
		{

			int[] sensitives = medsensitive;
			if (barMouseSensitive.Value == 0) { sensitives = lowsensitive; }
			if (barMouseSensitive.Value == 2) { sensitives = highsensitive; }
			if (i > sensitives[0])
			{
				return 3;
			}
			if (i > sensitives[1])
			{
				return 2;
			}
			if (i > sensitives[2])
			{
				return 1;
			}
			return 0;
		}
		
		private void Form1_Load(object sender, EventArgs e)
		{
			if (!this.ipe.available)
			{
				Application.Exit();
				return;
			}
			RemoteControllerReceiver.RunWorkerAsync();
		}
		
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{

			RemoteControllerReceiver.CancelAsync();
			ipe.keyUp(InputEmu.VK_C);
			ipe.keyUp(InputEmu.VK_Z);
			ipe.keyUp(InputEmu.VK_X);
			ipe.keyUp(InputEmu.VK_P);
			ipe.keyUp(InputEmu.VK_UP);
			ipe.keyUp(InputEmu.VK_ESC);
			ipe.keyUp(InputEmu.VK_DOWN);
			ipe.keyUp(InputEmu.VK_LEFT);
			ipe.keyUp(InputEmu.VK_SHIFT);
			ipe.keyUp(InputEmu.VK_ENTER);
			ipe.keyUp(InputEmu.VK_RIGHT);
			ipe.forceStop = true;
		}
		public static string GetLocalIP()
		{
			StringBuilder sbuilder = new StringBuilder();
			try
			{
				string HostName = Dns.GetHostName();
				IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
				for (int i = 0; i < IpEntry.AddressList.Length; i++)
				{
					if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
					{
						sbuilder.Append( IpEntry.AddressList[i].ToString());
					}
				}
				return sbuilder.ToString().Trim();
			}
			catch (Exception ex)
			{
				return "";
			}
		}
		

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}


		StringBuilder str = new StringBuilder("233");
		private string byte2HexFormatted(byte[] arr)
		{
			str.Clear();
			for (int i = 0; i < arr.Length; i++)
			{
				string h = toBinStr(arr[i]);
				str.Append(h);
				if (i < (arr.Length - 1))
					str.Append(' ');
			}
			return str.ToString();
		}
		public string toBinStr(byte input)
		{
			int b2 = ((int)input * 2) / 2;
			if (b2 < 0) {
				b2 += 256;
			}

			StringBuilder sb0 = new StringBuilder();
			for (int i = 0; i < 8; i++)
			{
				sb0.Insert(0,((b2 & 1) != 0) ? 1 : 0);
				b2 = b2 >> 1;
			}
			return sb0.ToString();
		}

		private void RemoteControllerReceiver_DoWork(object sender, DoWorkEventArgs e)
		{
			Socket receiver = new Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
			IPEndPoint ip = new IPEndPoint(IPAddress.Any, 0x3389);
			receiver.Bind(ip);
			receiver.ReceiveTimeout = 1000;
			while (true)
			{
				SocketError code = SocketError.Success;
				receiver.Receive(OperateStruct.result,0,2,SocketFlags.None,out code);
				if (code == SocketError.Success)
				{
					OperateStruct.parse();
					RemoteControllerReceiver.ReportProgress(20);
				}
				else
				if (code == SocketError.TimedOut)
				{
					OperateStruct.reset();
					RemoteControllerReceiver.ReportProgress(54);
				}
				else
				{
					OperateStruct.reset();
					RemoteControllerReceiver.ReportProgress(99);
					Console.WriteLine(code);
				}
				System.Threading.Thread.Sleep(2);
				if (RemoteControllerReceiver.CancellationPending) {
					receiver.Close();
					receiver.Dispose();
					return;
				}
			}

		}

		private void RemoteControllerReceiver_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			int code = e.ProgressPercentage;
			if (code == 20) {
				lblDataRecv.Text = byte2HexFormatted(OperateStruct.result);
			}
			if (code == 54)
			{
				lblDataRecv.Text = "<未连接>";
			}
			if (code == 99)
			{
				lblDataRecv.Text = "<错误>";
			}

			if (!checkBox1.Checked) {
				velU = OperateStruct.velU;
				velD = OperateStruct.velD;
				velL = OperateStruct.velL;
				velR = OperateStruct.velR;

				kbdBomb.BackColor = (OperateStruct.keyX == 1) ? Color.SkyBlue : Color.White;
				kbdShift.BackColor = (OperateStruct.keyShift == 1) ? Color.SkyBlue : Color.White;
				kbdShoot.BackColor = (OperateStruct.keyZ == 1) ? Color.SkyBlue : Color.White;
				kbdSpec.BackColor = (OperateStruct.keyC == 1) ? Color.SkyBlue : Color.White;
				kbdEnter.BackColor = (OperateStruct.keyEnter == 1) ? Color.SkyBlue : Color.White;
				kbdEsc.BackColor = (OperateStruct.keyEsc == 1) ? Color.SkyBlue : Color.White;
				kbdP.BackColor = (OperateStruct.keyP == 1) ? Color.SkyBlue : Color.White;

			}


		}


		private void kbdShoot_BackColorChanged(object sender, EventArgs e)
		{
			Label mSender = (Label)sender;
			int keycode = 0;
			if (mSender == kbdShoot) { keycode = InputEmu.VK_Z; }
			if (mSender == kbdBomb) { keycode = InputEmu.VK_X; }
			if (mSender == kbdSpec) { keycode = InputEmu.VK_C; }
			if (mSender == kbdShift) { keycode = InputEmu.VK_SHIFT; }
			if (mSender == kbdEnter) { keycode = InputEmu.VK_ENTER; }
			if (mSender == kbdEsc) { keycode = InputEmu.VK_ESC; }
			if (mSender == kbdP) { keycode = InputEmu.VK_P; }

			if (mSender.BackColor == Color.SkyBlue)
			{
				ipe.keyDown(keycode);
			}
			else
			{
				ipe.keyUp(keycode);
			}

		}

		private void button1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("本机的IP地址:\r\n" + GetLocalIP() + "\r\n请确保手机和电脑在同一Wifi下(使用手机热点可以获得更低的延时)");
		}
	}


	class OperateStruct
	{
		//Define struct of control
		public static int velU = 0;//0 to 3
		public static int velD = 0;
		public static int velL = 0;
		public static int velR = 0;

		public static int keyShift = 0; //0 or 1
		public static int keyZ = 0;
		public static int keyX = 0;
		public static int keyC = 0;
		public static int keyEnter = 0;
		public static int keyEsc = 0;
		public static int keyP = 0;

		public static byte[] result = new byte[2];

		public static void reset()
		{
			velU = 0;
			velD = 0;
			velL = 0;
			velR = 0;
			keyShift = 0;
			keyZ = 0;
			keyX = 0;
			keyC = 0;
			keyEnter = 0;
			keyEsc = 0;
			keyP = 0;
		}

		public static void parse()
		{
			reset();
			byte b0 = result[0];
			velU += ((b0 & 0x80) != 0) ? 2 : 0;
			velU += ((b0 & 0x40) != 0) ? 1 : 0;
			velD += ((b0 & 0x20) != 0) ? 2 : 0;
			velD += ((b0 & 0x10) != 0) ? 1 : 0;
			velL += ((b0 & 0x08) != 0) ? 2 : 0;
			velL += ((b0 & 0x04) != 0) ? 1 : 0;
			velR += ((b0 & 0x02) != 0) ? 2 : 0;
			velR += ((b0 & 0x01) != 0) ? 1 : 0;
			byte b1 = result[1];

			keyShift = ((b1 & 0x80) != 0) ? 1 : 0;
			keyZ = ((b1 & 0x40) != 0) ? 1 : 0;
			keyX = ((b1 & 0x20) != 0) ? 1 : 0;
			keyC = ((b1 & 0x10) != 0) ? 1 : 0;
			keyEnter = ((b1 & 0x08) != 0) ? 1 : 0;
			keyEsc = ((b1 & 0x04) != 0) ? 1 : 0;
			keyP = ((b1 & 0x02) != 0) ? 1 : 0;
		}
	}
}
