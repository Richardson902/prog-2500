using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Console
{
    class Program
    {

        static void Main(string[] args)
        {
            // Look in C# Help..."Statement Types" for description and examples
            //   -> if
            //   -> switch
            //   -> do
            //   -> while
            //   -> for
            //
            // This program runs in the console (DOS prompt).  An executable is placed in the "bin" directory
            // when the solution is "built".  Open a console (DOS prompt), navigate to that directory, and
            // type the name of the executable to run it.
            //
            // Practice putting debug breakpoints in different places and look at the change in variables
            // as you step through the code line-by-line.
            //


            Console.WriteLine("==========================================");
            Console.WriteLine("if-else");
            // if-else
            bool flagCheck = true;
            if (flagCheck == true)  // Notice the ==  common mistake to use =
            {
                Console.WriteLine("The flag is set to true.");
            }
            else
            {
                Console.WriteLine("The flag is set to false.");
            }


            Console.WriteLine("==========================================");
            Console.WriteLine("switch-case-default...int");
            // switch-case-default using int
            int caseSwitch = 1;
            switch (caseSwitch)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }


            Console.WriteLine("==========================================");
            Console.WriteLine("switch-case-default...string");
            // switch-case-default using string
            String caseSwitchString = "Russ";
            switch (caseSwitchString)
            {
                case "Bob":
                    Console.WriteLine("Set to Bob");
                    break;
                case "Russ":
                    Console.WriteLine("Set to Russ");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }


            Console.WriteLine("==========================================");
            Console.WriteLine("Do");
            int x = 0;
            do
            {
                Console.WriteLine(x);
                x++;  // increment x
            }
            while (x < 5);


            Console.WriteLine("==========================================");
            Console.WriteLine("for");
            // for(start; do while test is true; do each iteration)
            // use F11 in debug to see which is done when...it's important!!!
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("==========================================");
            Console.WriteLine("while");
            int n = 1;
            while (n < 6)
            {
                Console.WriteLine("Current value of n is {0} ... and that's the truth!", n);
                n++;
            }

            Console.WriteLine("==========================================");
            Console.WriteLine("Waiting for you to press enter");
            Console.ReadLine();

        }
    }
}
