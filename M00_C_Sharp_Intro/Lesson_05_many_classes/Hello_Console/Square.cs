using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Console
{
    public class Square
    {
        // the size of the square
        // These are "fields"
        private int x, y;

        // Define Properties as getter/setters of fields
        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        // constructor...assign using properties
        public Square(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }


        // Compute Area....use properties, but could use fields in this class
        public int Area()
        {
            return x * y;
        }
    }
}
