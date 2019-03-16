using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorOperations {

    /// <summary>
    /// Class that implements a vector in a in three-dimensional space.
    /// Is it possible to create a vector in two-dimensional space (x, y, 0) and one-dimensional space (x, 0, 0).
    /// </summary>
    public class Vector<T> {
        internal T x { get; set; }
        internal T y { get; set; }
        internal T z { get; set; }

        /// <summary> 
        /// Vector constructor in a three-dimensional space.
        /// </summary>
        public Vector(T x, T y, T z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary> 
        /// Creating deep copy of given vector.
        /// </summary>
        public Vector(Vector<T> prototype) {
            x = prototype.x;
            y = prototype.y;
            z = prototype.z;
        }
    }
}
