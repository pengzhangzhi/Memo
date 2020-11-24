using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace MEMO
{
    public partial class OpenFile : Form
    {
        public OpenFile()
        {
            InitializeComponent();
        }
        string filename;



        

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
             filename = openFileDialog1.FileName;
            if(dr==System.Windows.Forms.DialogResult.OK && !string.IsNullOrEmpty(filename))
            {
                StreamReader sr = new StreamReader(filename);
                textBox1.Text=sr.ReadToEnd();
                sr.Close();
            }
            toolStripStatusLabel1.Text = "文件读入成功！";
            Clipboard.SetText(filename);
            System.Windows.Forms.Clipboard.SetText(filename);
            toolStripStatusLabel1.Text = "文件地址已复制到剪贴板！";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.Write(textBox1.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
