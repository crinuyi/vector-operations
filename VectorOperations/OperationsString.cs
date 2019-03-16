using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorOperations {
    class OperationsString : IOperations<string>
    {
        /// <summary>
        /// Operation of adding vectors. Converts values of vectors to double and add them.
        /// </summary>
        /// <param name="a">Vector of string type.</param>
        /// <param name="b">Vector of string type.</param>
        /// <returns>Returns vector of string type or null, if exception occured during converting values from string to double type.</returns>
        public Vector<string> Add(Vector<string> a, Vector<string> b) {
            double x1, y1, z1, x2, y2, z2;

            try
            {
                x1 = double.Parse(a.x);
                y1 = double.Parse(a.y);
                z1 = double.Parse(a.z);
                x2 = double.Parse(b.x);
                y2 = double.Parse(b.y);
                z2 = double.Parse(b.z);
            } catch(ArgumentNullException e) {
                return null;
            } catch(FormatException e) {
                return null;
            } catch(OverflowException e) {
                return null;
            }

            double resultX = x1 + x2;
            double resultY = y1 + y2;
            double resultZ = z1 + z2;
            return new Vector<string>(resultX.ToString(), resultY.ToString(), resultZ.ToString());
        }

        /// <summary>
        /// Converts values of vectors to double and count the angle between them.
        /// </summary>
        /// <param name="a">Vector of string type.</param>
        /// <param name="b">Vector of string type.</param>
        /// <exception cref="ArgumentException">Thrown when given vectors are (0,0,0) and (0,0,0).</exception>
        /// <returns>Returns vector of string type or -1.0 if exception occured during converting values from string to double type.</returns>
        public double AngleBetweenVectors(Vector<string> a, Vector<string> b)
        {
            double x1, y1, z1, x2, y2, z2;

            try
            {
                x1 = double.Parse(a.x);
                y1 = double.Parse(a.y);
                z1 = double.Parse(a.z);
                x2 = double.Parse(b.x);
                y2 = double.Parse(b.y);
                z2 = double.Parse(b.z);
            } catch (ArgumentNullException e)
            {
                return -1.0;
            } catch (FormatException e)
            {
                return -1.0;
            } catch (OverflowException e)
            {
                return -1.0;
            }

            if (x1 != 0.0 && y1 != 0.0 && z1 != 0.0 && x2 != 0.0 && y2 != 0.0 && z2 != 0.0)
            {
                double cosinusValue = double.Parse(ScalarProduct(a, b)) / (VectorNorm(a) * VectorNorm(b));
                return Math.Cos(cosinusValue);
            }
            else throw new ArgumentException();
        }

        /// <summary>
        /// Distance between two vectors.
        /// </summary>
        /// <param name="a">Vector of string type.</param>
        /// <param name="b">Vector of string type.</param>
        /// <returns>Returns vector of string type.</returns>
        public double DistanceBetweenVectors(Vector<string> a, Vector<string> b)
        {
            return VectorNorm(Subtraction(a, b));
        }

        public Vector<string> MultiplyWithScalar(Vector<string> vector, string scalar)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Orthogonality of two vectors.
        /// </summary>
        /// <param name="a">Vector of string type.</param>
        /// <param name="b">Vector of string type.</param>
        /// <exception cref="ArgumentException">Throws if vectors have non-numeric values.</exception>
        /// <returns>Returns true, false or ArgumentException if it occured during converting values from string to double type.</returns>
        public bool OrthogonalityOfVectors(Vector<string> a, Vector<string> b)
        {
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
        /// Orthogonality of three vectors.
        /// </summary>
        /// <param name="a">Vector of string type.</param>
        /// <param name="b">Vector of string type.</param>
        /// <param name="c">Vector of string type.</param>
        /// <returns>Returns true, false or ArgumentException if it occured during converting values from string to double type.</returns>

        public bool OrthogonalityOfVectors(Vector<string> a, Vector<string> b, Vector<string> c)
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

        /// <summary>
        /// Scalar product of two vectors.
        /// </summary>
        /// <param name="a">Vector of string type.</param>
        /// <param name="b">Vector of string type.</param>
        /// <returns>Returns string value or null if exception occured during converting values from string to double type.</returns>
        public string ScalarProduct(Vector<string> a, Vector<string> b) {
            double x1, y1, z1, x2, y2, z2;

            try
            {
                x1 = double.Parse(a.x);
                y1 = double.Parse(a.y);
                z1 = double.Parse(a.z);
                x2 = double.Parse(b.x);
                y2 = double.Parse(b.y);
                z2 = double.Parse(b.z);
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

            return Convert.ToString((x1 * x2) + (y1 * y2) + (z1 * z2));
        }

        /// <summary>
        /// Operation of subtracting vectors. Converts values of vectors to double and subtract them.
        /// </summary>
        /// <param name="a">Vector of string type.</param>
        /// <param name="b">Vector of string type.</param>
        /// <returns>Returns vector of string type or null, if exception occured during converting values from string to double type.</returns>
        public Vector<string> Subtraction(Vector<string> a, Vector<string> b)
        {
            double x1, y1, z1, x2, y2, z2;

            try
            {
                x1 = double.Parse(a.x);
                y1 = double.Parse(a.y);
                z1 = double.Parse(a.z);
                x2 = double.Parse(b.x);
                y2 = double.Parse(b.y);
                z2 = double.Parse(b.z);
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

            double resultX = x1 - x2;
            double resultY = y1 - y2;
            double resultZ = z1 - z2;
            return new Vector<string>(resultX.ToString(), resultY.ToString(), resultZ.ToString());
        }

        /// <summary>
        /// Vector norm.
        /// </summary>
        /// <param name="vector">Vector of string type.</param>
        /// <returns>Returns vector norm or -1.0 if exceptions occured during converting values from string to double type.</returns>
        public double VectorNorm(Vector<string> vector)
        {
            double x, y, z;

            try
            {
                x = double.Parse(vector.x);
                y = double.Parse(vector.y);
                z = double.Parse(vector.z);
            } catch (ArgumentNullException e)
            {
                return -1.0;
            } catch (FormatException e)
            {
                return -1.0;
            } catch (OverflowException e)
            {
                return -1.0;
            }

            return Math.Sqrt((x * x) + (y * y) + (z * z));
        }
    }
}
