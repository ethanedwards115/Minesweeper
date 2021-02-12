using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Minesweeper
{
    public partial class Minesweeper : Form
    {
        Grid g;

        DateTime startTime;
        TimeSpan timeElapsed;

        public Minesweeper()
        {
            InitializeComponent();

            g = Grid.newGrid("medium", this);

            void EasyStartBtnClicked(object sender, MouseEventArgs e)
            {
                bool newGame = StartNewGame();
                if (newGame)
                {
                    g = Grid.newGrid("easy", this);
                }
            }

            void MediumStartBtnClicked(object sender, MouseEventArgs e)
            {
                bool newGame = StartNewGame();
                if (newGame)
                {
                    g = Grid.newGrid("medium", this);
                }
            }

            void HardStartBtnClicked(object sender, MouseEventArgs e)
            {
                bool newGame = StartNewGame();
                if (newGame)
                {
                    g = Grid.newGrid("hard", this);
                }
            }

            this.EasyStartBtn.MouseClick += EasyStartBtnClicked;
            this.MediumStartBtn.MouseClick += MediumStartBtnClicked;
            this.HardStartBtn.MouseClick += HardStartBtnClicked;

            timer.Interval = 1;
            UpdateFlagCounter(g.GetMineCount());
        }

        public bool StartNewGame()
        {
            var newGame = System.Windows.Forms.MessageBox.Show("Are you sure you want to start a new game?", "New Game", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (newGame == DialogResult.Yes)
            {
                StopTimer();
                foreach (Cell c in g.GetCells())
                {
                    this.Controls.Remove(c.GetControl());
                }
                return true;
            }
            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeElapsed = DateTime.Now - startTime;
            displayTimeLabel.Text = timeElapsed.ToString(@"hh\:mm\:ss\.fff");
        }

        public void StopTimer()
        {
            if (timer.Enabled)
            {
                this.timer.Stop();
                this.timer.Enabled = false;
                timeElapsed = TimeSpan.Zero;
                displayTimeLabel.Text = "00:00.000";
            }
        }

        public void StartTimer()
        {
            if (!timer.Enabled && !g.IsGameOver())
            {
                this.timer.Enabled = true;
                this.startTime = DateTime.Now;
                this.timer.Start();
            }
        }

        private void HelpBtn_Click(object sender, EventArgs e)
        {
            string message = "Left-click cells to reveal them.\nIf the cell is a mine, you lose.\nIf the cell is next to a number of mines, it will display how many mines are around it.\nRight-clicking on a cell will place a flag. Use flags to keep track of potential mines.\nTo win, reveal all of the non-mine cells, and flag all of the cells with mines.\nStart a new game by clicking one of the difficulty options on the left.";

            System.Windows.Forms.MessageBox.Show(message, "New Game", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        public void UpdateFlagCounter(int newFlagCount)
        {
            if (newFlagCount >= 0)
            {
                flagCounterLabel.ForeColor = Color.Black;
            }
            else
            {
                flagCounterLabel.ForeColor = Color.IndianRed;
            }

            flagCounterLabel.Text = "Remaining flags: " + Convert.ToString(newFlagCount);
        }
    }
}
