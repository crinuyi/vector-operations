using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorOperations {
    public class OperationsDouble : IOperations<double> {
        /// <summary>
        /// Operation of adding vectors.
        /// </summary>
        /// <param name="a">Vector of double type.</param>
        /// <param name="b">Vector of double type.</param>
        /// <returns>Returns vector of double type.</returns>
        public Vector<double> Add(Vector<double> a, Vector<double> b)
        {
            return new Vector<double>(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        /// <summary>
        /// Operation of subtracting vectors.
        /// </summary>
        /// <param name="a">Vector of double type.</param>
        /// <param name="b">Vector of double type..</param>
        /// <returns>Returns vector of double type.</returns>
        public Vector<double> Subtraction(Vector<double> a, Vector<double> b)
        {
            return new Vector<double>(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        /// <summary>
        /// Operation of multiplying vector and scalar.
        /// </summary>
        /// <param name="a">Vector of double type.</param>
        /// <param name="b">Vector of double type.</param>
        /// <returns>Returns vector of double type.</returns>
        public Vector<double> MultiplyWithScalar(Vector<double> vector, double scalar)
        {
            return new Vector<double>(scalar * vector.x, scalar * vector.y, scalar * vector.z);
        }

        /// <summary>
        /// Scalar product of two vectors.
        /// </summary>
        /// <param name="a">Vector of double type.</param>
        /// <param name="b">Vector of double type.</param>
        /// <returns>Returns vector of double type.</returns>
        public double ScalarProduct(Vector<double> a, Vector<double> b)
        {
            return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
        }

        /// <summary>
        /// Vector norm.
        /// </summary>
        /// <param name="vector">Vector of double type.</param>
        /// <returns>Returns vector of double type.</returns>
        public double VectorNorm(Vector<double> vector)
        {
            return Math.Sqrt((vector.x * vector.x) + (vector.y * vector.y) + (vector.z * vector.z));
        }

        /// <summary>
        /// Distance between two vectors.
        /// </summary>
        /// <param name="a">Vector of double type.</param>
        /// <param name="b">Vector of double type.</param>
        /// <returns>Returns vector of double type.</returns>
        public double DistanceBetweenVectors(Vector<double> a, Vector<double> b)
        {
            return VectorNorm(Subtraction(a, b));
        }

        /// <summary>
        /// Angle between two vectors.
        /// </summary>
        /// <param name="a">Vector of double type.</param>
        /// <param name="b">Vector of double type.</param>
        /// <returns>Returns vector of double type.</returns>
        public double AngleBetweenVectors(Vector<double> a, Vector<double> b)
        {
            if (a.x != 0.0 && a.y != 0.0 && a.z != 0.0 && b.x != 0.0 && b.y != 0.0 && b.z != 0.0) {
                double cosinusValue = ScalarProduct(a, b) / (VectorNorm(a) * VectorNorm(b));
                return Math.Cos(cosinusValue);
            }
            else throw new ArgumentException();
            
        }

        /// <summary>
        /// Orthogonality of two vectors.
        /// </summary>
        /// <param name="a">Vector of double type.</param>
        /// <param name="b">Vector of double type.</param>
        /// <returns>Returns vector of double type.</returns>
        public bool OrthogonalityOfVectors(Vector<double> a, Vector<double> b)
        {
            double ab = ScalarProduct(a, b);
            if (ab == 0.0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Orthogonality of three vectors.
        /// </summary>
        /// <param name="a">Vector of double type.</param>
        /// <param name="b">Vector of double type.</param>
        /// <param name="c">Vector of double type.</param>
        /// <returns>Returns vector of double type.</returns>
        public bool OrthogonalityOfVectors(Vector<double> a, Vector<double> b, Vector<double> c)
        {
            if (OrthogonalityOfVectors(a, b) == true)
            {
                if (OrthogonalityOfVectors(a, c) == true)
                {
                    if (OrthogonalityOfVectors(b, c) == true)
                    {
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
