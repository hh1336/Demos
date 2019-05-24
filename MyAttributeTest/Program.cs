using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAttributeTest
{
    class Program
    {
        [MyTest]
        static void Main(string[] args)
        {
            var p1 = new Person();
            p1.Name = "张三";
            p1.Age = 1;
            
            //得到类型
            Type type = p1.GetType();

            //返回一个MyTest注解的数组，传入一个注解，false表示不获取父类
            //var objs =  type.GetCustomAttributes(typeof(MyTest), false);

            //判断这个类是否有被标注这个注解
            //if(objs.Length > 0)
            //{
            //    Console.WriteLine("这个类被标注了注解");
            //}

            //和上面同样的效果
            var attbut = type.GetCustomAttribute(typeof(MyTest));
            if(attbut != null) Console.WriteLine("这个类被标注了注解");


            Console.ReadKey();
        }
    }

    /// <summary>
    /// 创建一个标签
    /// </summary>
    class MyTest : Attribute
    {

    }

    [MyTest]
    class Person
    {
        public string Name { set; get; }
        public int Age { set; get; }
    }
}
