using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             调用的方法取决于你new 的对象是什么类型的，所以this指向当前new的对象的方法
             */


            var c1 = new Child();
            c1.SayHello();

            Parent c2 = new Child();
            c2.SayHello();

            Parent p1 = new Parent();
            p1.SayHello();

            Console.ReadKey();

        }

        class Parent
        {
            public Parent()
            {
                //this.SayHello();
                var t = this.GetType();
                Console.WriteLine(t);
            }

            public virtual void SayHello()
            {
                Console.WriteLine("父类的SayHello");
            }
        }

        class Child : Parent
        {
            public override void SayHello()
            {
                Console.WriteLine("子类的SayHello");
            }
        }
    }
}
