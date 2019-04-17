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
        }
    }
}
