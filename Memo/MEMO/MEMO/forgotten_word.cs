using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace MEMO
{
    public partial class forgotten_word : Form
    {
        Queue Forgotten_Eng;
        Queue Forgotten_Chi;
        int index = 0; // tarce the index of current word
        public forgotten_word(Queue Forgotten_Eng, Queue Forgotten_Chi)
        {
            InitializeComponent();
            this.Forgotten_Eng = Forgotten_Eng;
            this.Forgotten_Chi = Forgotten_Chi;
            this.toolStripStatusLabel3.Text = "Hi~";




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


            // Create three items and three sets of subitems for each item.

            if (Forgotten_Eng.Count > 0 && Forgotten_Chi.Count > 0)
            {
                for (;index < Forgotten_Eng.Count; index++)
                {
                    ListViewItem temp = new ListViewItem(index.ToString(), 1);
                    temp.Checked = true;
                    temp.SubItems.Add(Forgotten_Eng.Dequeue().ToString());
                    temp.SubItems.Add(Forgotten_Chi.Dequeue().ToString());
                    listView1.Items.AddRange(new ListViewItem[] { temp });
                }
            }
            //ListViewItem item1 = new ListViewItem("1", 1);
            //// Place a check mark next to the item.
            //item1.Checked = true;
            //item1.SubItems.Add("1");
            //item1.SubItems.Add("2");

            //ListViewItem item2 = new ListViewItem("item2", 1);
            //item2.SubItems.Add("4");

            //ListViewItem temp = new ListViewItem("item3");
            //// Place a check mark next to the item.
            //item3.Checked = true;
            //item3.SubItems.Add("7");
            //item3.SubItems.Add("8");

            //// Create columns for the items and subitems.
            //// Width of -2 indicates auto-size.
            //listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
            //listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
            //listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
            //listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center);

            ////Add the items to the ListView.
            


            


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

        private void 菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 窗口最前ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void forgotten_word_Load(object sender, EventArgs e)
        {

        }

        private void 取消窗口最前ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem temp in listView1.Items)
            {
                temp.Checked = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem temp in listView1.Items)
            {
                if(temp.Checked)

                    temp.Checked = false;

                else temp.Checked = true;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string lines = "";
            System.DateTime current_time = new System.DateTime();
            current_time = System.DateTime.Now;
            string current = current_time.Year.ToString() + "-"+current_time.Month.ToString() + "-" + current_time.Day.ToString() + "-" + current_time.Hour.ToString()
                + "-" + current_time.Minute.ToString()+".txt";
            string path=Path.Combine(Environment.CurrentDirectory,current);
            StreamWriter sw = new StreamWriter(path);
            foreach (ListViewItem item in listView1.Items)
            {
                string line = item.SubItems[1].Text + "  " + item.SubItems[2].Text+"\n";
                sw.WriteLine(line);
            }
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            toolStripStatusLabel3.Text = "保存成功！保存路径为："+path;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            for (int i = listView1.SelectedItems.Count - 1; i >= 0; i--)
            {
                ListViewItem item = listView1.SelectedItems[i];
                listView1.Items.Remove(item);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                foreach(ListViewItem item in listView1.Items)
                {
                    if(item.SubItems[1].Text== textBox1.Text)
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
                    else MessageBox.Show("No finding.");
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
                foreach(ListViewItem item in listView1.Items)
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
    }
}
