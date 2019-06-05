using Sudoku_Multiplayer.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Multiplayer
{
    public partial class Game_Window : Form
    {
        Sudoku_Grid generatedGrid = new Sudoku_Grid();
        Complete_Sudoku_Grid_Generator visualGrid = new Complete_Sudoku_Grid_Generator();

        public Game_Window()
        {
            InitializeComponent();
            this.Controls.Add(visualGrid);

            generatedGrid.ShowInConsole();

            //for test purposes
            //this.Controls.Add(new Grid_3x3(3, 3));
            //Grid_3x3 sdGrid = new Grid_3x3(3, 3);
            //sdGrid.Location = new System.Drawing.Point(sdGrid.side_length,0);
            //Controls.Add(sdGrid);
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            visualGrid.Fill(generatedGrid);
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            visualGrid.HideRandom(3);
        }
    }
}
