using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// 为了保证线程安全，.net提供了一些专门用于多线程的集合
/// ConcurrentXXX为对应地线程安全集合
/// 如：ConcurrentStack<T> 
/// 可以到 System.Collections.Concurrent 这个命名空间中查看
/// 
/// 带锁的集合： BlockingCollection<T>
/// 这个集合会阻塞线程，会一直等待线程执行结束
/// </summary>
namespace 线程安全的集合类
{
    class Program
    {
        static void Main(string[] args)
        {
            var sharedCollection = new BlockingCollection<int>();
            var events = new ManualResetEventSlim[2];
            var waits = new WaitHandle[2];
            for (int i = 0; i < 2; i++)
            {
                events[i] = new ManualResetEventSlim(false);
                waits[i] = events[i].WaitHandle;
            }
            var producer = new Thread(obj =>
            {
                var state = (Tuple<BlockingCollection<int>, ManualResetEventSlim>)obj;
                var coll = state.Item1;
                var ev = state.Item2;
                var r = new Random();
                for (int i = 0; i < 300; i++)
                {
                    coll.Add(r.Next(3000));
                }
                ev.Set();
            });
            producer.Start(Tuple.Create<BlockingCollection<int>, ManualResetEventSlim>(sharedCollection, events[0]));

            var consumer = new Thread(obj =>
            {
                var state = (Tuple<BlockingCollection<int>, ManualResetEventSlim>)obj;
                var coll = state.Item1;
                var ev = state.Item2;
                for (int i = 0; i < 300; i++)
                {
                    int result = coll.Take();
                }
                ev.Set();
            });
            consumer.Start(Tuple.Create<BlockingCollection<int>, ManualResetEventSlim>(sharedCollection, events[1]));
            if (!WaitHandle.WaitAll(waits))
                Console.WriteLine("wait failed");
            else
                Console.WriteLine("reading/writing finished");
            Console.ReadKey();
        }
    }
}
