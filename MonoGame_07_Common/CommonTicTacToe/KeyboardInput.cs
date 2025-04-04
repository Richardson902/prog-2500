using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CommonTicTacToe
{
    public class KeyboardInput : IInputDevice
    {
        private KeyboardState currentState;
        private KeyboardState previousState;

        public void Update()
        {
            previousState = currentState;
            currentState = Keyboard.GetState();
        }
        public Vector2 GetMovementDirection()
        {
            Vector2 direction = Vector2.Zero;
            if (currentState.IsKeyDown(Keys.Up) && !previousState.IsKeyDown(Keys.Up)) direction.Y += 1;
            if (currentState.IsKeyDown(Keys.Down) && !previousState.IsKeyDown(Keys.Down)) direction.Y -= 1;
            if (currentState.IsKeyDown(Keys.Right) && !previousState.IsKeyDown(Keys.Right)) direction.X += 1;
            if (currentState.IsKeyDown(Keys.Left) && !previousState.IsKeyDown(Keys.Left)) direction.X -= 1;
            return direction;
        }
        public bool IsSelectPressed() =>
            currentState.IsKeyDown(Keys.Space) && !previousState.IsKeyDown(Keys.Space);

        public bool IsExitPressed() =>
            currentState.IsKeyDown(Keys.Escape);

        public int GetDepthChange()
        {
            if (currentState.IsKeyDown(Keys.W) && !previousState.IsKeyDown(Keys.W))
                return 1; // Move up in depth
            if (currentState.IsKeyDown(Keys.S) && !previousState.IsKeyDown(Keys.S))
                return -1; // Move down in depth
            return 0; // No change
        }
    }
}
