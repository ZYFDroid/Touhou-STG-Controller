using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace MetaData
{
	public partial class LicenseForm : Form
	{
		public LicenseForm()
		{
			this.InitializeComponent();
		}
		
		private void LicenseForm_Load(object sender, EventArgs e)
		{
			this.button4_Click(sender, e);
		}
		
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}
		
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.ddxoft.com/");
		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			this.printDocument1.Print();
		}
		
		private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
		{
			Rectangle pageBounds = e.PageBounds;
			e.Graphics.DrawString(this.textBox1.Text, SystemFonts.DefaultFont, Brushes.Black, new RectangleF((float)(pageBounds.X + pageBounds.Width / 8), (float)(pageBounds.Y + pageBounds.Height / 8), (float)(pageBounds.Width / 8 * 6), (float)(pageBounds.Height / 8 * 6)));
		}
		
		private void button4_Click(object sender, EventArgs e)
		{
			if (File.Exists("DD85590.32.dll"))
			{
				this.lblDllCheck.ForeColor = Color.Green;
				this.lblDllCheck.Text = "已找到DD85590.32.dll √";
			}
			else
			{
				this.lblDllCheck.ForeColor = Color.Red;
				this.lblDllCheck.Text = "未找到DD85590.32.dll ×";
			}
			this.btnAccept.Enabled = (this.checkBox1.Checked && this.lblDllCheck.Text.StartsWith("已"));
		}
		
		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					File.Copy(this.openFileDialog1.FileName, "DD85590.32.dll");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "复制DLL文件失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			this.button4_Click(sender, e);
		}
		
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			this.btnAccept.Enabled = (this.checkBox1.Checked && this.lblDllCheck.Text.StartsWith("已"));
		}
		
		private void btnAccept_Click(object sender, EventArgs e)
		{
		}
	}
}
