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

        public Grid_3x3(int labelColumn, int labelRow, int side_length) {
            //Set Name
            this.Name = "tableLayoutPanel_Grid_3x3_" + labelColumn + "_" + labelRow; // + i; to do in Sudoku_Grid

            //Set Style
            this.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.Size = new System.Drawing.Size(side_length, side_length);
            this.Location = new System.Drawing.Point(0, 0);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Margin = new System.Windows.Forms.Padding(0);

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
            //--Add the number label
            for (int row = 0; row < 3; row++) //for each line
            {
                for (int column = 0; column < 3; column++) //fill every case (per column)
                {
                    Sudoku_Numb_Label labelN = new Sudoku_Numb_Label(row, column);
                    this.Controls.Add(labelN, row, column);
                }
            }
        }
    }
}
