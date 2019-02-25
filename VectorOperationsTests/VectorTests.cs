using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorOperations;

namespace VectorOperationsTests {
    [TestClass]
    public class VectorTests {

        [TestMethod]
        public void TestMethod1() {
            Vector vector = new Vector(1, 2, 3);
            Assert.AreEqual(2.0, vector.Y);
        }
    }
}
