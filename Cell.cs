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

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public int GetRow()
        {
            return row;
        }

        public int GetColumn()
        {
            return col;
        }

        public void SetOffset(int _x, int _y)
        {
            offsetX = _x;
            offsetY = _y;

            CreateLabel();
        }

        public bool IsRevealed()
        {
            return revealed;
        }

        public bool IsFlagged()
        {
            return flagged;
        }

        public bool IsMine()
        {
            return hasMine;
        }

        public Label GetControl()
        {
            return revealLabel;
        }

        // Methods

        public bool SetAsMine()
        {
            if (hasMine) return false;

            hasMine = true;
            return true;
        }

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
                if (parent.IsGameOver()) return;

                switch(e.Button)
                {
                    case MouseButtons.Left:

                        parent.GetMainParent().StartTimer();

                        if (!revealed)
                            this.Reveal();
                        
                    break;

                    case MouseButtons.Right:

                        if(!revealed)
                            this.ToggleFlag();
                    break;
                }
            }

            revealLabel.MouseClick += revealLabel_MouseClick;
        }

        public void ToggleFlag()
        {
            if (!flagged)
            {
                revealLabel.Text = "⚐";
                flagged = true;
            }
            else
            {
                revealLabel.Text = "";
                flagged = false;
            }
        }

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

            parent.CheckWinGame();
        }

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

        public void SetBackColourWhite()
        {
            revealLabel.BackColor = Color.White;
        }
    }
}