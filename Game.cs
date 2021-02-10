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
        { // Right now function is generic, needs to be made to edit the individual button
			cells[col][row].setFlagState(true);
			btn[col][row].Text = "Flag";
    }
}
