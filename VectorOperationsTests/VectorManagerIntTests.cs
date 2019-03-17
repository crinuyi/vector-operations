using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorOperations;
using System.IO;
using System.Reflection;

namespace VectorOperationsTests {
    /// <summary>
    /// Unit tests of Vector<int> class.
    /// </summary>
    [TestClass]
    public class VectorManagerIntTests {
        VectorManagerInt VectorManagerInt;
        Vector<int> VECTOR_RESULT;
        double RESULT_DOUBLE;
        bool RESULT_BOOL;

        public TestContext TestContext { get; set; }
        Vector<int> VECTOR_1 = new Vector<int>(1, 2, 3);
        Vector<int> VECTOR_2 = new Vector<int>(4, 5, 7);
        Vector<int> VECTOR_3 = new Vector<int>(3, 4, 8);
        Vector<int> VECTOR_4 = new Vector<int>(0, 0, 0);
        int SCALAR_1 = 5;

        [TestInitialize]
        public void TestInitialize() {
            VectorManagerInt = new VectorManagerInt();
        }

        [TestCleanup]
        public void TestCleanup() {
            VectorManagerInt = null;
        }

        /// <summary>
        /// Testing operation of adding vectors.
        /// </summary>
        [TestMethod]
        public void AddingTest() {
            VECTOR_RESULT = VectorManagerInt.Add(VECTOR_1, VECTOR_2);

            Assert.AreEqual(5, VECTOR_RESULT.x);
            Assert.AreEqual(7, VECTOR_RESULT.y);
            Assert.AreEqual(10, VECTOR_RESULT.z);
        }

        /// <summary>
        /// Testing operation of subtracting vectors.
        /// </summary>
        [TestMethod]
        public void SubstractingTest() {
            VECTOR_RESULT = VectorManagerInt.Subtract(VECTOR_1, VECTOR_2);

            Assert.AreEqual(-3, VECTOR_RESULT.x);
            Assert.AreEqual(-3, VECTOR_RESULT.y);
            Assert.AreEqual(-4, VECTOR_RESULT.z);
        }

        /// <summary>
        /// Testing operation of multiplying vector with scalar.
        /// </summary>
        [TestMethod]
        public void MultiplyingTest() {
            VECTOR_RESULT = VectorManagerInt.MultiplyWithScalar(VECTOR_1, SCALAR_1);

            Assert.AreEqual(5, VECTOR_RESULT.x);
            Assert.AreEqual(10, VECTOR_RESULT.y);
            Assert.AreEqual(15, VECTOR_RESULT.z);
        }

        /// <summary>
        /// Testing calculating vector norm.
        /// </summary>
        [TestMethod]
        public void VectorNormTest() {
            RESULT_DOUBLE = VectorManagerInt.VectorNorm(VECTOR_1);

            Assert.AreEqual(3.74165738677394, RESULT_DOUBLE, 0.1);
        }

        /// <summary>
        /// Testing calculating scalar product.
        /// </summary>
        [TestMethod]
        public void ScalarProductTest() {
            RESULT_DOUBLE = VectorManagerInt.ScalarProduct(VECTOR_1, VECTOR_2);

            Assert.AreEqual(35, RESULT_DOUBLE, 0.1);
        }

        /// <summary>
        /// Testing calculating distance between vectors.
        /// </summary>
        [TestMethod]
        public void DistanceBetweenVectorsTest() {
            RESULT_DOUBLE = VectorManagerInt.DistanceBetweenVectors(VECTOR_1, VECTOR_2);

            Assert.AreEqual(5.8309518948453, RESULT_DOUBLE, 0.1);
        }

        /// <summary>
        /// Testing calculating angle between vectors.
        /// </summary>
        [TestMethod]
        public void AngleBetweenVectors_1Test() {
            RESULT_DOUBLE = VectorManagerInt.AngleBetweenVectors(VECTOR_1, VECTOR_2);

            Assert.AreEqual(0.58722671084815, RESULT_DOUBLE, 0.1);
        }

        /// <summary>
        /// Catching ArgumentException if given vectors are (0,0,0) and (0,0,0).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AngleBetweenVectors_2Test() {

            RESULT_DOUBLE = VectorManagerInt.AngleBetweenVectors(VECTOR_4, VECTOR_4);
        }

        /// <summary>
        /// Testing orthogonality of 2 vectors with positive result.
        /// </summary>
        [TestMethod]
        public void OrthogonalityOf2Vectors_1Test() {
            RESULT_BOOL = VectorManagerInt.OrthogonalityOfVectors(VECTOR_4, VECTOR_4);

            Assert.AreEqual(true, RESULT_BOOL);
        }

        /// <summary>
        /// Testing orthogonality of 2 vectors with negative result.
        /// </summary>
        [TestMethod]
        public void OrthogonalityOfVectors_2Test() {
            RESULT_BOOL = VectorManagerInt.OrthogonalityOfVectors(VECTOR_1, VECTOR_2);

            Assert.AreEqual(false, RESULT_BOOL);
        }

        /// <summary>
        /// Testing orthogonality of 3 vectors with positive result.
        /// </summary>
        [TestMethod]
        public void OrthogonalityOf3Vectors_1Test() {
            RESULT_BOOL = VectorManagerInt.OrthogonalityOfVectors(VECTOR_4, VECTOR_4, VECTOR_4);

            Assert.AreEqual(true, RESULT_BOOL);
        }

        /// <summary>
        /// Testing orthogonality of 3 vectors with negative result (when vector a and b aren't orthogonal).
        /// </summary>
        [TestMethod]
        public void OrthogonalityOf3Vectors_2Test() {
            RESULT_BOOL = VectorManagerInt.OrthogonalityOfVectors(VECTOR_1, VECTOR_2, VECTOR_3);

            Assert.AreEqual(false, RESULT_BOOL);
        }

        /// <summary>
        /// Testing orthogonality of 3 vectors with negative result (when vector a and c aren't orthogonal).
        /// </summary>
        [TestMethod]
        public void OrthogonalityOf3Vectors_3Test() {
            RESULT_BOOL = VectorManagerInt.OrthogonalityOfVectors(
                VECTOR_1,
                new Vector<int>(2, -1, 0),
                new Vector<int>(1, 2, -3));

            Assert.AreEqual(false, RESULT_BOOL);
        }

        /// <summary>
        /// Testing orthogonality of 3 vectors with negative result (when vector b and c aren't orthogonal).
        /// </summary>
        [TestMethod]
        public void OrthogonalityOf3Vectors_4Test() {
            RESULT_BOOL = VectorManagerInt.OrthogonalityOfVectors(
                new Vector<int>(0, 1, 0),
                new Vector<int>(1, 0, 0),
                new Vector<int>(-1, 0, 0));
            Assert.AreEqual(false, RESULT_BOOL);
        }
    }
}
