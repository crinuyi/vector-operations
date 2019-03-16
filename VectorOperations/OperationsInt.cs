using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorOperations {
    public class OperationsInt : IOperations<int> {
        /// <summary>
        /// Operation of adding given vectors.
        /// </summary>
        /// <param name="a">Vector of int type.</param>
        /// <param name="b">Vector of int type.</param>
        /// <returns>Returns vector of int type.</returns>
        public Vector<int> Add(Vector<int> a, Vector<int> b) {
            return new Vector<int>(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        /// <summary>
        /// Operation of subtracting given vectors.
        /// </summary>
        /// <param name="a">Vector of int type.</param>
        /// <param name="b">Vector of int type..</param>
        /// <returns>Returns vector of int type.</returns>
        public Vector<int> Subtraction(Vector<int> a, Vector<int> b) {
            return new Vector<int>(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        /// <summary>
        /// Operation of multiplying given vector and scalar.
        /// </summary>
        /// <param name="a">Vector of int type.</param>
        /// <param name="b">Vector of int type.</param>
        /// <returns>Returns vector of int type.</returns>
        public Vector<int> MultiplyWithScalar(Vector<int> vector, int scalar) {
            return new Vector<int>(scalar * vector.x, scalar * vector.y, scalar * vector.z);
        }

        /// <summary>
        /// Scalar product of two given vectors.
        /// </summary>
        /// <param name="a">Vector of int type.</param>
        /// <param name="b">Vector of int type.</param>
        /// <returns>Returns int value.</returns>
        public int ScalarProduct(Vector<int> a, Vector<int> b) {
            return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
        }

        /// <summary>
        /// Vector norm of given vector.
        /// </summary>
        /// <param name="vector">Vector of int type.</param>
        /// <returns>Returns double value.</returns>
        public double VectorNorm(Vector<int> vector) {
            return Math.Sqrt((vector.x * vector.x) + (vector.y * vector.y) + (vector.z * vector.z));
        }

        /// <summary>
        /// Distance between two given vectors.
        /// </summary>
        /// <param name="a">Vector of int type.</param>
        /// <param name="b">Vector of int type.</param>
        /// <returns>Returns double value.</returns>
        public double DistanceBetweenVectors(Vector<int> a, Vector<int> b) {
            return VectorNorm(Subtraction(a, b));
        }

        /// <summary>
        /// Angle between two vectors.
        /// </summary>
        /// <param name="a">Vector of int type.</param>
        /// <param name="b">Vector of int type.</param>
        /// <exception cref="ArgumentException">Thrown if given vectors are (0,0,0) and (0,0,0).</exception>
        /// <returns>Returns double value.</returns>
        public double AngleBetweenVectors(Vector<int> a, Vector<int> b) {
            if (a.x != 0 && a.y != 0 && a.z != 0 && b.x != 0 && b.y != 0 && b.z != 0) {
                double cosinusValue = ScalarProduct(a, b) / (VectorNorm(a) * VectorNorm(b));
                return Math.Cos(cosinusValue);
            }
            else throw new ArgumentException();

        }

        /// <summary>
        /// Orthogonality of two vectors.
        /// </summary>
        /// <param name="a">Vector of int type.</param>
        /// <param name="b">Vector of int type.</param>
        /// <returns>Returns true or false.</returns>
        public bool OrthogonalityOfVectors(Vector<int> a, Vector<int> b) {
            int ab = ScalarProduct(a, b);
            if (ab == 0.0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Orthogonality of three vectors.
        /// </summary>
        /// <param name="a">Vector of int type.</param>
        /// <param name="b">Vector of int type.</param>
        /// <param name="c">Vector of int type.</param>
        /// <returns>Returns true or false.</returns>
        public bool OrthogonalityOfVectors(Vector<int> a, Vector<int> b, Vector<int> c) {
            if (OrthogonalityOfVectors(a, b) == true) {
                if (OrthogonalityOfVectors(a, c) == true) {
                    if (OrthogonalityOfVectors(b, c) == true) {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}
