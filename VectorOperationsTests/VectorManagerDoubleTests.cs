using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorOperations;
using System.IO;
using System.Reflection;

namespace VectorOperationsTests {
    /// <summary>
    /// Unit tests of Vector<double> class.
    /// </summary>
    [TestClass]
    public class VectorManagerDoubleTests {
        VectorManagerDouble VectorManagerDouble;
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize() {
            VectorManagerDouble = new VectorManagerDouble();
        }

        /// <summary>
        /// Testing operation of adding vectors using data-driven unit test.
        /// </summary>
        [TestMethod]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"D:\github\vector-operations\VectorOperationsTests\data.csv", 
            "data#csv", 
            DataAccessMethod.Sequential),
            DeploymentItem("data.csv")]
        public void AddingTest() {
            Vector<double> VECTOR_1 = new Vector<double>(
                Convert.ToDouble(TestContext.DataRow["a1"]),
                Convert.ToDouble(TestContext.DataRow["b1"]),
                Convert.ToDouble(TestContext.DataRow["c1"])
                );
            Vector<double> VECTOR_2 = new Vector<double>(
                Convert.ToDouble(TestContext.DataRow["a2"]),
                Convert.ToDouble(TestContext.DataRow["b2"]),
                Convert.ToDouble(TestContext.DataRow["c2"])
                );

            
            Vector<double> VECTOR_3 = VectorManagerDouble.Add(VECTOR_1, VECTOR_2);

            Assert.AreEqual(Convert.ToDouble(TestContext.DataRow["a3"]), VECTOR_3.x);
            Assert.AreEqual(Convert.ToDouble(TestContext.DataRow["b3"]), VECTOR_3.y);
            Assert.AreEqual(Convert.ToDouble(TestContext.DataRow["c3"]), VECTOR_3.z);
        }

        /// <summary>
        /// Testing operation of subtracting vectors.
        /// </summary>
        [TestMethod]
        public void SubstractingTest() {
            Vector<double> VECTOR_1 = new Vector<double>(1, 2, 3);
            Vector<double> VECTOR_2 = new Vector<double>(4.5, 5.5, 7);

            Vector<double> VECTOR_3 = VectorManagerDouble.Subtract(VECTOR_1, VECTOR_2);

            Assert.AreEqual(-3.5, VECTOR_3.x);
            Assert.AreEqual(-3.5, VECTOR_3.y);
            Assert.AreEqual(-4, VECTOR_3.z);
        }

        /// <summary>
        /// Testing operation of multiplying vector with scalar.
        /// </summary>
        [TestMethod]
        public void MultiplyingTest() {
            //poprawic wartosci!
            Vector<double> VECTOR_1 = new Vector<double>(1, 2, 3);
            double SCALAR_1 = 5.34;

            Vector<double> VECTOR_3 = VectorManagerDouble.MultiplyWithScalar(VECTOR_1, SCALAR_1);

            Assert.AreEqual(5.34, VECTOR_3.x);
            Assert.AreEqual(10.68, VECTOR_3.y);
            Assert.AreEqual(16.02, VECTOR_3.z);
        }
    }
}
