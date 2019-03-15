using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorOperations {
    public interface IVector<T> {
        T GetX();
        T GetY();
        T GetZ();
    }
}
