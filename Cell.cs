using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Cell
    {
        private int x;
        private int y;
        private bool revealed;
        private bool hasMine;
        private int mineCount;

        public Cell(int _x, int _y)
        {
            x = _x;
            y = _y;
            revealed = false;
            hasMine = false;
            mineCount = 0;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public bool isRevealed()
        {
            return revealed;
        }

        public bool isMine()
        {
            return hasMine;
        }
    }
}
