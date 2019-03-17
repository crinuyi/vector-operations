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
    public class VectorManagerStringTests {
        VectorManagerString VectorManagerString;
        Vector<string> VECTOR_RESULT;
        string RESULT_STRING;
        double RESULT_DOUBLE;
        bool RESULT_BOOL;

        public TestContext TestContext { get; set; }
        Vector<string> VECTOR_1 = new Vector<string>("1", "2", "3");
        Vector<string> VECTOR_2 = new Vector<string>("4,5", "5,5", "7");
        Vector<string> VECTOR_3 = new Vector<string>("0,3", "4,44", "8,1");
        Vector<string> VECTOR_4 = new Vector<string>("0", "0", "0");
        string SCALAR_1 = "5,34";

        [TestInitialize]
        public void TestInitialize() {
            VectorManagerString = new VectorManagerString();
        }

        [TestCleanup]
        public void TestCleanup() {
            VectorManagerString = null;
        }

        /// <summary>
        /// Testing operation of adding vectors using data-driven unit test.
        /// </summary>
        [TestMethod]
        public void AddingTest() {
            VECTOR_RESULT = VectorManagerString.Add(VECTOR_1, VECTOR_2);

            Assert.AreEqual("5,5", VECTOR_RESULT.x);
            Assert.AreEqual("7,5", VECTOR_RESULT.y);
            Assert.AreEqual("10", VECTOR_RESULT.z);
        }

        /// <summary>
        /// Testing operation of subtracting vectors.
        /// </summary>
        [TestMethod]
        public void SubstractingTest() {
            VECTOR_RESULT = VectorManagerString.Subtract(VECTOR_1, VECTOR_2);

            Assert.AreEqual("-3,5", VECTOR_RESULT.x);
            Assert.AreEqual("-3,5", VECTOR_RESULT.y);
            Assert.AreEqual("-4", VECTOR_RESULT.z);
        }

        /// <summary>
        /// Testing operation of multiplying vector with scalar.
        /// </summary>
        [TestMethod]
        public void MultiplyingTest() {
            VECTOR_RESULT = VectorManagerString.MultiplyWithScalar(VECTOR_1, SCALAR_1);

            Assert.AreEqual("5,34", VECTOR_RESULT.x);
            Assert.AreEqual("10,68", VECTOR_RESULT.y);
            Assert.AreEqual("16,02", VECTOR_RESULT.z);
        }

        /// <summary>
        /// Testing calculating vector norm.
        /// </summary>
        [TestMethod]
        public void VectorNormTest() {
            RESULT_DOUBLE = VectorManagerString.VectorNorm(VECTOR_2);

            Assert.AreEqual("9,97496867163", Convert.ToString(RESULT_DOUBLE));
        }

        /// <summary>
        /// Testing calculating scalar product.
        /// </summary>
        [TestMethod]
        public void ScalarProductTest() {
            RESULT_STRING = VectorManagerString.ScalarProduct(VECTOR_1, VECTOR_2);

            Assert.AreEqual("36,5", RESULT_STRING);
        }

        /// <summary>
        /// Testing calculating distance between vectors.
        /// </summary>
        [TestMethod]
        public void DistanceBetweenVectorsTest() {
            RESULT_DOUBLE = VectorManagerString.DistanceBetweenVectors(VECTOR_1, VECTOR_2);

            Assert.AreEqual("6,36396103067893", Convert.ToString(RESULT_DOUBLE));
        }

        /// <summary>
        /// Testing calculating angle between vectors.
        /// </summary>
        [TestMethod]
        public void AngleBetweenVectors_1Test() {
            RESULT_DOUBLE = VectorManagerString.AngleBetweenVectors(VECTOR_1, VECTOR_2);

            Assert.AreEqual("0,558722671084815", Convert.ToString(RESULT_DOUBLE));
        }

        /// <summary>
        /// Catching ArgumentException if given vectors are (0,0,0) and (0,0,0).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AngleBetweenVectors_2Test() {

            RESULT_DOUBLE = VectorManagerString.AngleBetweenVectors(VECTOR_4, VECTOR_4);
        }

        /// <summary>
        /// Testing orthogonality of 2 vectors with positive result.
        /// </summary>
        [TestMethod]
        public void OrthogonalityOf2Vectors_1Test() {
            RESULT_BOOL = VectorManagerString.OrthogonalityOfVectors(VECTOR_4, VECTOR_4);

            Assert.AreEqual(true, RESULT_BOOL);
        }

        /// <summary>
        /// Testing orthogonality of 2 vectors with negative result.
        /// </summary>
        [TestMethod]
        public void OrthogonalityOfVectors_2Test() {
            RESULT_BOOL = VectorManagerString.OrthogonalityOfVectors(VECTOR_1, VECTOR_2);

            Assert.AreEqual(false, RESULT_BOOL);
        }

        /// <summary>
        /// Testing orthogonality of 3 vectors with positive result.
        /// </summary>
        [TestMethod]
        public void OrthogonalityOf3Vectors_1Test() {
            RESULT_BOOL = VectorManagerString.OrthogonalityOfVectors(VECTOR_4, VECTOR_4, VECTOR_4);

            Assert.AreEqual(true, RESULT_BOOL);
        }

        /// <summary>
        /// Testing orthogonality of 3 vectors with negative result (when vector a and b aren't orthogonal).
        /// </summary>
        [TestMethod]
        public void OrthogonalityOf3Vectors_2Test() {
            RESULT_BOOL = VectorManagerString.OrthogonalityOfVectors(VECTOR_1, VECTOR_2, VECTOR_3);

            Assert.AreEqual(false, RESULT_BOOL);
        }

        /// <summary>
        /// Testing orthogonality of 3 vectors with negative result (when vector a and c aren't orthogonal).
        /// </summary>
        [TestMethod]
        public void OrthogonalityOf3Vectors_3Test() {
            RESULT_BOOL = VectorManagerString.OrthogonalityOfVectors(
                VECTOR_1,
                new Vector<string>("2,0", "-1,0", "0,0"),
                new Vector<string>("1,0", "2,0", "-3,0"));

            Assert.AreEqual(false, RESULT_BOOL);
        }

        /// <summary>
        /// Testing orthogonality of 3 vectors with negative result (when vector b and c aren't orthogonal).
        /// </summary>
        [TestMethod]
        public void OrthogonalityOf3Vectors_4Test() {
            RESULT_BOOL = VectorManagerString.OrthogonalityOfVectors(
                new Vector<string>("0,0", "1,0", "0,0"),
                new Vector<string>("1,0", "0,0", "0,0"),
                new Vector<string>("-1,0", "0,0", "0,0"));
            Assert.AreEqual(false, RESULT_BOOL);
        }
    }
}
