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
        public Game_Window()
        {
            InitializeComponent();
            Complete_Sudoku_Grid_Generator grid = new Complete_Sudoku_Grid_Generator();
            this.Controls.Add(grid);

            Sudoku_Grid g = new Sudoku_Grid();
            int[,] generatedGrid = g.grid;
            g.ShowInConsole();
            grid.Fill(generatedGrid);

            //for test purposes
            //this.Controls.Add(new Grid_3x3(3, 3));
            //Grid_3x3 sdGrid = new Grid_3x3(3, 3);
            //sdGrid.Location = new System.Drawing.Point(sdGrid.side_length,0);
            //Controls.Add(sdGrid);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.BackColor = Color.Teal;
        }

    }
}
