using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorOperations;

namespace VectorOperationsTests {
    [TestClass]
    public class VectorTests {
        /// <summary>
        /// Testing creating deep copy of vector - checking if created object isn't the same.
        /// </summary>
        [TestMethod]
        public void CopyingVectorTest() {
            Vector<int> VECTOR_1 = new Vector<int>(1, 2, 3);
            Vector<int> VECTOR_2 = new Vector<int>(VECTOR_1);

            Assert.AreNotSame(VECTOR_1, VECTOR_2);
        }
    }
}
