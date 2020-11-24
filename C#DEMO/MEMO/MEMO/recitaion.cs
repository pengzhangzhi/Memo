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
using System.Data;
using System.Drawing;
using System.IO;



namespace MEMO
{
    public partial class recitaion : Form
    {
        Queue English = new Queue(); // english words
        Queue Chinese = new Queue(); // chinese translation
        Queue Forgotten_Eng = new Queue();
        Queue Forgotten_Chi = new Queue();
        int count ;
        public string vocab_name = "";
        string content;
        string[] lines;
        int vocabulary_len;
        

        public recitaion(string vocab)
        {
            InitializeComponent();
            // using queue to store vocabulary, note that forgotten contain words that are forgotten.
            //Queue English = new Queue(); // english words
            //Queue Chinese = new Queue(); // chinese translation
           
            count = 0;    // count how many words user has memorized.
            // read text file 
            vocab_name = vocab;
            if (vocab_name=="")
            {
                vocab_name = "英语六级词汇.txt";
            }

            this.toolStripStatusLabel1.Text = "hello world";
            
            this.toolStripStatusLabel2.Text = "遗忘单词共：" + "0" + "个";

            string vocab_path = Path.Combine(@".\Vocabulary\" , vocab_name );
            StreamReader sw = new StreamReader(@vocab_path, Encoding.Default);
            content = sw.ReadToEnd();
            lines = content.Split('\n');
            vocabulary_len = lines.Length;
            
            toolStripStatusLabel3.Text = "此单词书共有：" + vocabulary_len.ToString() + "个单词";
            for (int i = 0; i < lines.Length; i++)
            {
                
                string[] words = lines[i].Trim().Split(' ');


                if (words.Length < 2)
                {
                    
                    
                    continue;
                }
                else
                {
                    English.Enqueue(words[0]);
                    Chinese.Enqueue(words[2]);
                    
                }
                

            }


            this.toolStripStatusLabel1.Text = "Successfully Load Vocabulary List!";
        }

        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void recitaion_Load(object sender, EventArgs e)
        {

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            
            

        }
        
        private void display_word()
        {
            this.label1.Text = (string)English.Dequeue();
            Chinese.Dequeue();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (count < vocabulary_len && Chinese.Count != 0 && English.Count != 0)
            {

                this.label1.Text = (string)English.Dequeue();
                toolStripStatusLabel1.Text = this.label1.Text;
                Chinese.Dequeue();

                count++;



            }
            else
            {
                MessageBox.Show("You have alreadly memorized all of the words.");
            }

            this.label3.Text =count.ToString();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (count < vocabulary_len)
            {
                var translation= Chinese.Dequeue();
                var eng = English.Dequeue();
                MessageBox.Show((string)translation);

                
                this.label1.Text = (string)English.Peek();

                
                Forgotten_Eng.Enqueue(eng);
                Forgotten_Chi.Enqueue(translation);
                toolStripStatusLabel1.Text = "成功添加遗忘单词！";
                
                this.toolStripStatusLabel2.Text = "遗忘单词共：" + Forgotten_Eng.Count.ToString() + "个";
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            forgotten_word forgotten_words = new forgotten_word(Forgotten_Eng,Forgotten_Chi);
            forgotten_words.Show();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
