using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorOperations {
    public class Vector {
        internal double x;
        internal double y;
        internal double z;

        public double X { get { return x; } }
        public double Y { get { return y; } }
        public double Z { get { return z; } }
        
        public Vector() {
            x = 0;
            y = 0;
            z = 0;
        }

        public Vector(double x)
            : this(x, 0, 0) { }

        public Vector(double x, double y)
            : this(x, y, 0) { }

        public Vector(double x, double y, double z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector(Vector prototype) {
            x = prototype.x;
            y = prototype.y;
            z = prototype.z;
        }

        public static Vector operator +(Vector a, Vector b) {
            return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector operator -(Vector a, Vector b) {
            return new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector operator *(double a, Vector b) {
            return new Vector(a * b.x, a * b.y, a * b.z);
        }

        public static Vector operator *(Vector b, double a) {
            return new Vector(a * b.x, a * b.y, a * b.z);
        }
    }
}
