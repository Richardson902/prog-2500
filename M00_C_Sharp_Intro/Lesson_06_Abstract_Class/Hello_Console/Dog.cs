using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Console
{
    class Dog : Animal
    {
        private const int defaultSpeed = 2;
        private const int maxSpeed = 4;

        public Dog()
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
                // Clamp the speed so we don't go under defauly or over max speed
                speed = ClampSpeed(speed, defaultSpeed, maxSpeed);

                AssignDirection(direction, speed);
            }
        }

        public override void Voice()
        {
            Console.WriteLine("Arf Arf buddy");
        }

        // in move, have defaulty move if 2, and multiply by speed and set max speed, think will need to specify defauly too with consteructor
    }
}
