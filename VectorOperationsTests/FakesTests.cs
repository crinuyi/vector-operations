using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorOperations;
using static System.Math;

namespace VectorOperationsTests {

    [TestClass]
    public class FakesTests {
        Vector<double> vectorA = new Vector<double>(1, 4.5, 9);
        Vector<double> vectorB = new Vector<double>(4.7, 6, 9.99);

        [TestMethod]
        public void StubTest() {
            IVectorManager<double> vectorManager = new VectorOperations.Fakes.StubIVectorManager<double>() {
                AngleBetweenVectorsVectorOfT0VectorOfT0 = (a, b) => { return 1.0; }
            };

            Assert.AreEqual(1.0, vectorManager.AngleBetweenVectors(vectorA, vectorB), 0.1);
        }

        [TestMethod]
        public void ShimTest() {
            using (ShimsContext.Create()) {
                VectorOperations.Fakes.ShimVectorManagerString.ConvertVectorVectorOfString =
                    vector => { return new Vector<double>(1.2, 4, 5); };

                Vector<string> vectorString = new Vector<string>("6.66", "6", "9");
                Vector<double> vectorDouble = VectorManagerString.ConvertVector(vectorString);

                Assert.AreEqual(1.2, vectorDouble.x);
            }
        }
    }
}
