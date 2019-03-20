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
        /// Testing operation of adding vectors.
        /// </summary>
        [TestMethod]
        public void AddingTest_1() {
            VECTOR_RESULT = VectorManagerString.Add(VECTOR_1, VECTOR_2);

            Assert.AreEqual("5,5", VECTOR_RESULT.x);
            Assert.AreEqual("7,5", VECTOR_RESULT.y);
            Assert.AreEqual("10", VECTOR_RESULT.z);
        }

        /// <summary>
        /// Testing operation of adding vectors - returned null because of invalid argument.
        /// </summary>
        [TestMethod]
        public void Adding_Test_2() {
            VECTOR_RESULT = VectorManagerString.Add(VECTOR_1, new Vector<string>("", "2,0", "3"));

            Assert.AreEqual(null, VECTOR_RESULT);
        }

        /// <summary>
        /// Testing operation of subtracting vectors.
        /// </summary>
        [TestMethod]
        public void SubstractingTest_1() {
            VECTOR_RESULT = VectorManagerString.Subtract(VECTOR_1, VECTOR_2);

            Assert.AreEqual("-3,5", VECTOR_RESULT.x);
            Assert.AreEqual("-3,5", VECTOR_RESULT.y);
            Assert.AreEqual("-4", VECTOR_RESULT.z);
        }

        /// <summary>
        /// Testing operation of subtracting vectors - returned null because of invalid argument.
        /// </summary>
        [TestMethod]
        public void SubtractingTest_2() {
            VECTOR_RESULT = VectorManagerString.Subtract(VECTOR_1, new Vector<string>("test", "2,0", "3"));

            Assert.AreEqual(null, VECTOR_RESULT);
        }

        /// <summary>
        /// Testing operation of multiplying vector with scalar.
        /// </summary>
        [TestMethod]
        public void MultiplyingTest_1() {
            VECTOR_RESULT = VectorManagerString.MultiplyWithScalar(VECTOR_1, SCALAR_1);

            Assert.AreEqual("5,34", VECTOR_RESULT.x);
            Assert.AreEqual("10,68", VECTOR_RESULT.y);
            Assert.AreEqual("16,02", VECTOR_RESULT.z);
        }

        /// <summary>
        /// Testing operation of multiplying vector with scalar - returned null because of invalid argument.
        /// </summary>
        [TestMethod]
        public void MultiplyingTest_2() {
            VECTOR_RESULT = VectorManagerString.MultiplyWithScalar(new Vector<string>("test", "2,0", "3"), SCALAR_1);

            Assert.AreEqual(null, VECTOR_RESULT);
        }

        /// <summary>
        /// Testing operation of multiplying vector with scalar - returned null because of invalid argument.
        /// </summary>
        [TestMethod]
        public void MultiplyingTest_3() {
            VECTOR_RESULT = VectorManagerString.MultiplyWithScalar(VECTOR_1, "");

            Assert.AreEqual(null, VECTOR_RESULT);
        }

        /// <summary>
        /// Testing operation of multiplying vector with scalar - returned null because of invalid argument.
        /// </summary>
        [TestMethod]
        public void MultiplyingTest_4() {
            VECTOR_RESULT = VectorManagerString.MultiplyWithScalar(VECTOR_1, null);

            Assert.AreEqual(null, VECTOR_RESULT);
        }

        /// <summary>
        /// Testing operation of multiplying vector with scalar - returned null because of invalid argument.
        /// </summary>
        [TestMethod]
        public void MultiplyingTest_5() {
            VECTOR_RESULT = VectorManagerString.MultiplyWithScalar(VECTOR_1, "1e99999");

            Assert.AreEqual(null, VECTOR_RESULT);
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
        /// Testing calculating vector norm - returned -1.0 because of invalid argument.
        /// </summary>
        [TestMethod]
        public void VectorNormTest_2() {
            RESULT_DOUBLE = VectorManagerString.VectorNorm(new Vector<string>("3", null, "3"));

            Assert.AreEqual(-1, RESULT_DOUBLE);
        }

        /// <summary>
        /// Testing calculating scalar product.
        /// </summary>
        [TestMethod]
        public void ScalarProductTest_1() {
            RESULT_STRING = VectorManagerString.ScalarProduct(VECTOR_1, VECTOR_2);

            StringAssert.Contains("36,5", RESULT_STRING);
        }

        /// <summary>
        /// Testing calculating scalar product - returned null because of invalid argument.
        /// </summary>
        [TestMethod]
        public void ScalarProductTest_2() {
            RESULT_STRING = VectorManagerString.ScalarProduct(VECTOR_1, new Vector<string>("1e999999","3", "3"));

            Assert.AreEqual(null, RESULT_STRING);
        }

        /// <summary>
        /// Testing calculating distance between vectors.
        /// </summary>
        [TestMethod]
        public void DistanceBetweenVectorsTest_1() {
            RESULT_DOUBLE = VectorManagerString.DistanceBetweenVectors(VECTOR_1, VECTOR_2);

            Assert.AreEqual("6,36396103067893", Convert.ToString(RESULT_DOUBLE));
        }

        /// <summary>
        /// Testing calculating distance between vectors - returned -1.0 because of invalid argument.
        /// </summary>
        [TestMethod]
        public void DistanceBetweenVectorsTest_2() {
            RESULT_DOUBLE = VectorManagerString.DistanceBetweenVectors(VECTOR_1, new Vector<string>("", "3", "3"));

            Assert.AreEqual(-1.0, RESULT_DOUBLE);
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
        /// Testing calculating angle between vectors - returned -1.0 because of invalid argument.
        /// </summary>
        [TestMethod]
        public void AngleBetweenVectors_3Test() {
            RESULT_DOUBLE = VectorManagerString.AngleBetweenVectors(VECTOR_1, new Vector<string>("", "3", "3"));

            Assert.AreEqual(-1, RESULT_DOUBLE);
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
        public void OrthogonalityOf2Vectors_2Test() {
            RESULT_BOOL = VectorManagerString.OrthogonalityOfVectors(VECTOR_1, VECTOR_2);

            Assert.AreEqual(false, RESULT_BOOL);
        }

        /// <summary>
        /// Catching ArgumentException if given vector in argument is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OrthogonalityOf2Vectors_3Test() {
            RESULT_BOOL = VectorManagerString.OrthogonalityOfVectors(null, VECTOR_2);
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

        /// <summary>
        /// Testing orthogonality of 3 vectors with negative result - returned false because of invalid argument.
        /// </summary>
        [TestMethod]
        public void OrthogonalityOf3Vectors_5Test() {
            RESULT_BOOL = VectorManagerString.OrthogonalityOfVectors(
                VECTOR_1, 
                VECTOR_2,
                new Vector<string>("", "3", "3"));

            Assert.AreEqual(false, RESULT_BOOL);
        }

        /// <summary>
        /// Catching ArgumentException if given vector in argument is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OrthogonalityOf3Vectors_6Test() {
            RESULT_BOOL = VectorManagerString.OrthogonalityOfVectors(null, VECTOR_2, VECTOR_3);
        }
    }
}
