using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Minesweeper : Form
    {
        private Label flagCounterLabel;
        Grid g;
        Cell c = new Cell();

        public Minesweeper()
        {
            InitializeComponent();
            
            g = Grid.newGrid("easy",this.Height, 40, 5);

            g.AddCells(this);

            DisplayFlagCounter();

            Console.WriteLine("Done!");
        }

        public void DisplayFlagCounter()
        {
            
            int flagCounter = g.GetMineCount() - c.GetFlagCounter();
            
            flagCounterLabel = new Label();
            
            flagCounterLabel.Location = new Point(600, 39);
            flagCounterLabel.AutoSize = true;

            flagCounterLabel.Font = new Font("Microsoft Sans Serif", 32);

            String flagCounterText = Convert.ToString(flagCounter);
            flagCounterLabel.Text = "⚐: "+flagCounterText;
            this.Controls.Add(flagCounterLabel);
            }

        public void UpdateFlagCounterLabel()
        {
            int flagCounter = g.GetMineCount() - c.GetFlagCounter();
            String flagCounterText = Convert.ToString(flagCounter);
            flagCounterLabel.Text = "⚐: " + flagCounterText;
        }

        private void Minesweeper_MouseEnter(object sender, EventArgs e)
        {
            UpdateFlagCounterLabel();
        }
    }
    }

