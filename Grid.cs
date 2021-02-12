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
        public static readonly int EasyWidth = 500;
        public static readonly int MedWidth = 700;
        public static readonly int HardWidth = 900;

        private int x, y;

        private Cell[,] cells;
        private int cols;
        private int rows;
        private int mineCount;
        public int RemainingFlags {get; set;}

        private Minesweeper parent;
        private bool gameOver;

        public Grid(int _cols, int _rows, int _mineCount, int windowWidth, int _x, int _y, Minesweeper _parent)
        {
            cols = _cols;
            rows = _rows;
            mineCount = _mineCount;
            RemainingFlags = _mineCount;

            x = _x;
            y = _y;

            parent = _parent;

            gameOver = false;

            cells = new Cell[cols, rows];

            InitCells(cells, windowWidth/_cols);

            GenerateMines();

            AddCells();
        }

        public static Grid newGrid(string difficulty, Minesweeper _parent)
        {

            Grid g;

            if (difficulty.Equals("easy"))
            {
                g = new Grid(10, 8, 10, EasyWidth, _parent.Width/2 - EasyWidth/2, 100, _parent);
            }
            else if(difficulty.Equals("medium"))
            {
                g = new Grid(18, 14, 40, MedWidth, _parent.Width/2 - MedWidth/2, 100, _parent);
            }
            else if (difficulty.Equals("hard"))
            {
                g = new Grid(24, 20, 99, HardWidth, _parent.Width/2 - HardWidth/2, 100, _parent);
            }
            else
            {
                throw new InvalidOperationException();
            }

            _parent.UpdateFlagCounter(g.GetMineCount());
            return g;
        }

        public Cell[,] GetCells()
        {
            return cells;
        }

        public int GetMineCount()
        {
            return mineCount;
        }

        public Minesweeper GetMainParent()
        {
            return parent;
        }

        public bool IsGameOver()
        {
            return gameOver;
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

        public void AddCells()
        {
            foreach (Cell c in cells)
            {
                c.SetOffset(x, y);
                this.parent.Controls.Add(c.GetControl());
            }  
        }

        public void CheckWinGame()
        {
            int totalFlags = 0;
            int totalRevealed = 0;

            foreach(Cell c in cells)
            {
                if (c.IsFlagged()) totalFlags++;
                if (c.IsRevealed()) totalRevealed++;
            }

            if (totalFlags == mineCount && totalRevealed == (cols * rows) - mineCount && !gameOver)
            {
                // winner!!
                EndGame(true);
            }
        }

        public void EndGame(bool gameWon)
        {
            gameOver = true;
            parent.StopTimer();

            string message;

            if (gameWon)
            {
                message = "You Won";
            }
            else
            {
                message = "You Lost";
            }

            foreach (Cell c in cells)
            {
                if (c.IsMine())
                {
                    c.Reveal();
                }
                else if (c.IsFlagged())
                {
                    c.SetBackColourWhite();
                }
            }
            var playAgain = System.Windows.Forms.MessageBox.Show(message + "\nPlay Again?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.None);

            if (playAgain == DialogResult.No)
            {
                parent.Close();
            }
        }

        public void UpdateFlagCounter()
        {
            parent.UpdateFlagCounter(RemainingFlags);
        }
    }
}
