using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Console
{
    class Program
    {

        static void Main(string[] args)
        {
            /*
             * Run this code in the debugger and look at where it
             * goes step-by-step, and what the internal data structures
             * look like after each step.
             * 
             * Remember...console writes go to the DOS prompt.
             * 
            */
            Console.WriteLine("==========================================");
            Console.WriteLine(" object");

            // Create an instance of the class "newclass"
            newclass n = new newclass('A');

            // Java Way...use getter or setter
            Console.WriteLine(" object Ch=" + n.getCh());
            n.setCh('Z');
            Console.WriteLine(" object Ch1=" + n.getCh());
            n.setCh('8');
            Console.WriteLine(" object Ch1=" + n.getCh());

            n.printTheChar();

            // C# way...use Property to access Field
            n.Ch = 'R';
            Console.WriteLine(" object Ch=" + n.Ch);          
            n.Ch = 'S';
            Console.WriteLine(" object Ch=" + n.Ch);

            n.printTheChar();

            Console.WriteLine("==========================================");
            Console.WriteLine("Waiting for you to press enter");
            Console.ReadLine();

        }
    }
}
