using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CommonTicTacToe
{
    public class GamePadInput : IInputDevice
    {
        private readonly PlayerIndex playerIndex;
        private GamePadState currentState;
        private GamePadState previousState;

        public GamePadInput(PlayerIndex playerIndex)
        {
            this.playerIndex = playerIndex;
        }

        public void Update()
        {
            previousState = currentState;
            currentState = GamePad.GetState(playerIndex);
        }

        public Vector2 GetMovementDirection()
        {
            Vector2 direction = Vector2.Zero;

            if (currentState.DPad.Up == ButtonState.Pressed && previousState.DPad.Up == ButtonState.Released)
                direction.Y += 1;
            if (currentState.DPad.Down == ButtonState.Pressed && previousState.DPad.Down == ButtonState.Released)
                direction.Y -= 1;
            if (currentState.DPad.Right == ButtonState.Pressed && previousState.DPad.Right == ButtonState.Released)
                direction.X += 1;
            if (currentState.DPad.Left == ButtonState.Pressed && previousState.DPad.Left == ButtonState.Released)
                direction.X -= 1;

            return direction;
        }

        public bool IsSelectPressed()
        {
            return currentState.Buttons.A == ButtonState.Pressed && previousState.Buttons.A != ButtonState.Pressed;
        }

        public bool IsExitPressed()
        {
            return currentState.Buttons.Back == ButtonState.Pressed;
        }

        public int GetDepthChange()
        {
            if (currentState.Buttons.RightShoulder == ButtonState.Pressed && previousState.Buttons.RightShoulder == ButtonState.Released)
                return 1; // Move up in depth
            if (currentState.Buttons.LeftShoulder == ButtonState.Pressed && previousState.Buttons.LeftShoulder == ButtonState.Released)
                return -1; // Move down in depth
            return 0; // No change
        }
    }
}
