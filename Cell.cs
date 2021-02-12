using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Minesweeper
{
    class Cell
    {
        private int x, y, w;
        private int col, row;
        private int offsetX, offsetY;

        private bool revealed;
        private bool flagged;
        private bool hasMine;

        private Label revealLabel;

        private Grid parent;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="_x">The top-left x coordinate of this Cell.</param>
        /// <param name="_y">The top-left y coordinate of this Cell.</param>
        /// <param name="_w">The pixel width of this Cell.</param>
        /// <param name="_parent">The parent (Grid) which holds this Cell.</param>
        /// <param name="_col">The column number of this Cell.</param>
        /// <param name="_row">The row number of this Cell.</param>
        public Cell(int _x, int _y, int _w, Grid _parent, int _col, int _row)
        {
            x = _x;
            y = _y;
            w = _w;

            col = _col;
            row = _row;

            revealed = false;
            flagged = false;
            hasMine = false;

            parent = _parent;

            SetOffset(0, 0);
        }

        // Getters

        /// <summary>
        /// Get the top-left x coordinate of this Cell.
        /// </summary>
        /// <returns>top-left x coordinate</returns>
        public int GetX()
        {
            return x;
        }

        /// <summary>
        /// Get the top-left y coordinate of a Cell.
        /// </summary>
        /// <returns>Top-left y coordinate.</returns>
        public int GetY()
        {
            return y;
        }

        /// <summary>
        /// Get the row number of a Cell.
        /// </summary>
        /// <returns>Row number.</returns>
        public int GetRow()
        {
            return row;
        }

        /// <summary>
        /// Get the column number of a Cell.
        /// </summary>
        /// <returns>Column number.</returns>
        public int GetColumn()
        {
            return col;
        }

        /// <summary>
        /// Set the pixel offset of a Cell.
        /// </summary>
        /// <param name="_x">The top-left x coordinate of this offset.</param>
        /// <param name="_y">The top-left y coordinate of this offset.</param>
        public void SetOffset(int _x, int _y)
        {
            offsetX = _x;
            offsetY = _y;

            CreateLabel();
        }

        /// <summary>
        /// Check if a Cell is currently revealed.
        /// </summary>
        /// <returns>true if it is revealed, false otherwise.</returns>
        public bool IsRevealed()
        {
            return revealed;
        }

        /// <summary>
        /// Check if a Cell is currently flagged.
        /// </summary>
        /// <returns>true if it is flagged, false otherwise.</returns>
        public bool IsFlagged()
        {
            return flagged;
        }

        /// <summary>
        /// Check if a Cell contains a Mine.
        /// </summary>
        /// <returns>true if Cell contains a mine, false otherwise.</returns>
        public bool IsMine()
        {
            return hasMine;
        }

        /// <summary>
        /// Get the Control object of a Cell
        /// </summary>
        /// <returns>The Label object associated with a Cell</returns>
        public Label GetControl()
        {
            return revealLabel;
        }

        // Methods

        /// <summary>
        /// Make a Cell contain a Mine
        /// </summary>
        /// <returns>false if the Cell already contains a mine, true otherwise.</returns>
        public bool SetAsMine()
        {
            if (hasMine) return false;

            hasMine = true;
            return true;
        }

        /// <summary>
        /// Create the Label (Control) object associated with a Cell.
        /// </summary>
        private void CreateLabel()
        {
            revealLabel = new Label
            {
                Location = new Point(offsetX + x, offsetY + y),
                Width = w,
                Height = w,

                BorderStyle = BorderStyle.FixedSingle,

                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", w / 2),

                BackColor = Color.PaleTurquoise
            };

            void revealLabel_MouseClick(object sender, MouseEventArgs e)
            {
                // Do nothing if the game is already over.
                if (parent.IsGameOver()) return;

                switch(e.Button)
                {
                    // Left-mouse button starts the timer (if not already started)
                    // and reveals the cell.
                    case MouseButtons.Left:

                        parent.GetMainParent().StartTimer();

                        if (!revealed)
                            this.Reveal();
                    break;

                    // Right-mouse button toggles a flag on the cell.
                    case MouseButtons.Right:

                        if(!revealed)
                            this.ToggleFlag();
                    break;

                }

                // After each MouseClick event, check if the game has been won.
                parent.CheckWinGame();
            }

            // Add this method to the event handler
            revealLabel.MouseClick += revealLabel_MouseClick;
        }

        /// <summary>
        /// Toggles flag placement on the cell (between flagged and not flagged).
        /// </summary>
        public void ToggleFlag()
        {
            if (!flagged)
            {
                revealLabel.Text = "⚐";
                flagged = true;
                parent.RemainingFlags--;
            }
            else
            {
                revealLabel.Text = "";
                flagged = false;
                parent.RemainingFlags++;
            }

            parent.UpdateFlagCounter();
        }

        /// <summary>
        /// Reveal the Cell. If the Cell has no adjacent mines, reveal those Cells also.
        /// </summary>
        public void Reveal()
        {
            if (flagged) return;
            if (revealed) return;

            if (this.IsMine())
            {
                revealLabel.Text = "M";
                if (!parent.IsGameOver())
                {
                    parent.EndGame(false);
                }
                return;
            }

            Cell[,] cells = parent.GetCells();

            revealLabel.BackColor = Color.White;
            revealed = true;

            int surroundingMines = CountMines();

            if(surroundingMines == 0)
            {
                revealLabel.Text = "";

                for (int c = -1; c <= 1; c++)
                {
                    for (int r = -1; r <= 1; r++)
                    {
                        if(!(c == 0 && r == 0))
                        {
                            try
                            {
                                if (Math.Abs(c) == Math.Abs(r) && cells[col + c, row + r].CountMines() == 0)
                                    continue;

                                cells[col + c, row + r].Reveal();
                            }
                            catch (IndexOutOfRangeException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                    }
                }
            }
            else
            {
                revealLabel.Text = Convert.ToString(surroundingMines);
            }

            
        }

        /// <summary>
        /// Count the mines surrounding the Cell.
        /// </summary>
        /// <returns>The number of mines around this Cell.</returns>
        public int CountMines()
        {
            int total = 0;

            Cell[,] cells = parent.GetCells();

            for (int c = -1; c <= 1; c++)
            {
                for (int r = -1; r <= 1; r++)
                {
                    if (!(c == 0 && r == 0))
                    {
                        try
                        {
                            if (cells[col + c, row + r].IsMine())
                            {
                                total++;
                            }
                        }
                        catch(IndexOutOfRangeException e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }
            return total;
        }

        /// <summary>
        /// Set the background colour of the Cell to white.
        /// </summary>
        public void SetBackColourWhite()
        {
            revealLabel.BackColor = Color.White;
        }
    }
}