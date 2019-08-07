using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// BitVector32是一个结构
/// 优点是速度快，因为是存储在栈当中
/// 缺点是长度不可变
/// 属性：
///     Data            把BitVector中地数据返回为整数
///     Item            索引器
///     CreateMask()    访问BitVector中特定地创建掩码(静态方法)
///     CreateSection() 用于创建32位中地几个片段(静态方法)
/// </summary>
namespace BitVector32Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var bita1 = new BitVector32();
            int bit1 = BitVector32.CreateMask();
            int bit2 = BitVector32.CreateMask(bit1);
            int bit3 = BitVector32.CreateMask(bit2);
            int bit4 = BitVector32.CreateMask(bit3);
            int bit5 = BitVector32.CreateMask(bit4);
            bita1[bit1] = true;
            bita1[bit2] = false;
            bita1[bit3] = true;
            bita1[bit4] = true;
            bita1[bit5] = true;
            Console.WriteLine(bita1);
            bita1[0xabcdef] = true;
            Console.WriteLine(bita1);
            Console.ReadKey();
        }
    }
}
