using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorOperations {
    public class VectorManagerString : IVectorManager<string> {
        private static Vector<double> ConvertVector(Vector<string> vector) {
            Vector<double> newVector = null;

            try {
                newVector = new Vector<double>(
                    double.Parse(vector.x), 
                    double.Parse(vector.y), 
                    double.Parse(vector.z));
            } catch (ArgumentNullException e) {
                return null;
            } catch (FormatException e) {
                return null;
            } catch (OverflowException e) {
                return null;
            }

            return newVector;
        }

        /// <summary>
        /// Converts values of given vectors to double and add them.
        /// </summary>
        /// <param name="a">Vector of string type.</param>
        /// <param name="b">Vector of string type.</param>
        /// <returns>Returns vector of string type or null, if exception occured during converting values from string to double type.</returns>
        public Vector<string> Add(Vector<string> a, Vector<string> b) {
            Vector<double> aDouble = ConvertVector(a);
            Vector<double> bDouble = ConvertVector(b);
            if (aDouble != null && bDouble != null) {
                double resultX = aDouble.x + bDouble.x;
                double resultY = aDouble.y + bDouble.y;
                double resultZ = aDouble.z + bDouble.z;
                return new Vector<string>(resultX.ToString(), resultY.ToString(), resultZ.ToString());
            }
            else return null;
            
        }

        /// <summary>
        /// Converts values of given vectors to double and calculate the angle between them.
        /// </summary>
        /// <param name="a">Vector of string type.</param>
        /// <param name="b">Vector of string type.</param>
        /// <exception cref="ArgumentException">Thrown when given vectors are (0,0,0) and (0,0,0).</exception>
        /// <returns>Returns the angle as double value or -1.0 if exception occured during converting values from string to double type.</returns>
        public double AngleBetweenVectors(Vector<string> a, Vector<string> b) {
            Vector<double> aDouble = ConvertVector(a);
            Vector<double> bDouble = ConvertVector(b);
            if (aDouble != null && bDouble != null) {
                if (aDouble.x != 0.0 && aDouble.y != 0.0 && aDouble.z != 0.0 && bDouble.x != 0.0 && bDouble.y != 0.0 && bDouble.z != 0.0) {
                    double cosinusValue = double.Parse(ScalarProduct(a, b)) / (VectorNorm(a) * VectorNorm(b));
                    return Math.Cos(cosinusValue);
                }
                else throw new ArgumentException();
            }
            else return -1.0;
        }

        /// <summary>
        /// Distance between two given vectors.
        /// </summary>
        /// <param name="a">Vector of string type.</param>
        /// <param name="b">Vector of string type.</param>
        /// <returns>Returns the distance as double value.</returns>
        public double DistanceBetweenVectors(Vector<string> a, Vector<string> b) {
            return VectorNorm(Subtract(a, b));
        }

        /// <summary>
        /// Converts values of vectors to double and multiply it with scalar.
        /// </summary>
        /// <param name="vector">Vector of string type.</param>
        /// <param name="scalar">Scalar of double type.</param>
        /// <returns>Returns vector of string type or null if exception occured during converting values from string to double type.</returns>
        public Vector<string> MultiplyWithScalar(Vector<string> vector, string scalar) {
            double scalarDouble;

            try
            {
                scalarDouble = double.Parse(scalar);
            } catch (ArgumentNullException e)
            {
                return null;
            } catch (FormatException e)
            {
                return null;
            } catch (OverflowException e)
            {
                return null;
            }

            Vector<double> vectorDouble = ConvertVector(vector);
            if (vectorDouble != null) {
                double newX = scalarDouble * vectorDouble.x;
                double newY = scalarDouble * vectorDouble.y;
                double newZ = scalarDouble * vectorDouble.z;
                return new Vector<string>(Convert.ToString(newX), Convert.ToString(newY), Convert.ToString(newZ));
            }
            else return null;
        }

        /// <summary>
        /// Calculate orthogonality of two given vectors.
        /// </summary>
        /// <param name="a">Vector of string type.</param>
        /// <param name="b">Vector of string type.</param>
        /// <exception cref="ArgumentException">Throws if vectors have non-numeric values.</exception>
        /// <returns>Returns true, false or ArgumentException if it occured during converting values from string to double type.</returns>
        public bool OrthogonalityOfVectors(Vector<string> a, Vector<string> b) {
            double ab;
            if (ScalarProduct(a, b) != null)
                ab = double.Parse(ScalarProduct(a, b));
            else throw new ArgumentException();
            if (ab == 0.0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Calculate orthogonality of three given vectors.
        /// </summary>
        /// <param name="a">Vector of string type.</param>
        /// <param name="b">Vector of string type.</param>
        /// <param name="c">Vector of string type.</param>
        /// <returns>Returns true, false or ArgumentException if it occured during converting values from string to double type.</returns>
        public bool OrthogonalityOfVectors(Vector<string> a, Vector<string> b, Vector<string> c) {
            try {
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
            } catch(ArgumentException e) {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Calculate scalar product of two given vectors.
        /// </summary>
        /// <param name="a">Vector of string type.</param>
        /// <param name="b">Vector of string type.</param>
        /// <returns>Returns string value or null if exception occured during converting values from string to double type.</returns>
        public string ScalarProduct(Vector<string> a, Vector<string> b) {
            Vector<double> aDouble = ConvertVector(a);
            Vector<double> bDouble = ConvertVector(b);

            if (aDouble != null && bDouble != null)
                return Convert.ToString((aDouble.x * bDouble.x) + (aDouble.y * bDouble.y) + (aDouble.z * bDouble.z));
            else return null;
        }

        /// <summary>
        /// Operation of subtracting vectors. Converts values of vectors to double and subtract them.
        /// </summary>
        /// <param name="a">Vector of string type.</param>
        /// <param name="b">Vector of string type.</param>
        /// <returns>Returns vector of string type or null, if exception occured during converting values from string to double type.</returns>
        public Vector<string> Subtract(Vector<string> a, Vector<string> b) {
            Vector<double> aDouble = ConvertVector(a);
            Vector<double> bDouble = ConvertVector(b);

            if (aDouble != null && bDouble != null) {
                double resultX = aDouble.x - bDouble.x;
                double resultY = aDouble.y - bDouble.y;
                double resultZ = aDouble.z - bDouble.z;
                return new Vector<string>(resultX.ToString(), resultY.ToString(), resultZ.ToString());
            }
            else return null;
        }

        /// <summary>
        /// Vector norm.
        /// </summary>
        /// <param name="vector">Vector of string type.</param>
        /// <returns>Returns vector norm or -1.0 if exceptions occured during converting values from string to double type.</returns>
        public double VectorNorm(Vector<string> vector) {
            Vector<double> vectorDouble = ConvertVector(vector);

            if (vectorDouble != null)
                return Math.Sqrt((vectorDouble.x * vectorDouble.x) + (vectorDouble.y * vectorDouble.y) + (vectorDouble.z * vectorDouble.z));
            else return -1.0;
        }
    }
}