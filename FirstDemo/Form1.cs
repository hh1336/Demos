using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstDemo
{
    /// <summary>
    /// 窗体的实例化顺序
    /// 构造函数
    /// Load
    /// Activated
    /// Closing
    /// Closed
    /// Deactivate
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;//该窗体设置为MDI父窗体
            this.panel1.AutoScroll = true;//出现滚动条
            FormClosing += Form1_FormClosing;//窗体关闭前触发的事件
            StartPosition = FormStartPosition.CenterScreen;//启动软件时软件的位置

        }

        /// <summary>
        /// 直接执行Application.Exit();方法就不会触发FormClosing事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("窗体关闭前触发");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label1.Text = "回车或点击了";
            using (MySqlConnection conn = new MySqlConnection("Database=hsm;Data Source=127.0.0.1;User Id=root;Password=;port=3306;charset=utf8"))
            {
                string sql = "select * from reportopendialogs";
                var ds = new DataSet();
                var da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds, "reportopendialogs");
                this.dataGridView1.AutoGenerateColumns = true;
                this.dataGridView1.DataSource = ds;
                this.dataGridView1.DataMember = "reportopendialogs";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AcceptButton = this.button1;//当回车时触发该按钮
            CancelButton = this.button2;//当按下esc键时触发
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.label1.Text = "按下了esc";
            this.dataGridView1.DataSource = null;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var childrenForm = new ChildrenForm();
            //childrenForm.Show();  主方法后面的代码会立即执行
            //var dialogResult = childrenForm.ShowDialog();//等待方法执行结束后，下面的代码才会继续执行
            //if (dialogResult == DialogResult.Cancel)
            //    Console.WriteLine("wait ChildrenForm");
            childrenForm.MdiParent = this;//将主窗体设置为子窗体的父级窗体
            childrenForm.Show();//显示窗体
            
            
        }
    }
}
