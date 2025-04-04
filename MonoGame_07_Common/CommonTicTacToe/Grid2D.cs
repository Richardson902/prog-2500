using System;
using Microsoft.Xna.Framework;

namespace CommonTicTacToe
{
    public class Grid2D : BaseGrid
    {
        private readonly GridValue[,] cells;

        public Grid2D(GraphicsDeviceManager graphics) : base(3, graphics)
        {
            cells = new GridValue[size, size];
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    cells[x, y] = GridValue.Dot;
        }
        protected override void UpdateCursorPosition(Vector2 movement)
        {
            if (Math.Abs(movement.X) > 0.5f)
                currentPosition.X = (currentPosition.X + Math.Sign(movement.X) + size) % size;
            if (Math.Abs(movement.Y) > 0.5f)
                currentPosition.Y = (currentPosition.Y + Math.Sign(movement.Y) + size) % size;
        }

        protected override void MakeMove()
        {
            var x = (int)currentPosition.X;
            var y = (int)currentPosition.Y;

            if (cells[x, y] == GridValue.Dot)
            {
                cells[x, y] = currentPlayer;
                currentPlayer = currentPlayer == GridValue.X ? GridValue.O : GridValue.X; // Switch player
            }
        }

        public override void Draw(Vector3 cameraPosition, float aspectRatio, Vector3 cameraTarget, Vector3 cameraUpDirection)
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    var position = new Vector3(x * 100 - 50.0f, y * 100 - 50.0f, 0);
                    var gridValue = cells[x, y];
                    var model = models[gridValue.ToString()];
                    model.pos = position;

                    // Set default colors based on grid value
                    switch (gridValue)
                    {
                        case GridValue.X:
                            model.color = Color.BlueViolet;
                            break;
                        case GridValue.O:
                            model.color = Color.DarkOrange;
                            break;
                        case GridValue.Center:
                            model.color = Color.Yellow;
                            break;
                        case GridValue.Dot:
                            model.color = Color.PaleGreen;
                            break;
                    }

                    // Highlight selected position
                    if (x == (int)currentPosition.X && y == (int)currentPosition.Y)
                    {
                        model.color = Color.Red;
                    }

                    model.draw(cameraPosition, aspectRatio, cameraTarget, cameraUpDirection);
                }
            }
        }
        public override GridValue CheckWinner()
        {
            // Check rows
            for (int row = 0; row < size; row++)
            {
                if (cells[row, 0] != GridValue.Dot &&
                    cells[row, 0] == cells[row, 1] &&
                    cells[row, 1] == cells[row, 2])
                    return cells[row, 0];
            }

            // Check columns
            for (int col = 0; col < size; col++)
            {
                if (cells[0, col] != GridValue.Dot &&
                    cells[0, col] == cells[1, col] &&
                    cells[1, col] == cells[2, col])
                    return cells[0, col];
            }

            // Check diagonals
            if (cells[0, 0] != GridValue.Dot &&
                cells[0, 0] == cells[1, 1] &&
                cells[1, 1] == cells[2, 2])
                return cells[0, 0];

            if (cells[0, 2] != GridValue.Dot &&
                cells[0, 2] == cells[1, 1] &&
                cells[1, 1] == cells[2, 0])
                return cells[0, 2];

            return GridValue.Dot;
        }



    }
}
