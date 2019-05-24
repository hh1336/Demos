using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 控制台反射案例2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Name = "张三";
            Person p2 = new Person();
            p2.Name = p1.Name;
            var p3 = MyClone(p1);
            p3.SayHi();
            Console.ReadKey();
        }

        static T MyClone<T>(T obj) where T :class
        {
            Type type = obj.GetType();//得到传入的对象类型

            object newobj = Activator.CreateInstance(type);//根据类型创建一个类

            foreach (var prop in type.GetProperties())//遍历这个类型里面所有的属性
            {
                if(prop.CanRead&& prop.CanWrite)//每个属性都必须可读可写 
                {
                    object value =  prop.GetValue(obj);//获取传入对象的某个属性值
                    prop.SetValue(newobj, value);//将值设置给新创建出来的类对应的属性
                }
            }
            return newobj as T;
        }
    }
    class Person
    {
        public string Name { set; get; }

        public void SayHi()
        {
            Console.WriteLine("我的名字是：" + this.Name);
        }
    }
}
