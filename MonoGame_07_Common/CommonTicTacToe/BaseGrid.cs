using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CommonTicTacToe
{
    public abstract class BaseGrid
    {
        protected readonly Dictionary<string, myModel> models = new();
        protected readonly int size;
        protected Vector2 currentPosition;
        protected GridValue currentPlayer;
        protected GridValue winner = GridValue.Dot;

        public BaseGrid(int size, GraphicsDeviceManager graphics)
        {
            this.size = size;
            myModel.setupGraphics(graphics);
        }

        public virtual void LoadContent(ContentManager content)
        {
            models["X"] = new myModel(content.Load<Model>("Models\\X"), Color.BlueViolet);
            models["O"] = new myModel(content.Load<Model>("Models\\O"), Color.DarkOrange);
            models["Center"] = new myModel(content.Load<Model>("Models\\Z"), Color.Yellow);
            models["Dot"] = new myModel(content.Load<Model>("Models\\dot"), Color.PaleGreen);
        }

        public virtual void Update(IInputDevice input)
        {
            var movement = input.GetMovementDirection();
            UpdateCursorPosition(movement);

            var depthChange = input.GetDepthChange();
            UpdateDepth(depthChange);

            if (input.IsSelectPressed())
            {
                MakeMove();
            }
        }



        protected abstract void UpdateCursorPosition(Vector2 movement);
        protected abstract void MakeMove();
        protected virtual void UpdateDepth(int depthChange)
        {
            // Default implementation does nothing
        }
        public abstract void Draw(Vector3 cameraPosition, float aspectRatio, Vector3 cameraTarget, Vector3 cameraUpDirection);
        public abstract GridValue CheckWinner();
    }
}
