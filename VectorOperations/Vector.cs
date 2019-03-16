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
    public class Vector<T> {
        internal T x { get; set; }
        internal T y { get; set; }
        internal T z { get; set; }

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
