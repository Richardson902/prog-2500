using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Console
{
    class newclass
    {
        private Char ch = 'A';
        private int x = 3;
        private int y = 4;


        // Property for interanal field ch
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

        // Java Way: getter
        public char getCh()
        {
            return this.ch;
        }

        // Java Way: setter
        public void setCh(Char ch) { this.ch = ch; }

        // print the character
        public void printTheChar() {
            for (int i = 1; i <= this.y; i++)
            {
                Console.WriteLine("-");
            }

            for (int j = 1; j <= this.x; j++)
            {                    
                Console.Write("-"); 
            }
            Console.WriteLine(this.ch);
        
        }

    }
}
