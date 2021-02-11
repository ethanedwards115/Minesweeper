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
            displayTime.Text = timeElapsed.ToString();
        }

        public void StopTimer()
        {
            if (timer.Enabled)
            {
                this.timer.Stop();
                this.timer.Enabled = false;
                timeElapsed = TimeSpan.Zero;
                displayTime.Text = "00:00.000";
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
    }
}
