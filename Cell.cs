using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Cell
    {
        private bool _revealed;
        private int _x;
        private int _y;

        public Cell(int x, int y)
        {
            _x = x;
            _y = y;
            _revealed = false;
        }
    }
}
