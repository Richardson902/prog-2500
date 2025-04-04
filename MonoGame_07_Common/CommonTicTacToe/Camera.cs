using Microsoft.Xna.Framework;

namespace CommonTicTacToe
{
    public class Camera
    {
        private Vector3 position;
        private Vector3 target;
        private Vector3 upDirection;
        private readonly bool is3D;

        public Vector3 Position => position;
        public Vector3 Target => target;
        public Vector3 UpDirection => upDirection;

        public Camera(bool is3D = false)
        {
            this.is3D = is3D;
            Reset();
        }

        public void Reset()
        {
            if (is3D)
            {
                position = new Vector3(-200.0f, 450.0f, 450.0f);
            }
            else
            {
                position = new Vector3(0.0f, 350.0f, 350.0f);
            }

            target = Vector3.Zero;
            upDirection = Vector3.Up;
        }

        public void UpdatePosition(int preset)
        {
            if (is3D)
            {
                switch (preset)
                {
                    case 1:
                        position = new Vector3(-300.0f, 450.0f, 450.0f);
                        break;
                    case 2:
                        position = new Vector3(-200.0f, 450.0f, 450.0f);
                        break;
                    case 3:
                        position = new Vector3(-100.0f, 450.0f, 450.0f);
                        break;
                    case 4:
                        position = new Vector3(0.0f, -450.0f, 450.0f);
                        break;
                    case 5:
                        position = new Vector3(450.0f, 0.0f, 450.0f);
                        break;
                    case 6:
                        position = new Vector3(450.0f, 450.0f, 0.0f);
                        break;
                }
            }
            else
            {
                switch (preset)
                {
                    case 1:
                        position = new Vector3(0.0f, 350.0f, 350.0f);
                        break;
                    case 2:
                        position = new Vector3(350.0f, 0.0f, 350.0f);
                        break;
                    case 3:
                        position = new Vector3(350.0f, 350.0f, 0.0f);
                        break;
                }
            }
        }
    }
}
