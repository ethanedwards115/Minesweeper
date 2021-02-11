using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Game
{
	public Game()
	{
	}

	MouseEventArgs me = (MouseEventArgs) e;

	void btnEvent_Click(object sender, MouseEventArgs me)
    {
		if(e.button == System.Windows.Forms.MouseButtons.Left)
        {
			// Euans Code here
        }
		else if(e.button == System.Windows.Forms.MouseButtons.Right)
        {
			if (cells[col][row].getFlagState() == false) // If a flag is not placed
            {
				cells[col][row].setFlagState(true);
				btn[col][row].Text = "Flag";
			}
            else // If a flag has already been placed
            {
				cells[col][row].setFlagState(false);
				btn[col][row].Text = "";
			}
    }
}
