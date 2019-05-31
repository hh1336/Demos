using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructSumDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(0.1d, 0.1d, 0.5d);
            Vector v2 = new Vector(0.1d, 0.1d, 0.5d);
            Vector v3 = v1 + v2;
            Console.WriteLine(v3.ToString());
            Console.ReadKey();
        }
    }
}
