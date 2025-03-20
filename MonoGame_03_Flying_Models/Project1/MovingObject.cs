using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{

    public class MovingObject : myModel
    {
        private float boundaryX = 200f;
        private float boundaryY = 200f;
        private float boundaryZ = 200f;

        public MovingObject(Model m) : base(m)
        {
        }

        public MovingObject(Model m, Color color) : base(m, color)
        {
        }

        public MovingObject(Model m, Vector3 pos, Vector3 vel, Color color) : base(m, pos, vel, color)
        {
        }

        public void SetSpeed(float x, float y, float z)
        {
            vel = new Vector3(x, y, z);
        }

        public void SetSpeedX(float x)
        {
            vel.X = x;
        }

        public void SetSpeedY(float y)
        {
            vel.Y = y;
        }

        public void SetSpeedZ(float z)
        {
            vel.Z = z;
        }

        public void SetRotationVelocity(float x, float y, float z)
        {
            rot_vel = new Vector3(x, y, z);
        }

        public void SetRotationVelocityX(float x)
        {
            rot_vel.X = x;
        }

        public void SetRotationVelocityY(float y)
        {
            rot_vel.Y = y;
        }

        public void SetRotationVelocityZ(float z)
        {
            rot_vel.Z = z;
        }

        public void SetBoundary(float x, float y, float z)
        {
            boundaryX = x;
            boundaryY = y;
            boundaryZ = z;
        }



        public override void Move()
        {
            pos += vel;
            rot += rot_vel;

            if (Math.Abs(pos.X) > boundaryX)
            {
                vel.X *= -1;
                pos.X = Math.Sign(pos.X) * boundaryX;
            }

            if (Math.Abs(pos.Y) > boundaryY)
            {
                vel.Y *= -1;
                pos.Y = Math.Sign(pos.Y) * boundaryY;
            }  

            if (Math.Abs(pos.Z) > boundaryZ)
            {
                vel.Z *= -1;
                pos.Z = Math.Sign(pos.Z) * boundaryZ;
            }
        }
    }
}
