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
    public partial class 关于 : Form
    {

        int select;
        
        public 关于(int choice)
        {
            InitializeComponent();
            select = choice;
            switch (choice)
            {
                case 0:
                    this.linkLabel1.Text = "作者：@彭张智";
                    break;
                case 1:
                    this.linkLabel1.Text = "Github(click here!)";
                    break;
                case 2:
                    this.linkLabel1.Text = "E-mail:zhangzhipengcs@foxmail.com";
                    break;
                case 3:
                    this.linkLabel1.Text = "copyright:MIT";
                    break;
                case 4:
                    this.linkLabel1.Text = "格式：“English  英语”（中间两个空格）";
                    break;


            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void 关于_Load(object sender, EventArgs e)
        {

        }
    }
}
