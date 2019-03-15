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
    public class Vector<T> : IVector<T> {
        internal T x;
        internal T y;
        internal T z;

        public T GetX() {
            return x;
        }

        public T GetY() {
            return y;
        }

        public T GetZ() {
            return z;
        }

        /// <summary> 
        /// Konstruktor wektora w przestrzeni trójwymiarowej. 
        /// </summary>
        public Vector(T x, T y, T z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary> 
        /// Tworzenie kopii głębokiej wektora. 
        /// </summary>
        public Vector(Vector<T> prototype) {
            x = prototype.x;
            y = prototype.y;
            z = prototype.z;
        }
    }
}
