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
            //初始化定时器
            timer1.Enabled = true;      //定时器的可见性
            timer1.Interval = 1000;     //定时器的时间间隔设置为1000ms
            this.toolStripStatusLabel1.Text = "系统当前时间：" + DateTime.Now.ToString();

        }
        string filename;



        

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
             filename = openFileDialog1.FileName;
            if(dr==System.Windows.Forms.DialogResult.OK && !string.IsNullOrEmpty(filename))
            {
                
                StreamReader sr = new StreamReader(filename, Encoding.UTF8);
                richTextBox1.Text=sr.ReadToEnd();
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
            sw.Write(richTextBox1.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void OpenFile_Load(object sender, EventArgs e)
        {

        }
        private void GetCurrentNum()
        {
            int currentCount = 0;//每行的个数
            int totalCount = richTextBox1.SelectionStart;//当前bai光标以前的字du数
            int index = richTextBox1.SelectionStart;
            currentCount = index + 1;//SelectionStart是从0开始 默认+1
            int last = 0;
            string[] currentStr = richTextBox1.Text.Substring(0, index).Split('\n');//当前光标以前每行的数组
            last = currentStr.Length;//当前光标前面有多少行
            toolStripStatusLabel2.Text = last.ToString();//显示光标所在的行数
        }

            private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "系统当前时间：" + DateTime.Now.ToString();
            GetCurrentNum();
        }
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            filename = openFileDialog1.FileName;
            if (dr == System.Windows.Forms.DialogResult.OK && !string.IsNullOrEmpty(filename))
            {
                StreamReader sr = new StreamReader(filename);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
            toolStripStatusLabel1.Text = "文件读入成功！";
            Clipboard.SetText(filename);
            System.Windows.Forms.Clipboard.SetText(filename); //将读入文件地址复制到剪贴板
            toolStripStatusLabel1.Text = "文件地址已复制到剪贴板！";
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //保存选项实现代码
            if (filename.Length > 0)
            {
                //文件名不是空，原来已经有此文件则直接保存
                richTextBox1.SaveFile(filename, RichTextBoxStreamType.PlainText);
            }
            else
            {
                //文件名是空，属于新建的文件,调用另存为事件
                另存为ToolStripMenuItem_Click(sender, e);
            }
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "文本文件 | *.txt";
            saveFileDialog1.FilterIndex = 1;                        //文件对话框中当前选定筛选器的索引
            saveFileDialog1.InitialDirectory = "E:\\";              //保存文件时的默认目录
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //点击了保存文件对话框的确定按钮
                filename = saveFileDialog1.FileName;                //更新文件名
                //保存文件,参数分别是文件的路径path 和文件的类型(这里指定为纯文本)
                richTextBox1.SaveFile(filename, RichTextBoxStreamType.PlainText);
                //获取文件保存路径并更新窗口标题栏
                int index = filename.LastIndexOf('\\');             //找到最后一个斜线的下标索引
                string Text_2 = filename.Substring(index + 1);      //去掉文件路径获取文件名(参数下标索引，截取长度(不指定直到最后))
                toolStripStatusLabel2.Text = Text_2 + "-EditorPrimer";               //更新标题栏
            }
        }
    }
}
