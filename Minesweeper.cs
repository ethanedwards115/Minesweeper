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

            void newGameBtnClicked(object sender, MouseEventArgs e)
            {
                StopTimer();

                foreach (Cell c in g.GetCells())
                {
                    this.Controls.Remove(c.GetControl());
                }

                g = Grid.newGrid("medium", this);
            }

            this.NewGameBtn.MouseClick += newGameBtnClicked;
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
