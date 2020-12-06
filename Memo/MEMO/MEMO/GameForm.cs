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
    public partial class GameForm : Form
    {
        string Guess;
        private ArrayList words;
        private int step=0;
        Graphics hangman;
        Pen BlackPen;
        int randomIndex;
        string level;
        string content = "";
        public GameForm()
        {
            InitializeComponent();
            HangManGameSetting hangman_setting = new HangManGameSetting();
            hangman_setting.Show();
            level=hangman_setting.return_game_setting();
            content = hangman_setting.return_game_vocab();
            if(content=="")
            {
                ReadFile();
            }
            
            GetRandomIndex();
            Guess = words[randomIndex].ToString();
        }


        private void ReadFile()
        {
            string vocab_name = "英语六级词汇.txt";
            string path = Path.Combine(@".\Vocabulary\", vocab_name);
            words = new ArrayList();
            StreamReader SR = new StreamReader(path);
            while (SR.EndOfStream == false)
            {
                string lines = SR.ReadLine();
                string word = lines.Trim().Split(' ')[0];
                words.Add(word);
            }
        }

        private int GetRandomIndex()
        {
            Random RD = new Random();
            //值得优化的地方，复制了一整块地址去 花费O(N）的时间，空间
            randomIndex= RD.Next(words.ToArray().Length);
            return randomIndex;
        }

        /*
         1. panel1 display letter string
         2. panel2 display hangman consists of  head(round circle) body( vertical line) two hand and two feet. 
         3. six chances of gusses. enumerate number into part of hangman respectively.
             
             */
        private void GameForm_Load(object sender, EventArgs e)
        {
            
        }
        private ArrayList check_letter(char letter,string word)
        {
            string match_string = word;
            ArrayList index = new ArrayList();

            
            
            int index1 = match_string.IndexOf(letter);

            // There is a bug in this while loop below.
            MessageBox.Show(index1.ToString());
            while (index1!=word.Length-1 || index1!=-1)
            {
                index1 = match_string.IndexOf(letter,index1+1);
                if (index1 != -1)
                {
                    MessageBox.Show(index1.ToString());
                    index.Add(index1);
                    
                }
            }



            MessageBox.Show(" ");
            if (index.Count == 0) return null;
            
            return index;
            // can't find this letter in the word.
        }
        private void DisplayLetter(ArrayList index)
        {
            MessageBox.Show("");
            Graphics graph= panel2.CreateGraphics();
            SolidBrush brush = new SolidBrush(Color.Red);
            float interval = panel2.Width / 10;
            float y = panel2.Height / 2;
            MessageBox.Show("");
            foreach (int i in index)
            {
                //int idx = int.Parse(i.ToString());
                string letter = Guess[i].ToString();
                graph.DrawString(letter,new Font("微软雅黑",22), brush,(1+i)*interval,y);

            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            float PenWidth = panel1.Height / 35;
            float top = panel1.Height / 5;
            float buttom = panel1.Height * 5 / 6;
            float right = panel1.Width / 6;
            float left = panel1.Width / 2;
            float mid_top = (right - left) / 2 + left;
            float mid_end = top + (buttom - top) / 5;
             hangman = panel1.CreateGraphics();
             BlackPen = new Pen(Color.Black, PenWidth);
            hangman.DrawLine(BlackPen, right, top, left, top); // top line
            hangman.DrawLine(BlackPen, right, top, right, buttom); // vertical line
            hangman.DrawLine(BlackPen, mid_top, top, mid_top, mid_end); // middle line


        }

        private void button26_Click(object sender, EventArgs e)
        {
            
            
            
                ArrayList index = check_letter('a', Guess);
            MessageBox.Show(" ");
                if (index != null)
                {
                    DisplayLetter(index);
                }
                
           
                
                
                
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
             Guess=words[randomIndex].ToString();
        }
    }
}
