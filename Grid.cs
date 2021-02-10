using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Grid
    {
        private Cell[,] cells;
        private int width;
        private int height;
        private int mineCount;

        public Grid(int _w, int _h, int _mineCount)
        {
            width = _w;
            height = _h;
            mineCount = _mineCount;

            cells = new Cell[width, height];

            InitCells(cells);
        }

        private void InitCells(Cell[,] cells)
        {
            for (int col = 0; col < width; col++)
            {
                for (int row = 0; row < height; row++)
                {
                    cells[col, row] = new Cell(col, row);
                }
            }
        }

        public void ActivateCell(int col, int row)
        {
            if (cells[col, row].IsMine())
            {
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (cells[i, j].IsMine())
                        {
                            //display mine image on button
                        }
                    }
                }
                Console.Write("Game Over");
            }
            else
            {
                CountAdjacentMines(col, row);
            }
        }

        public void CountAdjacentMines(int col, int row)
        {
            int adjacentMines = 0;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (!(x == 0 && y == 0))
                    {
                        try
                        {
                            Cell currentCell = cells[col + x, row + y];
                            if (currentCell.IsMine())
                            {
                                adjacentMines++;
                            }
                        }
                        catch (IndexOutOfRangeException e)
                        {

                        }
                    }
                }
            }
            cells[col, row].SetMinesAroundCell(adjacentMines);
        }
    }
}
