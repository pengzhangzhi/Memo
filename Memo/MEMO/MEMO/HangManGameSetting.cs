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
using System.Collections;

namespace MEMO
{
    
    public partial class HangManGameSetting : Form
    {
        public string content=string.Empty;
        public string level = string.Empty;


        public HangManGameSetting()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            radioButton4.Checked = true;
            
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void HangManGameSetting_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //transport messages into parent form
            /*
             1. settings
             2. word
             
             */

            this.Close();


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            if (dr == System.Windows.Forms.DialogResult.OK && !string.IsNullOrEmpty(filename))
            {

                StreamReader sr = new StreamReader(filename, Encoding.UTF8);

                content=sr.ReadToEnd();



                sr.Close();
            }
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            level = "easy";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            level = "hard";
        }

        // return game setting 
        public string return_game_setting()
        {
            return level;
        }
        public string return_game_vocab()
        {
            return content;
        }
    }
}
