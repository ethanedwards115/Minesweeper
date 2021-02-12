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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_cols">Number of columns.</param>
        /// <param name="_rows">Number of rows.</param>
        /// <param name="_mineCount">Number of mines.</param>
        /// <param name="windowWidth">Width of the display (in pixels).</param>
        /// <param name="_x">Top-left X position of the Grid.</param>
        /// <param name="_y">Top-left Y position of the Grid.</param>
        /// <param name="_parent"></param>
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

        /// <summary>
        /// Creates a new Grid based on the difficulty provided.
        /// </summary>
        /// <param name="difficulty">"easy", "medium" or "hard".</param>
        /// <param name="_parent">The parent of the grid</param>
        /// <returns>A new Grid object.</returns>
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

            // update the flag counter when a new game starts so it displays correctly
            _parent.UpdateFlagCounter(g.GetMineCount());
            return g;
        }

        /// <summary>
        /// Get the 2D Cell array held by this Grid object.
        /// </summary>
        /// <returns>2D Cell array.</returns>
        public Cell[,] GetCells()
        {
            return cells;
        }

        /// <summary>
        /// Get the number of mines currently on the Grid.
        /// </summary>
        /// <returns>Number of mines on the Grid</returns>
        public int GetMineCount()
        {
            return mineCount;
        }

        /// <summary>
        /// Get the main parent of this Grid
        /// </summary>
        /// <returns>Minesweeper parent object</returns>
        public Minesweeper GetMainParent()
        {
            return parent;
        }

        /// <summary>
        /// Check if the game is over or not.
        /// </summary>
        /// <returns>True if the game is over, false otherwise.</returns>
        public bool IsGameOver()
        {
            return gameOver;
        }

        /// <summary>
        /// Initialise the Cell objects required by the Grid object.
        /// </summary>
        /// <param name="cells">The 2D array holding all the Cells</param>
        /// <param name="w">The pixel width of each Cell</param>
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

        /// <summary>
        /// Randomly generates mines to be placed on the grid.
        /// </summary>
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

        /// <summary>
        /// Display all Cell objects on the main parent.
        /// </summary>
        public void AddCells()
        {
            foreach (Cell c in cells)
            {
                c.SetOffset(x, y);
                this.parent.Controls.Add(c.GetControl());
            }  
        }

        /// <summary>
        /// Handles game victory conditions after each mouse event on a cell.
        /// </summary>
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

        /// <summary>
        /// Handles the end-game dialog based on victory.
        /// </summary>
        /// <param name="gameWon">true if won, false otherwise.</param>
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
