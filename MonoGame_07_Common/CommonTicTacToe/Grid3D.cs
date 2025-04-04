using System;
using Microsoft.Xna.Framework;

namespace CommonTicTacToe
{
    public class Grid3D : BaseGrid
    {
        private readonly GridValue[,,] cells;
        private int currentDepth;

        public Grid3D(GraphicsDeviceManager graphics) : base(3, graphics)
        {
            cells = new GridValue[size, size, size];
            InitializeGrid();
            currentDepth = 0;
        }

        private void InitializeGrid()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    for (int z = 0; z < size; z++)
                        cells[x, y, z] = GridValue.Dot;

            // Center position is special
            cells[1, 1, 1] = GridValue.Center;
        }

        protected override void UpdateCursorPosition(Vector2 movement)
        {
            if (Math.Abs(movement.X) > 0.5f)
                currentPosition.X = (currentPosition.X + Math.Sign(movement.X) + size) % size;
            if (Math.Abs(movement.Y) > 0.5f)
                currentPosition.Y = (currentPosition.Y + Math.Sign(movement.Y) + size) % size;
        }

        protected override void UpdateDepth(int depthChange)
        {
            if (depthChange != 0)
            {
                currentDepth = (currentDepth + depthChange + size) % size;
            }
        }

        protected override void MakeMove()
        {
            var x = (int)currentPosition.X;
            var y = (int)currentPosition.Y;
            var z = currentDepth;

            if (cells[x, y, z] == GridValue.Dot)
            {
                cells[x, y, z] = currentPlayer;
                currentPlayer = currentPlayer == GridValue.X ? GridValue.O : GridValue.X;
            }
        }

        public override void Draw(Vector3 cameraPosition, float aspectRatio, Vector3 cameraTarget, Vector3 cameraUpDirection)
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    for (int z = 0; z < size; z++)
                    {
                        var position = new Vector3(
                            x * 100 - 100.0f,
                            y * 100 - 100.0f,
                            z * 100 - 100.0f);

                        var gridValue = cells[x, y, z];
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
                        if (x == (int)currentPosition.X && y == (int)currentPosition.Y && z == currentDepth)
                        {
                            model.color = Color.Red;
                        }

                        model.draw(cameraPosition, aspectRatio, cameraTarget, cameraUpDirection);
                    }
                }
            }
        }

        public override GridValue CheckWinner()
        {
            // Check each layer
            for (int z = 0; z < size; z++)
            {
                // Check rows
                for (int x = 0; x < size; x++)
                {
                    if (cells[x, 0, z] != GridValue.Dot &&
                        cells[x, 0, z] == cells[x, 1, z] &&
                        cells[x, 1, z] == cells[x, 2, z])
                        return cells[x, 0, z];
                }

                // Check columns
                for (int y = 0; y < size; y++)
                {
                    if (cells[0, y, z] != GridValue.Dot &&
                        cells[0, y, z] == cells[1, y, z] &&
                        cells[1, y, z] == cells[2, y, z])
                        return cells[0, y, z];
                }

                // Check diagonals
                if (cells[0, 0, z] != GridValue.Dot &&
                    cells[0, 0, z] == cells[1, 1, z] &&
                    cells[1, 1, z] == cells[2, 2, z])
                    return cells[0, 0, z];

                if (cells[2, 0, z] != GridValue.Dot &&
                    cells[2, 0, z] == cells[1, 1, z] &&
                    cells[1, 1, z] == cells[0, 2, z])
                    return cells[2, 0, z];
            }

            // Check vertical lines
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (cells[x, y, 0] != GridValue.Dot &&
                        cells[x, y, 0] == cells[x, y, 1] &&
                        cells[x, y, 1] == cells[x, y, 2])
                        return cells[x, y, 0];
                }
            }

            // Check 3D diagonals
            if (cells[0, 0, 0] != GridValue.Dot &&
                cells[0, 0, 0] == cells[1, 1, 1] &&
                cells[1, 1, 1] == cells[2, 2, 2])
                return cells[0, 0, 0];

            if (cells[2, 0, 0] != GridValue.Dot &&
                cells[2, 0, 0] == cells[1, 1, 1] &&
                cells[1, 1, 1] == cells[0, 2, 2])
                return cells[2, 0, 0];

            return GridValue.Dot;
        }
    }
}