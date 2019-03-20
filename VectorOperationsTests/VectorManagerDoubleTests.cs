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
        Vector<double> VECTOR_RESULT;
        double RESULT_DOUBLE;
        bool RESULT_BOOL;

        public TestContext TestContext { get; set; }
        Vector<double> VECTOR_1 = new Vector<double>(1, 2, 3);
        Vector<double> VECTOR_2 = new Vector<double>(4.5, 5.5, 7);
        Vector<double> VECTOR_3 = new Vector<double>(0.3, 4.44, 8.1);
        Vector<double> VECTOR_4 = new Vector<double>(0, 0, 0);
        double SCALAR_1 = 5.34;

        [TestInitialize]
        public void TestInitialize() {
            VectorManagerDouble = new VectorManagerDouble();
        }

        [TestCleanup]
        public void TestCleanup() {
            VectorManagerDouble = null;
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
            Vector<double> VECTOR_A = new Vector<double>(
                Convert.ToDouble(TestContext.DataRow["x1"]),
                Convert.ToDouble(TestContext.DataRow["y1"]),
                Convert.ToDouble(TestContext.DataRow["z1"])
                );
            Vector<double> VECTOR_B = new Vector<double>(
                Convert.ToDouble(TestContext.DataRow["x2"]),
                Convert.ToDouble(TestContext.DataRow["y2"]),
                Convert.ToDouble(TestContext.DataRow["z2"])
                );
            
            VECTOR_RESULT = VectorManagerDouble.Add(VECTOR_A, VECTOR_B);
            Assert.AreEqual(Convert.ToDouble(TestContext.DataRow["x3"]), VECTOR_RESULT.x);
            Assert.AreEqual(Convert.ToDouble(TestContext.DataRow["y3"]), VECTOR_RESULT.y);
            Assert.AreEqual(Convert.ToDouble(TestContext.DataRow["z3"]), VECTOR_RESULT.z);
        }

        /// <summary>
        /// Testing operation of subtracting vectors.
        /// </summary>
        [TestMethod]
        public void SubstractingTest() {
            VECTOR_RESULT = VectorManagerDouble.Subtract(VECTOR_1, VECTOR_2);

            Assert.AreEqual(-3.5, VECTOR_RESULT.x);
            Assert.AreEqual(-3.5, VECTOR_RESULT.y);
            Assert.AreEqual(-4, VECTOR_RESULT.z);
        }

        /// <summary>
        /// Testing operation of multiplying vector with scalar.
        /// </summary>
        [TestMethod]
        public void MultiplyingTest() {
            VECTOR_RESULT = VectorManagerDouble.MultiplyWithScalar(VECTOR_1, SCALAR_1);

            Assert.AreEqual(5.34, VECTOR_RESULT.x);
            Assert.AreEqual(10.68, VECTOR_RESULT.y);
            Assert.AreEqual(16.02, VECTOR_RESULT.z);
        }

        /// <summary>
        /// Testing calculating vector norm.
        /// </summary>
        [TestMethod]
        public void VectorNormTest() {
            RESULT_DOUBLE = VectorManagerDouble.VectorNorm(VECTOR_2);

            Assert.AreEqual(9.97496867163, RESULT_DOUBLE, 0.1);
        }

        /// <summary>
        /// Testing calculating scalar product.
        /// </summary>
        [TestMethod]
        public void ScalarProductTest() {
            RESULT_DOUBLE = VectorManagerDouble.ScalarProduct(VECTOR_1, VECTOR_2);

            Assert.AreEqual(36.5, RESULT_DOUBLE, 0.1);
        }

        /// <summary>
        /// Testing calculating distance between vectors.
        /// </summary>
        [TestMethod]
        public void DistanceBetweenVectorsTest() {
            RESULT_DOUBLE = VectorManagerDouble.DistanceBetweenVectors(VECTOR_1, VECTOR_2);

            Assert.AreEqual(6.36396103067893, RESULT_DOUBLE, 0.1);
        }

        /// <summary>
        /// Testing calculating angle between vectors.
        /// </summary>
        [TestMethod]
        public void AngleBetweenVectors_1Test() {
            RESULT_DOUBLE = VectorManagerDouble.AngleBetweenVectors(VECTOR_1, VECTOR_2);

            Assert.AreEqual(0.58722671084815, RESULT_DOUBLE, 0.1);
        }

        /// <summary>
        /// Catching ArgumentException if given vectors are (0,0,0) and (0,0,0).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AngleBetweenVectors_2Test() {
            RESULT_DOUBLE = VectorManagerDouble.AngleBetweenVectors(VECTOR_4, VECTOR_4);
        }

        /// <summary>
        /// Testing orthogonality of 2 vectors with positive result.
        /// </summary>
        [TestMethod]
        public void OrthogonalityOf2Vectors_1Test() {
            RESULT_BOOL = VectorManagerDouble.OrthogonalityOfVectors(VECTOR_4, VECTOR_4);

            Assert.AreEqual(true, RESULT_BOOL);
        }

        /// <summary>
        /// Testing orthogonality of 2 vectors with negative result.
        /// </summary>
        [TestMethod]
        public void OrthogonalityOfVectors_2Test() {
            RESULT_BOOL = VectorManagerDouble.OrthogonalityOfVectors(VECTOR_1, VECTOR_2);

            Assert.AreEqual(false, RESULT_BOOL);
        }

        /// <summary>
        /// Testing orthogonality of 3 vectors with positive result.
        /// </summary>
        [TestMethod]
        public void OrthogonalityOf3Vectors_1Test() {
            RESULT_BOOL = VectorManagerDouble.OrthogonalityOfVectors(VECTOR_4, VECTOR_4, VECTOR_4);

            Assert.AreEqual(true, RESULT_BOOL);
        }

        /// <summary>
        /// Testing orthogonality of 3 vectors with negative result (when vector a and b aren't orthogonal).
        /// </summary>
        [TestMethod]
        public void OrthogonalityOf3Vectors_2Test() {
            RESULT_BOOL = VectorManagerDouble.OrthogonalityOfVectors(VECTOR_1, VECTOR_2, VECTOR_3);

            Assert.AreEqual(false, RESULT_BOOL);
        }

        /// <summary>
        /// Testing orthogonality of 3 vectors with negative result (when vector a and c aren't orthogonal).
        /// </summary>
        [TestMethod]
        public void OrthogonalityOf3Vectors_3Test() {
            RESULT_BOOL = VectorManagerDouble.OrthogonalityOfVectors(
                VECTOR_1,
                new Vector<double>(2.0, -1.0, 0.0),
                new Vector<double>(1.0, 2.0, -3.0));

            Assert.AreEqual(false, RESULT_BOOL);
        }

        /// <summary>
        /// Testing orthogonality of 3 vectors with negative result (when vector b and c aren't orthogonal).
        /// </summary>
        [TestMethod]
        public void OrthogonalityOf3Vectors_4Test() {
            RESULT_BOOL = VectorManagerDouble.OrthogonalityOfVectors(
                new Vector<double>(0.0, 1.0, 0.0),
                new Vector<double>(1.0, 0.0, 0.0),
                new Vector<double>(-1.0, 0.0, 0.0));
            Assert.AreEqual(false, RESULT_BOOL);
        }
    }
}
