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
    public partial class ChildrenForm : Form
    {
        public ChildrenForm()
        {
            InitializeComponent();
            Console.WriteLine("ChildrenForm is run over");
        }
    }
}
