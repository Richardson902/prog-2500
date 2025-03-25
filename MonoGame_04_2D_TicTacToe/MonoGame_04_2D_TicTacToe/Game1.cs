using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_04_2D_TicTacToe;


/**
* 3D: Place an Image on the Screen using XNA:
* ===========================================
* This sample:
*      - Uses MonoGame programming...used to be xBox/XNA
*      - Shows how 3D mesh shapes are placed on the screen
*      - Too functional, should use more OOP
*      - myModel class isn't bad, but grid should be a class with it's own draw()
*      - note enumerations used to show meaning in variables
*      
*      
**/

public class Game1 : Game
{
    private Grid grid;
    public static GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }


    // Set the position of the camera in world space, for our view matrix.
    Vector3 cameraPosition = new Vector3(0.0f, 350.0f, 350.0f);


    // List of models to draw
    System.Collections.ArrayList Model_list = new System.Collections.ArrayList();


    // Used to detect the B button being pressed
    ButtonState lastUpdateState;
    ButtonState thisUpdateState;

    // The aspect ratio determines how to scale 3d to 2d projection.
    float aspectRatio;


    // each and any spot my be selected
    private Boolean[,] selection = new Boolean[3, 3];

    // current "cursor" in 2D
    private int[] current = new int[2];

    Boolean lastTimeWasNotSpace = false;
    Boolean lastTimeWasNotUp = false;
    Boolean lastTimeWasNotRight = false;


    private myModel[] m = new myModel[4];


    protected override void LoadContent()
    {

        Debug.WriteLine("BasicCameraSample LoadContent");

        _spriteBatch = new SpriteBatch(GraphicsDevice);

        grid = new Grid();

        // Flyweight pattern: create one of each mesh, and reuse
        // these 4 meshes in the grid.  
        // load each mesh one at a time, 4 types of mesh objects
        // All mesh objects displayed, will render from one of these 4
        myModel.setupGraphics(_graphics);
        m[(int)Grid.GridVal.Center] = new myModel(Content.Load<Model>("Models\\Z"), Vector3.Zero, Vector3.Zero, Color.Yellow);
        m[(int)Grid.GridVal.X] = new myModel(Content.Load<Model>("Models\\X"), Vector3.Zero, Vector3.Zero, Color.Yellow);
        m[(int)Grid.GridVal.O] = new myModel(Content.Load<Model>("Models\\O"), Vector3.Zero, Vector3.Zero, Color.Yellow);
        m[(int)Grid.GridVal.Dot] = new myModel(Content.Load<Model>("Models\\dot"), Vector3.Zero, Vector3.Zero, Color.Yellow);

        aspectRatio = (float)_graphics.GraphicsDevice.Viewport.Width /
                        (float)_graphics.GraphicsDevice.Viewport.Height;
    }

    protected override void Update(GameTime gameTime)
    {


        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        //Get Keyboard Keystroke
        KeyboardState k = Keyboard.GetState();

        // Act on the keystroke
        if (k.IsKeyDown(Keys.E))
            this.Exit();                                      // E = Exit Game


        // cameraPosition
        if (k.IsKeyDown(Keys.D1))
        {
            cameraPosition = new Vector3(0.0f, 350.0f, 350.0f);
        }
        if (k.IsKeyDown(Keys.D2))
        {
            cameraPosition = new Vector3(50.0f, 450.0f, 450.0f);
        }
        if (k.IsKeyDown(Keys.D3))
        {
            cameraPosition = new Vector3(100.0f, 250.0f, 250.0f);
        }
        if (k.IsKeyDown(Keys.D4))
        {
            cameraPosition = new Vector3(0.0f, -350.0f, 250.0f);
        }




        if ((k.IsKeyDown(Keys.Up)) && lastTimeWasNotUp)
        {
            grid.CurrentPosition[1] = (grid.CurrentPosition[1] + 1) % 3;
        }

        if ((k.IsKeyDown(Keys.Right)) && lastTimeWasNotRight)
        {
            grid.CurrentPosition[0] = (grid.CurrentPosition[0] + 1) % 3;
        }

        if (k.IsKeyDown(Keys.Space) && lastTimeWasNotSpace)
        {
            grid.ToggleSelection(grid.CurrentPosition[0], grid.CurrentPosition[1]);
            grid.UpdateGridValue(grid.CurrentPosition[0], grid.CurrentPosition[1]);
        }

        lastTimeWasNotUp = !k.IsKeyDown(Keys.Up);
        lastTimeWasNotRight = !k.IsKeyDown(Keys.Right);
        lastTimeWasNotSpace = !k.IsKeyDown(Keys.Space);

        grid.WhoWon = grid.GetWhoWon();

        base.Update(gameTime);
    }



    Vector3 cameraTarget = Vector3.Zero;
    Vector3 cameraUpDirection = Vector3.Up;

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        grid.Draw(m, cameraPosition, aspectRatio, cameraTarget, cameraUpDirection);

        if (grid.WhoWon != Grid.GridVal.Dot)
        {
            Debug.WriteLine("Player " + grid.WhoWon + " won!");
        }

        base.Draw(gameTime);
    }
}

