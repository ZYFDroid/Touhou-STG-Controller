namespace MetaData
{
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.kbdUp = new System.Windows.Forms.Label();
			this.kbdLeft = new System.Windows.Forms.Label();
			this.kbdDown = new System.Windows.Forms.Label();
			this.kbdRight = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.kbdP = new System.Windows.Forms.Label();
			this.kbdEsc = new System.Windows.Forms.Label();
			this.kbdShift = new System.Windows.Forms.Label();
			this.kbdSpec = new System.Windows.Forms.Label();
			this.kbdBomb = new System.Windows.Forms.Label();
			this.kbdEnter = new System.Windows.Forms.Label();
			this.kbdShoot = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.barMouseSensitive = new System.Windows.Forms.TrackBar();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.lblDataRecv = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.RemoteControllerReceiver = new System.ComponentModel.BackgroundWorker();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.barMouseSensitive)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(12, 18);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(132, 16);
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "启动 (Alt+Shift+P)";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// timer2
			// 
			this.timer2.Enabled = true;
			this.timer2.Interval = 1;
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// kbdUp
			// 
			this.kbdUp.BackColor = System.Drawing.Color.White;
			this.kbdUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.kbdUp.Location = new System.Drawing.Point(179, 15);
			this.kbdUp.Name = "kbdUp";
			this.kbdUp.Size = new System.Drawing.Size(40, 40);
			this.kbdUp.TabIndex = 2;
			this.kbdUp.Text = "上";
			this.kbdUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.kbdUp.BackColorChanged += new System.EventHandler(this.kbdUp_BackColorChanged);
			// 
			// kbdLeft
			// 
			this.kbdLeft.BackColor = System.Drawing.Color.White;
			this.kbdLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.kbdLeft.Location = new System.Drawing.Point(140, 54);
			this.kbdLeft.Name = "kbdLeft";
			this.kbdLeft.Size = new System.Drawing.Size(40, 40);
			this.kbdLeft.TabIndex = 2;
			this.kbdLeft.Text = "左";
			this.kbdLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.kbdLeft.BackColorChanged += new System.EventHandler(this.kbdLeft_BackColorChanged);
			// 
			// kbdDown
			// 
			this.kbdDown.BackColor = System.Drawing.Color.White;
			this.kbdDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.kbdDown.Location = new System.Drawing.Point(179, 54);
			this.kbdDown.Name = "kbdDown";
			this.kbdDown.Size = new System.Drawing.Size(40, 40);
			this.kbdDown.TabIndex = 2;
			this.kbdDown.Text = "下";
			this.kbdDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.kbdDown.BackColorChanged += new System.EventHandler(this.kbdDown_BackColorChanged);
			// 
			// kbdRight
			// 
			this.kbdRight.BackColor = System.Drawing.Color.White;
			this.kbdRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.kbdRight.Location = new System.Drawing.Point(218, 54);
			this.kbdRight.Name = "kbdRight";
			this.kbdRight.Size = new System.Drawing.Size(40, 40);
			this.kbdRight.TabIndex = 2;
			this.kbdRight.Text = "右";
			this.kbdRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.kbdRight.BackColorChanged += new System.EventHandler(this.kbdRight_BackColorChanged);
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.BackColor = System.Drawing.Color.Transparent;
			this.checkBox2.Location = new System.Drawing.Point(248, 19);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(72, 16);
			this.checkBox2.TabIndex = 5;
			this.checkBox2.Text = "窗口置顶";
			this.checkBox2.UseVisualStyleBackColor = false;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(269, 71);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 12);
			this.label1.TabIndex = 6;
			this.label1.Text = "AFPS:60";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.kbdP);
			this.groupBox1.Controls.Add(this.kbdEsc);
			this.groupBox1.Controls.Add(this.kbdShift);
			this.groupBox1.Controls.Add(this.kbdSpec);
			this.groupBox1.Controls.Add(this.kbdBomb);
			this.groupBox1.Controls.Add(this.kbdEnter);
			this.groupBox1.Controls.Add(this.kbdShoot);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.kbdUp);
			this.groupBox1.Controls.Add(this.kbdDown);
			this.groupBox1.Controls.Add(this.kbdLeft);
			this.groupBox1.Controls.Add(this.kbdRight);
			this.groupBox1.Controls.Add(this.checkBox2);
			this.groupBox1.Location = new System.Drawing.Point(12, 14);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(329, 100);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "键位";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// kbdP
			// 
			this.kbdP.BackColor = System.Drawing.Color.White;
			this.kbdP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.kbdP.Location = new System.Drawing.Point(227, 29);
			this.kbdP.Name = "kbdP";
			this.kbdP.Size = new System.Drawing.Size(18, 18);
			this.kbdP.TabIndex = 3;
			this.kbdP.Text = "P";
			this.kbdP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.kbdP.BackColorChanged += new System.EventHandler(this.kbdShoot_BackColorChanged);
			// 
			// kbdEsc
			// 
			this.kbdEsc.BackColor = System.Drawing.Color.White;
			this.kbdEsc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.kbdEsc.Location = new System.Drawing.Point(134, 35);
			this.kbdEsc.Name = "kbdEsc";
			this.kbdEsc.Size = new System.Drawing.Size(40, 20);
			this.kbdEsc.TabIndex = 3;
			this.kbdEsc.Text = "Esc";
			this.kbdEsc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.kbdEsc.BackColorChanged += new System.EventHandler(this.kbdShoot_BackColorChanged);
			// 
			// kbdShift
			// 
			this.kbdShift.BackColor = System.Drawing.Color.White;
			this.kbdShift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.kbdShift.Location = new System.Drawing.Point(9, 15);
			this.kbdShift.Name = "kbdShift";
			this.kbdShift.Size = new System.Drawing.Size(80, 40);
			this.kbdShift.TabIndex = 3;
			this.kbdShift.Text = "SHIFT";
			this.kbdShift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.kbdShift.BackColorChanged += new System.EventHandler(this.kbdShoot_BackColorChanged);
			// 
			// kbdSpec
			// 
			this.kbdSpec.BackColor = System.Drawing.Color.White;
			this.kbdSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.kbdSpec.Location = new System.Drawing.Point(68, 54);
			this.kbdSpec.Name = "kbdSpec";
			this.kbdSpec.Size = new System.Drawing.Size(40, 40);
			this.kbdSpec.TabIndex = 3;
			this.kbdSpec.Text = "C";
			this.kbdSpec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.kbdSpec.BackColorChanged += new System.EventHandler(this.kbdShoot_BackColorChanged);
			// 
			// kbdBomb
			// 
			this.kbdBomb.BackColor = System.Drawing.Color.White;
			this.kbdBomb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.kbdBomb.Location = new System.Drawing.Point(29, 54);
			this.kbdBomb.Name = "kbdBomb";
			this.kbdBomb.Size = new System.Drawing.Size(40, 40);
			this.kbdBomb.TabIndex = 3;
			this.kbdBomb.Text = "X";
			this.kbdBomb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.kbdBomb.BackColorChanged += new System.EventHandler(this.kbdShoot_BackColorChanged);
			// 
			// kbdEnter
			// 
			this.kbdEnter.BackColor = System.Drawing.Color.White;
			this.kbdEnter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.kbdEnter.Location = new System.Drawing.Point(134, 15);
			this.kbdEnter.Name = "kbdEnter";
			this.kbdEnter.Size = new System.Drawing.Size(40, 21);
			this.kbdEnter.TabIndex = 3;
			this.kbdEnter.Text = "Enter";
			this.kbdEnter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.kbdEnter.BackColorChanged += new System.EventHandler(this.kbdShoot_BackColorChanged);
			// 
			// kbdShoot
			// 
			this.kbdShoot.BackColor = System.Drawing.Color.White;
			this.kbdShoot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.kbdShoot.Location = new System.Drawing.Point(88, 15);
			this.kbdShoot.Name = "kbdShoot";
			this.kbdShoot.Size = new System.Drawing.Size(40, 40);
			this.kbdShoot.TabIndex = 3;
			this.kbdShoot.Text = "Z";
			this.kbdShoot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.kbdShoot.BackColorChanged += new System.EventHandler(this.kbdShoot_BackColorChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.barMouseSensitive);
			this.groupBox2.Controls.Add(this.checkBox1);
			this.groupBox2.Location = new System.Drawing.Point(12, 122);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(179, 80);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "鼠标玩东方(其他游戏也可以)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "灵敏度";
			// 
			// barMouseSensitive
			// 
			this.barMouseSensitive.Location = new System.Drawing.Point(68, 32);
			this.barMouseSensitive.Maximum = 2;
			this.barMouseSensitive.Name = "barMouseSensitive";
			this.barMouseSensitive.Size = new System.Drawing.Size(104, 45);
			this.barMouseSensitive.TabIndex = 2;
			this.barMouseSensitive.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.barMouseSensitive.Value = 1;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.lblDataRecv);
			this.groupBox3.Controls.Add(this.button1);
			this.groupBox3.Location = new System.Drawing.Point(198, 122);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(143, 80);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "手机控制玩东方";
			// 
			// lblDataRecv
			// 
			this.lblDataRecv.Location = new System.Drawing.Point(6, 47);
			this.lblDataRecv.Name = "lblDataRecv";
			this.lblDataRecv.Size = new System.Drawing.Size(131, 23);
			this.lblDataRecv.TabIndex = 1;
			this.lblDataRecv.Text = "<未连接>";
			this.lblDataRecv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(6, 20);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(131, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "查看本机地址";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// RemoteControllerReceiver
			// 
			this.RemoteControllerReceiver.WorkerReportsProgress = true;
			this.RemoteControllerReceiver.WorkerSupportsCancellation = true;
			this.RemoteControllerReceiver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RemoteControllerReceiver_DoWork);
			this.RemoteControllerReceiver.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.RemoteControllerReceiver_ProgressChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(353, 211);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.ShowIcon = false;
			this.Text = "东方游戏的全新玩法";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.barMouseSensitive)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		
		private global::System.ComponentModel.IContainer components;
		
		private global::System.Windows.Forms.CheckBox checkBox1;
		
		private global::System.Windows.Forms.Timer timer2;
		
		private global::System.Windows.Forms.Label kbdUp;
		
		private global::System.Windows.Forms.Label kbdLeft;
		
		private global::System.Windows.Forms.Label kbdDown;
		
		private global::System.Windows.Forms.Label kbdRight;
		
		private global::System.Windows.Forms.CheckBox checkBox2;
		
		private global::System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label kbdShift;
		private System.Windows.Forms.Label kbdBomb;
		private System.Windows.Forms.Label kbdShoot;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TrackBar barMouseSensitive;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label kbdSpec;
		private System.ComponentModel.BackgroundWorker RemoteControllerReceiver;
		private System.Windows.Forms.Label lblDataRecv;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label kbdEsc;
		private System.Windows.Forms.Label kbdEnter;
		private System.Windows.Forms.Label kbdP;
	}
}
