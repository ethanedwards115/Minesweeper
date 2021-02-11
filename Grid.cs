using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{

    // 10x8 = easy, 10 mines
    // 18x14 = medium, 40 mines
    // 24x20 = hard, 99 mines

    class Grid
    {
        private int x, y;

        private Cell[,] cells;
        private int cols;
        private int rows;
        private int mineCount;

        public Grid(int _cols, int _rows, int _mineCount, int windowWidth, int _x, int _y)
        {
            cols = _cols;
            rows = _rows;
            mineCount = _mineCount;

            x = _x;
            y = _y;

            cells = new Cell[cols, rows];

            InitCells(cells, windowWidth/_cols);

            GenerateMines();
        }

        public static Grid newGrid(string difficulty, int windowWidth, int _x, int _y)
        {
            if (difficulty.Equals("easy"))
            {
                return new Grid(10, 8, 10, windowWidth, _x, _y);
            }
            else if(difficulty.Equals("medium"))
            {
                return new Grid(18, 14, 40, windowWidth, _x, _y);
            }
            else if (difficulty.Equals("hard"))
            {
                return new Grid(24, 20, 99, windowWidth, _x, _y);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public Cell[,] GetCells()
        {
            return cells;
        }

        private void InitCells(Cell[,] cells, int w)
        {
            for (int c = 0; c < cols; c++)
            {
                for (int r = 0; r < rows; r++)
                {
                    cells[c, r] = new Cell(c * w, r * w, w, this, c, r);
                }
            }
        }

        public void GenerateMines()
        {
            Random rng = new Random();
            int _rx, _ry;

            for (int i = 0; i < mineCount; i++)
            {
                _rx = rng.Next() % cols;
                _ry = rng.Next() % rows;

                Cell current = cells[_rx, _ry];
                
                if (!current.SetAsMine())
                {
                    i--;
                    continue;
                }
            }
        }

        public int CountTotalMines()
        {
            int total = 0;

            foreach (Cell c in cells)
            {
                if (c.IsMine()) total++;
            }

            return total;
        }

        public void AddCells(Form parent)
        {
            foreach (Cell c in cells)
            {
                c.SetOffset(x, y);
                parent.Controls.Add(c.GetRevealLabel());
            }  
        }
    }
}
