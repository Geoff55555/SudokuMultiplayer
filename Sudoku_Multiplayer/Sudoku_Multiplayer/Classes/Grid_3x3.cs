using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Sudoku_Multiplayer.Classes
{
    class Grid_3x3 : TableLayoutPanel
    {
        public int side_length = 333;

        public Grid_3x3(int column, int row) {
            //Set Name
            this.Name = "tableLayoutPanel_Grid_3x3_" + column + "_" + row; // + i; to do in Sudoku_Grid

            //Set Style
            this.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.Size = new System.Drawing.Size(side_length, side_length);
            this.Location = new System.Drawing.Point(0, 0);

            //Columns Set
            this.ColumnCount = 3;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));

            //Rows Set
            this.RowCount = 3;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));

            //Add Controls
            for (int labelRow = 0; labelRow < 3; labelRow++) //for each line
            {
                for (int labelColumn = 0; labelColumn < 3; labelColumn++) //fill every case (per column)
                {
                    Sudoku_Numb_Label labelN = new Sudoku_Numb_Label(labelRow, labelColumn);
                    this.Controls.Add(labelN, labelRow, labelColumn);
                }
            }
        }
    }
}
