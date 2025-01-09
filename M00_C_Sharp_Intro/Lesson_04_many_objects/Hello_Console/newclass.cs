using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Console
{
    class newclass
    {
        private Char ch = 'A';

        // Getter and Setter for ch
        public Char Ch
        {
            get { return ch; }
            set { ch = value; }
        }

        // Constructor no parameters
        public newclass()
        {
            ch = 'Y';
        }

        // Constructor one parameters
        public newclass(Char ch)
        {
            this.ch = ch;
        }

        // Get the character
        public char getTheChar()
        {
            return this.ch;
        }

        // Set the character
        public void setTheChar(Char ch) { this.ch = ch; }

    }
}
