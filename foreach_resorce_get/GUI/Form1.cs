using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace foreach_resorce_get
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		// folder select
		private void button1_Click(object sender, EventArgs e)
		{
			var Dialog = new CommonOpenFileDialog();
			// フォルダーを開く設定に
			Dialog.IsFolderPicker = true;
			// 読み取り専用フォルダ/コントロールパネルは開かない
			Dialog.EnsureReadOnly = false;
			Dialog.AllowNonFileSystemItems = false;
			// パス指定
			Dialog.DefaultDirectory = Application.StartupPath;
			// 開く
			var Result = Dialog.ShowDialog();
			// もし開かれているなら
			if(Result == CommonFileDialogResult.Ok) {
				// ここでいろいろする（開いたフォルダはDialog.FileNameで取得）
				textBox2.Text = Dialog.FileName;
			}
		}

		// do
		private void button2_Click(object sender, EventArgs e)
		{
			int i;
			// text check
			if(textBox1.Text == string.Empty || !Directory.Exists(textBox2.Text)) {
				// error
				MessageBox.Show("Textbox empty");
				return;
			}
			// create
			Http_File_Getter hfg = new Http_File_Getter(textBox1.Text);
			hfg.SaveDir = textBox2.Text;
			// get
			for(i=(int)numericUpDown1.Value; i <=(int)numericUpDown2.Value; i++){
				hfg.GetOfPart(i);
				progressBar1.Value = (int)(i / (double)numericUpDown2.Value * 100);
			}
			// end
			MessageBox.Show("All Process Finish. " + (i-1) + "/" + (int)numericUpDown2.Value);
			progressBar1.Value = 0;
		}
	}
}
