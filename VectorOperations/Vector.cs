using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorOperations {

    /// <summary>
    /// Klasa implementująca wektor w przestrzeni trójwymiarowej.
    /// Istnieje możliwość utworzenia wektoru w przestrzeni dwuwymiarowej (x, y, 0) oraz jednowymiarowej (x, 0, 0).
    /// </summary>
    public class Vector {
        internal double x;
        internal double y;
        internal double z;

        public double X { get { return x; } }
        public double Y { get { return y; } }
        public double Z { get { return z; } }
        
        /// <summary> 
        /// Konstruktor wektora (0, 0, 0). 
        /// </summary>
        public Vector() {
            x = 0;
            y = 0;
            z = 0;
        }

        /// <summary> 
        /// Konstruktor wektora w przestrzeni jednowymiarowej. 
        /// </summary>
        public Vector(double x)
            : this(x, 0, 0) { }

        /// <summary> 
        /// Konstruktor wektora w przestrzeni dwuwymiarowej. 
        /// </summary>
        public Vector(double x, double y)
            : this(x, y, 0) { }

        /// <summary> 
        /// Konstruktor wektora w przestrzeni trójwymiarowej. 
        /// </summary>
        public Vector(double x, double y, double z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary> 
        /// Tworzenie kopii głębokiej wektora. 
        /// </summary>
        public Vector(Vector prototype) {
            x = prototype.x;
            y = prototype.y;
            z = prototype.z;
        }

        /// <summary> 
        /// Operacja dodawania wektorów. 
        /// </summary>
        public static Vector operator +(Vector a, Vector b) {
            return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        /// <summary> 
        /// Operacja odejmowania wektorów. 
        /// </summary>
        public static Vector operator -(Vector a, Vector b) {
            return new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        /// <summary> 
        /// Operacja mnożenia wektora przez skalar (wersja 1). 
        /// </summary>
        public static Vector operator *(double a, Vector b) {
            return new Vector(a * b.x, a * b.y, a * b.z);
        }

        /// <summary> 
        /// Operacja mnożenia wektora przez skalar (wersja 2). 
        /// </summary>
        public static Vector operator *(Vector b, double a) {
            return new Vector(a * b.x, a * b.y, a * b.z);
        }
    }
}
