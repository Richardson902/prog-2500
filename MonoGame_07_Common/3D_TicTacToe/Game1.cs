using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CommonTicTacToe;


namespace _3D_TicTacToe
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private BaseGrid grid;
        private InputManager inputManager;
        private Camera camera;
        private float aspectRatio;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //_graphics.IsFullScreen = true;

            inputManager = new InputManager();
            grid = new Grid3D(_graphics);
            camera = new Camera(is3D: true);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            grid.LoadContent(Content);
            aspectRatio = (float)GraphicsDevice.Viewport.Width / GraphicsDevice.Viewport.Height;
            myModel.setupGraphics(_graphics);
        }

        protected override void Update(GameTime gameTime)
        {
            inputManager.Update();

            if (inputManager.IsExitPressed())
                Exit();

            grid.Update(inputManager.GetActiveDevice());

            KeyboardState k = Keyboard.GetState();
            if (k.IsKeyDown(Keys.D1)) camera.UpdatePosition(1);
            if (k.IsKeyDown(Keys.D2)) camera.UpdatePosition(2);
            if (k.IsKeyDown(Keys.D3)) camera.UpdatePosition(3);
            if (k.IsKeyDown(Keys.D4)) camera.UpdatePosition(4);
            if (k.IsKeyDown(Keys.D5)) camera.UpdatePosition(5);
            if (k.IsKeyDown(Keys.D6)) camera.UpdatePosition(6);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            grid.Draw(camera.Position, aspectRatio, camera.Target, camera.UpDirection);
            base.Draw(gameTime);
        }
    }
}
