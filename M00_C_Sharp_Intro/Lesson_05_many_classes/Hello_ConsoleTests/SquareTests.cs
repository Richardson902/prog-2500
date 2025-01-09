using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hello_Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Console.Tests
{
    [TestClass()]
    public class SquareTests
    {
        [TestMethod()]
        public void AreaTest_01()
        {

            // arrange
            double a = 1.0;
            double b = 1.0;
            double delta = 0.001;
            var square = new Square((int)a, (int)b);

            // expected
            double expected = a * b;

            // act
            double actual = square.Area();

            // assert
            Assert.AreEqual(expected, actual, delta);
        }
        [TestMethod()]
        public void AreaTest_02()
        {

            // arrange
            double a = 1.0001;
            double b = 1.0003;
            double delta = 0.001;
            var square = new Square((int)a, (int)b);

            // expected
            double expected = a*b;

            // act
            double actual = square.Area();

            // assert
            Assert.AreEqual(expected, actual, delta);
        }
        [TestMethod()]
        public void AreaTest_03()
        {

            // arrange
            double a = 1.9;
            double b = 1.8;
            double delta = 0.001;
            var square = new Square((int)a, (int)b);

            // expected
            double expected = a * b;

            // act
            double actual = square.Area();

            // assert
            Assert.AreEqual(expected, actual, delta);
        }
    }
}