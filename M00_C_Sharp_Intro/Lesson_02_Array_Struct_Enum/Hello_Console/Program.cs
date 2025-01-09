using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Console
{
    class Program
    {
        //
        // Step through this code with the debugger and look at the contents
        // of the variables and how they change.
        //
        // Note the the data structures and how they are stored.
        //

        // struct used to contain related variables
        public struct Book
        {
            public decimal price;
            public string title;
            public string author;
        }

        // start enum count at 4
        public enum Days { Sat = 4, Sun, Mon, Tue, Wed, Thu, Fri };

        // struct with enum
        public struct Day_Struct
        {
            public decimal some_num;
            public Days some_day;
        }


        static void Main(string[] args)
        {

            Console.WriteLine("==========================================");
            Console.WriteLine("foreach");
            int[] fibarray = new int[] { 0, 1, 2, 3, 5, 8, 13 };
            foreach (int i in fibarray)
            {
                System.Console.WriteLine(i);
            }


            Console.WriteLine("==========================================");
            Console.WriteLine("Integral Type, conversion and initializing");
            long aLong = 22;
            //int i1 = aLong;       // Error: no implicit conversion from long.
            int i2 = (int)aLong;  // OK: explicit conversion.
            int i3 = new int();   // init to default which is zero
            int i4 = 0;
            Console.WriteLine("i2=" + i2 + "   i3=" + i3 + "   i4=" + i4);


            Console.WriteLine("==========================================");
            Console.WriteLine(" Struct ");
            Book b = new Book();
            b.price = 10.0M;
            b.title = "C# manual";
            b.author = "Russ";
            Console.WriteLine(" author =" + b.author);


            Console.WriteLine("==========================================");
            Console.WriteLine(" Enumeration, remember we started Sat=4 ");
            Days d = Days.Thu;
            Console.WriteLine(" day =" + d.ToString() + "   int=" + (int)d);

            //foreach day in Days 
            foreach (Days i in Enum.GetValues(typeof(Days)))
            {
                Console.WriteLine("Day = " + i + " int=" + (int)i);
            }

            Console.WriteLine("==========================================");
            Console.WriteLine(" String ");
            string a = "happy " + "morning";
            char ch = a[2];  // get a char in the middle of the string
            Console.WriteLine(" a=" + a + "   ch=" + ch);

            // Struct with enum
            Console.WriteLine("==========================================");
            Console.WriteLine(" Struct with Enumeration ");
            Day_Struct ds = new Day_Struct();
            ds.some_num = 67;
            ds.some_day = Days.Sun;
            Console.WriteLine(" ds day =" + ds.some_day + " or " + ds.some_day.ToString() + "   int=" + (int)ds.some_day);

            Console.WriteLine("==========================================");
            Console.WriteLine("Waiting for you to press enter");
            Console.ReadLine();

        }
    }
}
