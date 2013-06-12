using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixRefactoring;

namespace UnitTestProject1
{
    [TestClass]
    public class MatrixRefactoringTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitializingTestSizeZero()
        {
            Matrix matrix = new Matrix(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitializingTestSizeOneHundredAndOne()
        {
            Matrix matrix = new Matrix(101);
        }

        [TestMethod]
        public void TestingToStringMethodSizeOne()
        {
            Matrix matrix = new Matrix(1);
            matrix.FillMatrix();

            string str = "  1";
            Assert.AreEqual(str, matrix.ToString());
        }

        [TestMethod]
        public void MyTestMethod()
        {
            Matrix matrix = new Matrix(6);
            matrix.FillMatrix();

            string str = 
                "  1 16 17 18 19 20\r\n" +
                " 15  2 27 28 29 21\r\n" +
                " 14 31  3 26 30 22\r\n" +
                " 13 36 32  4 25 23\r\n" +
                " 12 35 34 33  5 24\r\n" +
                " 11 10  9  8  7  6";
            Assert.AreEqual(str, matrix.ToString());
        }
    }
}
