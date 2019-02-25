using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorOperations;

namespace VectorOperationsTests {
    [TestClass]
    public class VectorTests {

        [TestMethod]
        public void Adding() {
            Vector VECTOR_1 = new Vector(1, 2, 3);
            Vector VECTOR_2 = new Vector(4.5, 5.66666, 7);

            Vector VECTOR_3 = VECTOR_1 + VECTOR_2;

            //zapytac sie jak to zmienic
            Assert.AreEqual(5.5, VECTOR_3.X);
            Assert.AreEqual(7.66666, VECTOR_3.Y);
            Assert.AreEqual(10, VECTOR_3.Z);
        }

        [TestMethod]
        public void Substracting() {
            Vector VECTOR_1 = new Vector(1, 2, 3);
            Vector VECTOR_2 = new Vector(4.5, 5.5, 7);

            Vector VECTOR_3 = VECTOR_1 - VECTOR_2;

            //zapytac sie jak to zmienic
            Assert.AreEqual(-3.5, VECTOR_3.X);
            Assert.AreEqual(-3.5, VECTOR_3.Y);
            Assert.AreEqual(-4, VECTOR_3.Z);
        }

        [TestMethod]
        public void Multiplying_1() {
            Vector VECTOR_1 = new Vector(1, 2, 3);
            double value = 5.34;

            Vector VECTOR_3 = value * VECTOR_1;

            //zapytac sie jak to zmienic
            Assert.AreEqual(5.34, VECTOR_3.X);
            Assert.AreEqual(10.68, VECTOR_3.Y);
            Assert.AreEqual(16.02, VECTOR_3.Z);
        }

        [TestMethod]
        public void Multiplying_2() {
            Vector VECTOR_1 = new Vector(1, 2, 3);
            double value = 5.34;

            Vector VECTOR_3 = VECTOR_1 * value;

            //zapytac sie jak to zmienic
            Assert.AreEqual(5.34, VECTOR_3.X);
            Assert.AreEqual(10.68, VECTOR_3.Y);
            Assert.AreEqual(16.02, VECTOR_3.Z);
        }

        [TestMethod]
        public void CheckingConstructor_1() {
            Vector vector = new Vector();

            Assert.AreEqual(0, vector.X);
            Assert.AreEqual(0, vector.Y);
            Assert.AreEqual(0, vector.Z);
        }

        [TestMethod]
        public void CheckingConstructor_2() {
            Vector vector = new Vector(1.5);

            Assert.AreEqual(1.5, vector.X);
            Assert.AreEqual(0, vector.Y);
            Assert.AreEqual(0, vector.Z);
        }

        [TestMethod]
        public void CheckingConstructor_3() {
            Vector vector = new Vector(1.5, 6.6);

            Assert.AreEqual(1.5, vector.X);
            Assert.AreEqual(6.6, vector.Y);
            Assert.AreEqual(0, vector.Z);
        }

        [TestMethod]
        public void CopyingVector() {
            Vector VECTOR_1 = new Vector(1, 2, 3);
            Vector VECTOR_2 = new Vector(VECTOR_1);

            Assert.AreNotSame(VECTOR_1, VECTOR_2);
        }
    }
}
