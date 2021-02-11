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
        public Minesweeper()
        {
            InitializeComponent();

            Grid g = new Grid(30, 40, 5);

            Console.WriteLine("Done!");
        }
    }
}
