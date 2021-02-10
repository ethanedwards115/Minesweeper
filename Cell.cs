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
        private int minesAroundCell;
        private bool flagState;

        public Cell(int _x, int _y)
        {
            x = _x;
            y = _y;
            revealed = false;
            hasMine = false;
            minesAroundCell = 0;
            flagState = false;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public bool IsRevealed()
        {
            return revealed;
        }

        public bool IsMine()
        {
            return hasMine;
        }

        public int GetMinesAroundCell()
        {
            return minesAroundCell;
        }

        public bool GetFlagState()
        {
            return flagState;
        }

        public void setFlagState(bool flagState)
        {
            this.flagState = flagState;
        }
    }
}
