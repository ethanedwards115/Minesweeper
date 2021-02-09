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
    }
}
