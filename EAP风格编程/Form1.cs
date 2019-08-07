using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EAP风格编程
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += Wc_DownloadStringCompleted;
            wc.DownloadStringAsync(new Uri("http://www.baidu.com"));
        }

        private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.textBox1.Text = e.Result;
        }
    }
}
