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
    public class CircleTests
    {


        [TestMethod()]
        public void AreaTest_01()
        {


            // arrange
            double a = 1.0;
            double delta = 0.001;
            var circle = new Circle((int)a);

            // expected
            double expected = (int) ((int) a * (int)a * Math.PI ) ;

            // act
            double actual = circle.Area();

            // assert
            Assert.AreEqual(expected, actual, delta);

            /////////////////////////////////

            //Assert.Fail();
        }


        [TestMethod()]
        public void AreaTest_02()
        {
            Assert.Fail();
        }


        [TestMethod()]
        public void AreaTest_03()
        {
            Assert.Fail();
        }


        [TestMethod()]
        public void AreaTest_04()
        {
            Assert.Fail();
        }


        [TestMethod()]
        public void AreaTest_05()
        {
            Assert.Fail();
        }




    }
}