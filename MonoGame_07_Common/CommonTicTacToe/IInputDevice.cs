using Microsoft.Xna.Framework;

namespace CommonTicTacToe
{
    public interface IInputDevice
    {
        Vector2 GetMovementDirection();
        bool IsSelectPressed();
        bool IsExitPressed();
        void Update();
        int GetDepthChange();
    }
}
