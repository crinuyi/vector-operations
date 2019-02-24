using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorOperations {
    class Operations {

        //iloczyn skalarny
        public double ScalarProduct(Vector a, Vector b) {
            return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
        }

        //norma wektora/długość wektora
        public double VectorNorm(Vector vector) {
            return Math.Sqrt((vector.x * vector.x) + (vector.y * vector.y) + (vector.z * vector.z));
        }

        //odległość pomiędzy wektorami
        public double DistanceBetweenVectors(Vector a, Vector b) {
            return VectorNorm(a - b);
        }

        //kąt pomiędzy NIEZEROWYMI wektorami (pamiętać o wyjątku!)
        public double AngleBetweenVectors(Vector a, Vector b) {
            double cosinusValue = ScalarProduct(a, b) / (VectorNorm(a) * VectorNorm(b));
            return Math.Cos(cosinusValue);
        }

        //ortogonalność wektorów - 2x
        public bool OrthogonalityOfVectors(Vector a, Vector b) {
            double ab = ScalarProduct(a, b);
            if (ab == 0.0)
                return true;
            else
                return false;
        }

        //ortogonalność wektorów - 3x
        public bool OrthogonalityOfVectors(Vector a, Vector b, Vector c) {
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
