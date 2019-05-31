using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructSumDemo
{
    public struct Vector
    {
        public double x, y, z;

        public Vector(double x,double y,double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector(Vector vector)
        {
            this.x = vector.x;
            this.y = vector.y;
            this.z = vector.z;
        }

        public override string ToString()
        {
            return "{" + x + "," + y + "," + z + "}";
        }

        public static Vector operator + (Vector ihs,Vector rhs)
        {
            Vector result = new Vector(ihs);
            result.x += rhs.x;
            result.y += rhs.y;
            result.z += rhs.z;
            return result;
        }
    }
}
