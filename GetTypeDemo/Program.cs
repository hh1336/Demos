using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTypeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();

            //获取类型的方式,以下返回的对象都指向同一个引用
            Type t1 = p1.GetType();
            Type t2 = typeof(Person);
            Type t3 = Type.GetType("GetTypeDemo.Person");

            //Activator可以动态创建一个类
            object obj1 = Activator.CreateInstance(t1);

            Console.WriteLine(t1);
            Console.WriteLine(t2);
            Console.WriteLine(t3);
            Console.WriteLine(obj1);
            Console.ReadKey();
        }
    }
}
