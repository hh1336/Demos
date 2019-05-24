using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 反射案例
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            p.Name = "mamamamam";
            this.propertyGrid1.SelectedObject = p;
        }
    }

    class Person
    {
        public int id;
        public string hobby;

        public Person()
        {

        }

        public Person(string name)
        {
            this.Name = name;
        }
        public Person(int age, string name) : this(name)
        {

        }

        public string Name { set; get; }

        public void SayHi()
        {
            Console.WriteLine("我的名字是：" + this.Name);
        }
    }
}
