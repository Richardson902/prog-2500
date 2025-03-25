using System;
using Microsoft.Xna.Framework;

namespace MonoGame_04_2D_TicTacToe
{
    class Grid
    {
        public enum GridVal { X = 0, O = 1, Center = 2, Dot = 3 }

        private GridVal[,] gridValues = new GridVal[3, 3];
        private bool[,] selection = new bool[3, 3];

        public int[] CurrentPosition { get; set; } = new int[2];
        public GridVal WhoWon { get; set; }
        private GridVal[] turn = { GridVal.X, GridVal.O };

        public Grid()
        {
            SetAllGridPos(GridVal.Dot);
            SetAllNotSelected();
        }

        public void SetGridPos(GridVal v, int x, int y)
        {
            gridValues[x, y] = v;
        }

        public void SetAllGridPos(GridVal v)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    SetGridPos(v, i, j);
                }
            }
        }

        public void SetAllNotSelected()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    selection[i, j] = false;
                }
            }
        }

        public void ToggleSelection(int x, int y)
        {
            selection[x, y] = !selection[x, y];
        }

        public void UpdateGridValue(int x, int y)
        {
            int eVal = (int)gridValues[x, y];
            int max_eVal = Enum.GetNames(typeof(GridVal)).Length;
            eVal = (eVal + 1) % max_eVal;
            gridValues[x, y] = (GridVal)eVal;
        }

        public GridVal GetGridValue(int x, int y)
        {
            return gridValues[x, y];
        }

        public bool IsSelected(int x, int y)
        {
            return selection[x, y];
        }

        public GridVal GetWhoWon()
        {
            foreach (var player in turn)
            {
                for (int i = 0; i < 3; i++)
                {
                    // Horizontal
                    if ((gridValues[i, 0] == player) && (gridValues[i, 1] == player) && (gridValues[i, 2] == player))
                    {
                        return player;
                    }

                    // Vertical
                    if ((gridValues[0, i] == player) && (gridValues[1, i] == player) && (gridValues[2, i] == player))
                    {
                        return player;
                    }
                }

                // Diagonals
                if ((gridValues[0, 0] == player) && (gridValues[1, 1] == player) && (gridValues[2, 2] == player))
                {
                    return player;
                }

                if ((gridValues[2, 0] == player) && (gridValues[1, 1] == player) && (gridValues[0, 2] == player))
                {
                    return player;
                }
            }

            return GridVal.Dot;
        }

        public void Draw(myModel[] models, Vector3 cameraPosition, float aspectRatio, Vector3 cameraTarget, Vector3 cameraUpDirection)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    bool won = ((gridValues[i, j] != GridVal.Dot) && (WhoWon == gridValues[i, j]));

                    Vector3 location = new Vector3(
                        i * 100 - 50.0f,
                        j * 100 - 50.0f,
                        0.0f
                    );

                    myModel here = models[(int)gridValues[i, j]];
                    here.pos = location;

                    here.color = Color.PaleGreen;
                    if (gridValues[i, j] == GridVal.X) { here.color = Color.BlueViolet; }
                    if (gridValues[i, j] == GridVal.O) { here.color = Color.DarkOrange; }

                    if ((i == CurrentPosition[0]) && (j == CurrentPosition[1]))
                    {
                        here.color = Color.Red;
                    }

                    here.draw(cameraPosition, aspectRatio, cameraTarget, cameraUpDirection, won);
                }
            }
        }


    }
}
