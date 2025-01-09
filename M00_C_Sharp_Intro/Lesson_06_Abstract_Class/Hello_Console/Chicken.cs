using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Console
{
    class Chicken : Animal
    {
        private const int defaultSpeed = 1;
        private const int maxSpeed = 3;

        public Chicken()
        {
            DX = defaultSpeed;
            DY = defaultSpeed;
        }

        public override void Move(string direction = "default", int speed = 0)
        {
            if (direction == "default")
            {
                X += defaultSpeed;
                Y += defaultSpeed;
            }
            else
            {
                speed = ClampSpeed(speed, defaultSpeed, maxSpeed);

                AssignDirection(direction, speed);
            }
        }

        public override void Voice()
        {
            Console.WriteLine("Buk Buk! *lays egg while maintaining eye contact*");
        }
    }
}
