using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstDemo
{
    /// <summary>
    /// 对Control类进行介绍
    /// Control是一个核心类，用于创建用户所见的图形界面
    /// Control继承自Component，Component用于提供一些必要的结构
    /// </summary>
    public class PersentControl : Control
    {
        public Control control { get; set; }

        public void Persent()
        {
            control.Dock = DockStyle.Top;//表示子控件停留在父控件的某条边上
        }
    }
}
