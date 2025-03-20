using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    public class StationaryObject : myModel
    {
        public StationaryObject(Model m) : base(m)
        {
        }

        public StationaryObject(Model m, Color color) : base(m, color)
        {
        }

        public StationaryObject(Model m, Vector3 pos, Vector3 vel, Color color) : base(m, pos, vel, color)
        {
        }

        public override void Move()
        {
            // Do nothing
        }
    }
}
