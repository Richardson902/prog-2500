using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort_Utest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Utest.Tests
{
    [TestClass()]
    public class TestMeTests
    {
        [TestMethod()]
        public void integer_array_sortTest_01()
        {
            int[] expected_result_array = { 1, 2, 3, 4 };
            TestMe T = new TestMe();
            int[] myInts = { 3, 2, 4, 1 };
            int[] actual_sorted_array = T.integer_array_sort(myInts);

            // print
            foreach (int i in actual_sorted_array)
            {
                Console.WriteLine(i);
            }

            // assert each value
            Assert.AreEqual(actual_sorted_array[0], expected_result_array[0]);
            Assert.AreEqual(actual_sorted_array[1], expected_result_array[1]);
            Assert.AreEqual(actual_sorted_array[2], expected_result_array[2]);
            Assert.AreEqual(actual_sorted_array[3], expected_result_array[3]);

            //Assert.Fail();
        }
        [TestMethod()]
        public void integer_array_sortTest_02()
        {
            int[] expected_result_array = { 1, 2, 3, 4 };
            TestMe T = new TestMe();
            int[] myInts = { 3, 2, 4, 1 };
            int[] actual_sorted_array = T.integer_array_sort(myInts);

            // print
            for (int i = 0; i < actual_sorted_array.Length; i++)
            {
                Console.WriteLine(actual_sorted_array[i]);
            }

            for (int i = 0; i < actual_sorted_array.Length; i++)
            {
                Assert.AreEqual(actual_sorted_array[i], expected_result_array[i]);
            }


        }
        [TestMethod()]
        public void integer_array_sortTest_03()
        {
            int[] expected_result_array = { 1, 2, 3, 4, 5, 6, 7 };
            TestMe T = new TestMe();
            int[] myInts = { 3, 2, 4, 1, 7, 5, 6 };
            int[] actual_sorted_array = T.integer_array_sort(myInts);

            // print
            for (int i = 0; i < actual_sorted_array.Length; i++)
            {
                Console.WriteLine(actual_sorted_array[i]);
            }

            for (int i = 0; i < actual_sorted_array.Length; i++)
            {
                Assert.AreEqual(actual_sorted_array[i], expected_result_array[i]);
            }


        }
        [TestMethod()]
        public void integer_array_sortTest_04()
        {
            int[] expected_result_array = { -3, -2, 1, 2, 3, 4 };
            TestMe T = new TestMe();
            int[] myInts = { 3, 2, 4, 1, -2, -3 };
            int[] actual_sorted_array = T.integer_array_sort(myInts);

            // print
            for (int i = 0; i < actual_sorted_array.Length; i++)
            {
                Console.WriteLine(actual_sorted_array[i]);
            }

            for (int i = 0; i < actual_sorted_array.Length; i++)
            {
                Assert.AreEqual(actual_sorted_array[i], expected_result_array[i]);
            }


        }

        [TestMethod()]
        public void integer_array_sortTest_05()
        {
            int[] expected_result_array = { 1, 2, 3, 4, 99, 100, 101 };
            TestMe T = new TestMe();
            int[] myInts = { 3, 2, 99, 100, 4, 1 };
            int[] actual_sorted_array = T.integer_array_sort(myInts);

            // print
            for (int i = 0; i < actual_sorted_array.Length; i++)
            {
                Console.WriteLine(actual_sorted_array[i]);
            }

            for (int i = 0; i < actual_sorted_array.Length; i++)
            {
                Assert.AreEqual(actual_sorted_array[i], expected_result_array[i]);
            }

        }

        [TestMethod()]
        public void integer_array_sortTest_06()
        {
            int[] expected_result_array = { -99, 0, 0, 0, 1, 2, 3, 4, 99 };
            TestMe T = new TestMe();
            int[] myInts = { 0, -99, 99, 3, 2, 4, 1,0 };
            int[] actual_sorted_array = T.integer_array_sort(myInts);

            // print
            for (int i = 0; i < actual_sorted_array.Length; i++)
            {
                Console.WriteLine(actual_sorted_array[i]);
            }

            for (int i = 0; i < actual_sorted_array.Length; i++)
            {
                Assert.AreEqual(actual_sorted_array[i], expected_result_array[i]);
            }


        }

    }
}