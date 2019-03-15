using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorOperations {
    class Operations : IOperations<double> {
        /// <summary>
        /// Operacja dodawania wektorów. 
        /// </summary>
        /// <param name="a">Wektor typu double.</param>
        /// <param name="b">Wektor typu double.</param>
        /// <returns>Zwraca wektor typu double.</returns>
        public Vector<double> Add(Vector<double> a, Vector<double> b)
        {
            return new Vector<double>(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        /// <summary>
        /// Operacja odejmowania wektorów. 
        /// </summary>
        /// <param name="a">Wektor typu double.</param>
        /// <param name="b">Wektor typu double.</param>
        /// <returns>Zwraca wektor typu double.</returns>
        public Vector<double> Divide(Vector<double> a, Vector<double> b)
        {
            return new Vector<double>(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        /// <summary>
        /// Operacja mnożenia wektorów. 
        /// </summary>
        /// <param name="a">Wektor typu double.</param>
        /// <param name="b">Wektor typu double.</param>
        /// <returns>Zwraca wektor typu double.</returns>
        public Vector<double> MultiplyWithScalar(Vector<double> vector, double scalar)
        {
            return new Vector<double>(scalar * vector.x, scalar * vector.y, scalar * vector.z);
        }

        /// <summary>
        /// Iloczyn skalarny dwóch wektorów.
        /// </summary>
        /// <param name="a">Wektor typu double.</param>
        /// <param name="b">Wektor typu double.</param>
        /// <returns>Zwraca wartość zmiennoprzecinkową.</returns>
        public double ScalarProduct(Vector<double> a, Vector<double> b)
        {
            return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
        }

        /// <summary>
        /// Norma/długość wektora.
        /// </summary>
        /// <param name="vector">Wektor typu double.</param>
        /// <returns>Zwraca wartość zmiennoprzecinkową.</returns>
        public double VectorNorm(Vector<double> vector)
        {
            return Math.Sqrt((vector.x * vector.x) + (vector.y * vector.y) + (vector.z * vector.z));
        }

        /// <summary>
        /// Odległość pomiędzy dwoma wektorami.
        /// </summary>
        /// <param name="a">Wektor typu double.</param>
        /// <param name="b">Wektor typu double.</param>
        /// <returns>Zwraca wartość zmiennoprzecinkową.</returns>
        public double DistanceBetweenVectors(Vector<double> a, Vector<double> b)
        {
            return VectorNorm(Divide(a, b));
        }

        /// <summary>
        /// Kąt pomiędzy niezerowymi wektorami.
        /// </summary>
        /// <param name="a">Wektor typu double.</param>
        /// <param name="b">Wektor typu double.</param>
        /// <returns>Zwraca wartość zmiennoprzecinkową.</returns>
        public double AngleBetweenVectors(Vector<double> a, Vector<double> b)
        {
            if (a.GetX() != 0.0 && a.GetY() != 0 && a.GetZ() != 0 && b.GetX() != 0 && b.GetY() != 0 && b.GetZ() != 0) {
                double cosinusValue = ScalarProduct(a, b) / (VectorNorm(a) * VectorNorm(b));
                return Math.Cos(cosinusValue);
            }
            else throw new ArgumentException();
            
        }

        //ortogonalność wektorów - 2x
        public bool OrthogonalityOfVectors(Vector<double> a, Vector<double> b)
        {
            double ab = ScalarProduct(a, b);
            if (ab == 0.0)
                return true;
            else
                return false;
        }

        //ortogonalność wektorów - 3x
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
