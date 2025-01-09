using Sort_Utest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Console
{
    class Program
    {

        static void Main(string[] args)
        {
            // 


            Console.WriteLine("==========================================");
            Console.WriteLine("call sort routine");
            TestMe T = new TestMe();
            int[] myInts = { 3, 2, 4, 1 };
            int[] sorted_array = T.integer_array_sort(myInts);
            foreach (int i in sorted_array)
            {
                Console.WriteLine(i);
            }
        


            Console.WriteLine("==========================================");
            Console.WriteLine("Waiting for you to press enter");
            Console.ReadLine();

        }
    }
}
