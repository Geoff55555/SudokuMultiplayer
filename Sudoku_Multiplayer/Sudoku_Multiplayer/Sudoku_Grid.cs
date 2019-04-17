using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sudoku_Multiplayer.Classes;

namespace Sudoku_Multiplayer
{
    class Sudoku_Grid : TableLayoutPanel
    {
        public int[,] grid = new int[9,9];

        public Sudoku_Grid()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    grid[row, column] = row+column;
                }
            }
        }
    }
}
