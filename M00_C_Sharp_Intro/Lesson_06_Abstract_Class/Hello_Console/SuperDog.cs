using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Console
{
    class SuperDog : Animal
    {
        private const int defaultSpeed = 10;
        // No max speed because he's a super dog who can fly

        public SuperDog()
        {
            DX = defaultSpeed;
            DY = defaultSpeed;
        }

        public override void Move(string direction = "default", int speed = 0)
        {
            if (direction == "default" && speed == 0)
            {
                X += DX;
                Y += DY;
            }
            else
            {
                if (speed <= 10) { speed = defaultSpeed; }
                AssignDirection(direction, speed);
            }
        }

        public override void Voice()
        {
            Console.WriteLine("I'm Krypto! Not to be confused with Kryptonite, that will kill me.");
        }
    }
}
