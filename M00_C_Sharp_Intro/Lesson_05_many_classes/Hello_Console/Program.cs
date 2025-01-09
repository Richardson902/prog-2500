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
            // make some squares and circles
            Square s1 = new Square(10, 20);
            Circle s2 = new Circle(20);
            Square s3 = new Square(6, 70);
            Circle s4 = new Circle(10);

            // get the area of the shapes ... we get objects' property, not field
            Console.WriteLine("S1 X=" + s1.X + "S1 Y=" + s1.Y + " Area s1 =" + s1.Area() + "  " + s1.GetType());
            Console.WriteLine("S2 R=" + s2.R + " Area s2 =" + s2.Area() + "  " + s2.GetType());
            Console.WriteLine("S3 X=" + s3.X + "S3 Y=" + s3.Y + " Area s3 =" + s3.Area() + "  " + s3.GetType());
            Console.WriteLine("S4 X=" + s4.R + " Area s4 =" + s4.Area() + "  " + s4.GetType());

            Console.WriteLine("==========================================");
            Console.WriteLine("Waiting for you to press enter");
            Console.ReadLine();

        }
    }
}
