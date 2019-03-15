using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorOperations
{
    public interface IOperations<T> {
        Vector<T> Add(Vector<T> a, Vector<T> b);
        Vector<T> Divide(Vector<T> a, Vector<T> b);
        Vector<T> MultiplyWithScalar(Vector<T> vector, T scalar);

        T ScalarProduct(Vector<T> a, Vector<T> b);
        T VectorNorm(Vector<T> vector);
        T DistanceBetweenVectors(Vector<T> a, Vector<T> b);
        T AngleBetweenVectors(Vector<T> a, Vector<T> b);
        bool OrthogonalityOfVectors(Vector<T> a, Vector<T> b);
        bool OrthogonalityOfVectors(Vector<T> a, Vector<T> b, Vector<T> c);
    }
}
