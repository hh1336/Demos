using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// bitArray是一个二进制数组，可以动态调整大小
/// bitArray的表示形式是：true false false false false false false false
/// 对应的二进制是：0 0 0 0 0 0 0 1   位置是相反的
/// </summary>
namespace BitArrayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int bits;
            string[] bitNumber = new string[8];
            int binary;
            byte[] ByteSet = new byte[] { 1, 2, 3, 4, 5 };//定义字节数组
            BitArray BitSet = new BitArray(ByteSet);//将字节数组存储到BitArray中，注意：是逆序存储
            bits = 0;//计数器
            binary = 7;//二进制数组下标，由于是逆序存储，索引0-7，所以索引从7开始
            Console.WriteLine("bitSet包含地元素为：" + BitSet.Count + "位");//存储了5个字节数组，一个占8位所以是40
            for (int i = 0; i <= BitSet.Count - 1; i++)
            {
                Console.WriteLine("BitSet.Get(" + i + ")", BitSet.Get(i));
                if (BitSet.Get(i))
                    bitNumber[binary] = "1";//如果该位存储为true则存入1
                else
                    bitNumber[binary] = "0";//如果为false则存储为0
                bits++;//计数++
                binary--;//下标--
                if((bits % 8) == 0)//计数器为8时，表示一个字节数组已经表示完毕
                {
                    binary = 7;
                    bits = 0;
                    for (int j = 0; j <= 7; j++)
                    {
                        Console.Write(bitNumber[j]);
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();

        }
    }
}
