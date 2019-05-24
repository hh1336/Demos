using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Type的成员
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 反射通用属性
            //得到这个类的类型
            Type t = typeof(Person);

            //得到这个类型的父类
            Type t1 = t.BaseType;

            //得到这个类的子类
            Type t2 = t.GetType();

            //得到这个类型的全名，包括命名空间
            string typeFullName = t.FullName;

            //得到这个类型的名称
            string typeName = t.Name;

            //得到这个类的无参构造函数
            ConstructorInfo ct1 = t.GetConstructor(new Type[0]);

            //得到这个类带有一个string类型的构造函数
            ConstructorInfo ct2 = t.GetConstructor(new Type[] { typeof(string) });

            //得到这个类有2个构造函数
            ConstructorInfo ct3 = t.GetConstructor(new Type[] { typeof(int), typeof(string) });

            //没有这个构造函数，结果为null
            ConstructorInfo ct4 = t.GetConstructor(new Type[] { typeof(string), typeof(string) });

            //返回所有公共的字段
            FieldInfo[] f1 = t.GetFields();

            //得到私有的字段
            FieldInfo[] f2 = t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            //foreach (var field in f2)
            //{
            //    Console.WriteLine(field);
            //}

            ////返回这个类的所有方法
            //MethodInfo[] m1 = t.GetMethods();

            //MethodInfo m2 = t.GetMethod("SayHi");
            //m2.Invoke(typeof(Person), new Type[0]);

            //foreach (var m in m1)
            //{
            //    Console.WriteLine(m);
            //}

            ////得到所有属性
            //PropertyInfo[] p1 = t.GetProperties();

            //foreach (var p in p1)
            //{
            //    Console.WriteLine(p);
            //}

            #endregion

            #region 反射动态创建类
            Type type = typeof(Person);
            object obj = Activator.CreateInstance(type);//调用默认的构造函数创建对象
            PropertyInfo pname = type.GetProperty("Name");//得到这个属性
            pname.SetValue(obj, "么么么么么");//给obj这个对象的Name属性赋值

            MethodInfo method = type.GetMethod("SayHi");//得到这个类型的这个方法
            method.Invoke(obj,new object[0]);//调用这个方法在某个类型上

            #endregion

            Console.ReadKey();
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
