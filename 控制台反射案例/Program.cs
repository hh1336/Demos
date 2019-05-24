using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 控制台反射案例
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Name = "张三";
            ShowObj(p);
            Console.ReadKey();
        }

        static void ShowObj(object obj)
        {
            Type type = obj.GetType();
            var props =  type.GetProperties();

            foreach (var prop in props)
            {
                //如果可读
                if (prop.CanRead)
                {
                    string pname = prop.Name;
                    object pvalue = prop.GetValue(obj);
                    Console.WriteLine(pname + "=" + pvalue);
                }
            }
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
