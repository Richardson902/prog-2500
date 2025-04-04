using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Linq;

namespace CommonTicTacToe
{
    public class InputManager
    {
        private readonly List<IInputDevice> inputDevices = [];
        private readonly KeyboardInput keyboardFallback;
        private IInputDevice activeDevice;

        public InputManager()
        {
            keyboardFallback = new KeyboardInput();
            inputDevices.Add(keyboardFallback);
            activeDevice = keyboardFallback;

            if (GamePad.GetState(PlayerIndex.One).IsConnected)
            {
                var gamepad = new GamePadInput(PlayerIndex.One);
                inputDevices.Add(gamepad);
            }
                
            if (GamePad.GetState(PlayerIndex.Two).IsConnected)
            {
                var gamepad = new GamePadInput(PlayerIndex.Two);
                inputDevices.Add(gamepad);
            }
        }

        public void Update()
        {
            foreach (var device in inputDevices)
            {
                device.Update();

                if (HasInput(device))
                {
                    activeDevice = device;
                }
            }
        }

        private bool HasInput(IInputDevice device)
        {
            return device.GetMovementDirection() != Vector2.Zero ||
                   device.IsSelectPressed() ||
                   device.IsExitPressed();
        }

        public IInputDevice GetActiveDevice()
        {
            return activeDevice;
        }

        public Vector2 GetMovementDirection()
        {
            foreach (var device in inputDevices)
            {
                var direction = device.GetMovementDirection();
                if (direction != Vector2.Zero)
                    return direction;
            }
            return Vector2.Zero;
        }

        public bool IsSelectPressed()
        {
            return inputDevices.Any(device => device.IsSelectPressed());
        }

        public bool IsExitPressed()
        {
            return inputDevices.Any(device => device.IsExitPressed());
        }
    }
}
