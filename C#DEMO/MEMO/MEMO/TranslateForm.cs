using System;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Web;
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
    public partial class TranslateForm : Form
    {
        public TranslateForm()
        {
            InitializeComponent();
        }



        public class Translator
        {
            string q;
            string from = "auto";
            string to;
            string appId;
            Random rd;
            string secretKey;

            public Translator(string to,string appId,string secretKey)
            {
                
                this.to = to;
                this.appId = appId;
                this.secretKey = secretKey;
                // 原文 q 

                // 源语言

                // 目标语言 to 

                // 改成您的APP ID
            }
            public string Translate(string str)
            {
               
                
                rd = new Random();
                string salt = rd.Next(100000).ToString();
                // 改成您的密钥
                MessageBox.Show(from);
                
                string sign = EncryptString(appId + q + salt + secretKey);
                string url = "http://api.fanyi.baidu.com/api/trans/vip/translate?";
                url += "q=" + HttpUtility.UrlEncode(q);
                url += "&from=" + from;
                url += "&to=" + to;
                url += "&appid=" + appId;
                url += "&salt=" + salt;
                url += "&sign=" + sign;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                request.UserAgent = null;
                request.Timeout = 6000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                return retString;
                
            }

            public static string EncryptString(string str)
            {
                MD5 md5 = MD5.Create();
                // 将字符串转换成字节数组
                byte[] byteOld = Encoding.UTF8.GetBytes(str);
                // 调用加密方法
                byte[] byteNew = md5.ComputeHash(byteOld);
                // 将加密结果转换为字符串
                StringBuilder sb = new StringBuilder();
                foreach (byte b in byteNew)
                {
                    // 将字节转换成16进制表示的字符串，
                    sb.Append(b.ToString("x2"));
                }
                // 返回加密的字符串
                return sb.ToString();
            }



        }





        private void TranslateForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q=textBox1.Text;
           
            string to=comboBox1.Text;
            MessageBox.Show(q);
            MessageBox.Show(to);
            // 这是我申请的 ID 和 密钥  可以直接用我的使用。
            string appId= "20201124000624376";
            string secretKey= "0LjgGIm2nm_8hgND_sO5";


            Translator translator = new Translator(to, appId, secretKey);
            string result = translator.Translate(q);
            textBox2.Text = result;
            Clipboard.SetText(result);
            System.Windows.Forms.Clipboard.SetText(result);
            toolStripStatusLabel1.Text = "翻译结果已复制到剪贴板！";
        }
    }
}
