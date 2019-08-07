using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpClientDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            //构造post请求表单的数据
            List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();
            pairs.Add(new KeyValuePair<string, string>("commit", "Sign in"));
            pairs.Add(new KeyValuePair<string, string>("login", "hh1336"));
            pairs.Add(new KeyValuePair<string, string>("password", "132"));
            pairs.Add(new KeyValuePair<string, string>("webauthn-support", "supported"));
            FormUrlEncodedContent content = new FormUrlEncodedContent(pairs);

            //发送一个post请求
            HttpClient hc = new HttpClient();
            var result = await hc.PostAsync("https://github.com/session", content);
            textBox1.Text = result.Headers.ToString();
        }
    }
}
