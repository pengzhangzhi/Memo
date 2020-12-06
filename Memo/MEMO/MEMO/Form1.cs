using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEMO
{
    public partial class main : Form
    {
        string selected_vovcabulary_book = "";
        public main()
        {
            InitializeComponent();
        }

        private void check_radio_button()
        {
            
            foreach (Control rb in this.Controls)
            {
                
                if (rb is RadioButton)
                {
                    
                    if (((RadioButton)rb).Checked)
                    {
                        selected_vovcabulary_book = ((RadioButton)rb).Text;
                        

                        break;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            check_radio_button();
            if (selected_vovcabulary_book != "")
            {
                recitaion Re = new recitaion(selected_vovcabulary_book);
                
                
                Re.Show();
            }
            else
            {
                MessageBox.Show("您还没有选择词汇书!");
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void main_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "Welcome~";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            check_radio_button();


            if (selected_vovcabulary_book=="")
            {
                MessageBox.Show("您还没有选择词汇书!");
            }
            else

            {
                if (selected_vovcabulary_book == "自定义词汇表地址：")
                    selected_vovcabulary_book = textBox1.Text;
                toolStripStatusLabel1.Text = "你选择的词汇书是：" + selected_vovcabulary_book;
            }
            
        }

        private void 关于作者ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            关于 guanyu =new 关于(0);
            guanyu.Show();
        }

        private void github地址ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            关于 guanyu = new 关于(1);
            guanyu.Show();
        }

        private void 联系作者ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            关于 guanyu = new 关于(2);
            guanyu.Show();
        }

        private void 版权ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            关于 guanyu = new 关于(3);
            guanyu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "开始从剪贴板中收集单词~";
            collector col = new collector();
            col.Show();


        }

        private void 自定义词汇表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            关于 guanyu = new 关于(4);
            guanyu.Show();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged_2(object sender, EventArgs e)
        {
            OpenFile of = new OpenFile();
            of.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TranslateForm TF = new TranslateForm();
            TF.Show();
        }

        private void viewInGithubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/pengzhangzhi/Memo";
            System.Diagnostics.Process.Start(@url);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GameForm gf = new GameForm();
            gf.Show();

        }
    }
}
