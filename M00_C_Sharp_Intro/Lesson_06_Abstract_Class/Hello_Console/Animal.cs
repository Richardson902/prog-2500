using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Console
{
    abstract class Animal
    {
        // Sets default location of 100, 100 and initialize speed variables
        public int X { get; set; } = 100;
        public int Y { get; set; } = 100;
        public int DX { get; set; }
        public int DY { get; set; }

        public abstract void Voice();
        public abstract void Move(String direction = "default", int speed = 0);

        public int GetX() { return this.X; }
        public int GetY() { return this.Y; }

        // Function to clamp the speed based on min/max
        public static int ClampSpeed(int speed, int defaultSpeed, int maxSpeed)
        {
            if (speed < defaultSpeed) return defaultSpeed;
            if (speed > maxSpeed) return maxSpeed;
            return speed;
        }

        // Function to assign the direction the animal moves on the axis based on string input
        public void AssignDirection(string direction, int speed)
        {
            switch (direction.ToLower())
            {
                case "up":
                    Y += speed;
                    break;
                case "down":
                    Y -= speed;
                    break;
                case "right":
                    X += speed;
                    break;
                case "left":
                    X -= speed;
                    break;
                default:
                    X += speed;
                    Y += speed;
                    break;
            }
        }
    }
}
