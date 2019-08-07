using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用线程池执行下面的代码
            //ThreadPool.QueueUserWorkItem(strat =>
            //{
            //    for (int i = 0; i < 200; i++)
            //    {
            //        Console.WriteLine(i);
            //    }
            //});
            //for (int i = 0; i < 200; i++)
            //{
            //    Console.WriteLine("同时执行");
            //}

            //线程池传参数
            for (int i = 0; i < 500; i++)
            {
                ThreadPool.QueueUserWorkItem(start =>
                {
                    Console.WriteLine(start);
                }, i);
            }

            Console.ReadKey();
        }
    }
}
