using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Multiplayer.Classes
{
    class Complete_Sudoku_Grid_Generator : TableLayoutPanel
    {

        public Complete_Sudoku_Grid_Generator()
        {
            this.ColumnCount = 3;
            this.RowCount = 3;

            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    this.Controls.Add(new Grid_3x3(column, row), column, row);
                }
            }
        }
    }
}
