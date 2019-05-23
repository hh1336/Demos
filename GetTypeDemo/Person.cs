using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTypeDemo
{
    public class Person
    {
        public string Name { set; get; }

        public int Age { set; get; }

        public override string ToString()
        {
            return "调用了Person类的ToString方法";
        }
    }
}
