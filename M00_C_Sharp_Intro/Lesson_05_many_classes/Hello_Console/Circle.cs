using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Console
{
    public class Circle
    {
        // the size of the circle's radius
        private int _r;

        // C# Encapsulates using Accessors
        public int R
        {
            get
            {
                return _r;
            }

            set
            {
                _r = value;
            }
        }


        // constructor
        public Circle(int _r)
        {
            this._r = _r;
        }

        // Local methods could use _r or R, but other classes must use R
        public int Area()
        {
            // use float inside paren, but convert to int afterwards
            return (int)(3.1415 * (float)R * (float)R);  // area of circle
        }
    }

}
