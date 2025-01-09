using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Console
{
    class Program
    {
        /*
        * Run this code in the debugger and look at where it
        * goes step-by-step, and what the internal data structures
        * look like after each step.
        * 
        * Remember...console writes go to the DOS prompt.
        * 
        */


        static void Main(string[] args)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine(" object");

            // Create an instance of the class "newclass"
            newclass n1 = new newclass('R');
            newclass n2 = new newclass('U');
            newclass n3 = new newclass('S');
            newclass n4 = new newclass('S');

            char a = n1.Ch;    // what code did this execute?

            Console.WriteLine(" object n1=" + n1.Ch);
            Console.WriteLine(" object n2=" + n2.Ch);
            Console.WriteLine(" object n3=" + n3.Ch);
            Console.WriteLine(" object n4=" + n4.Ch);

            Console.WriteLine("==========================================");
            Console.WriteLine("Waiting for you to press enter");
            Console.ReadLine();

        }
    }
}
