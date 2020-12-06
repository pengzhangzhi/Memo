using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;  //导入命名空间,类Thread就在此空间中
using System.Collections;
using System.IO;

namespace MEMO
{
    public partial class collector : Form
    {


        int index = 0; // tarce the index of current word
        public collector()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView1.AllowColumnReorder = true;
            // Display check boxes.
            listView1.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            listView1.FullRowSelect = true;
            // Display grid lines.
            listView1.GridLines = true;
            // select multiple row
            listView1.FullRowSelect = true;
            // Sort the items in the list in ascending order.
            listView1.Sorting = SortOrder.Ascending;

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.


            listView1.Columns.Add("Index", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("English", -2, HorizontalAlignment.Center);
            listView1.Columns.Add("Chinese", -2, HorizontalAlignment.Center);

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void collector_Load(object sender, EventArgs e)
        {


            //Thread.Sleep(2000);
            //while (Clipboard.ContainsText(TextDataFormat.Text)) // 判断剪贴板里是否有内容
            //{
            //    // 这一块代码不好写，目前还有bug、考虑换成 手动添加单词
            //    string English = Clipboard.GetText(TextDataFormat.Text);
            //    // 现在剪贴板内容存在clipboardText 里
            //    //MessageBox.Show(English);
            //    //Thread.Sleep(2000);

            //    while (Clipboard.ContainsText(TextDataFormat.Text) && Clipboard.GetText(TextDataFormat.Text) != English)
            //    {//剪贴板里有新内容
            //        string Chinese= Clipboard.GetText(TextDataFormat.Text);
                    
            //        Clipboard.Clear();
            //        Thread.Sleep(1000);
            //        MessageBox.Show(Chinese,English);

            //    }
            //    Thread.Sleep(1000);
            //}
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.Selected)
                    {
                        item.SubItems[1].Text = textBox1.Text;
                    }
                    break;

                }
            }

            else if (!string.IsNullOrEmpty(textBox2.Text))
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.Selected)
                    {
                        item.SubItems[2].Text = textBox2.Text;
                    }
                    break;

                }
            }
            else
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.Selected)
                    {
                        item.SubItems[1].Text = textBox1.Text;
                        item.SubItems[2].Text = textBox2.Text;
                    }
                    break;


                }
            }
        }
        class NullStringException : Exception
        {
            public NullStringException(string message) : base(message)
            {

            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = Clipboard.GetText(TextDataFormat.Text);
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text = Clipboard.GetText(TextDataFormat.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
                    throw new NullStringException("textBox1.Text is null or textBox2.Text is null.");

                else
                {
                    ListViewItem temp = new ListViewItem(index.ToString(), 1);
                    temp.Checked = true;
                    temp.SubItems.Add(textBox1.Text);
                    temp.SubItems.Add(textBox2.Text);
                    listView1.Items.AddRange(new ListViewItem[] { temp });
                    index++;
                }
            }
            catch (NullStringException nse)
            {
                MessageBox.Show(nse.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[1].Text == textBox1.Text)
                    {
                        item.Selected = true;
                    }
                    else MessageBox.Show("No finding.");
                }
            }

            else if (!string.IsNullOrEmpty(textBox2.Text))
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[2].Text == textBox2.Text)
                    {
                        item.Selected = true;
                    }
                    else MessageBox.Show("No findings.");
                }
            }


            else
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[1].Text == textBox1.Text && item.SubItems[2].Text == textBox2.Text)
                    {
                        item.Selected = true;
                    }
                    else MessageBox.Show("No finding.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = listView1.SelectedItems.Count - 1; i >= 0; i--)
            {
                ListViewItem item = listView1.SelectedItems[i];
                listView1.Items.Remove(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lines = "";
            System.DateTime current_time = new System.DateTime();
            current_time = System.DateTime.Now;
            string current = current_time.Year.ToString() + "-" + current_time.Month.ToString() + "-" + current_time.Day.ToString() + "-" + current_time.Hour.ToString()
                + "-" + current_time.Minute.ToString() + ".txt";
            string path = Path.Combine(Environment.CurrentDirectory, current);
            StreamWriter sw = new StreamWriter(path);
            foreach (ListViewItem item in listView1.Items)
            {
                string line = item.SubItems[1].Text + "  " + item.SubItems[2].Text + "\n";
                sw.WriteLine(line);
            }
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            toolStripStatusLabel1.Text = "保存成功！保存路径为：" + path;
        }
    }
}
