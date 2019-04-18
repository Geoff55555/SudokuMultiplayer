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
        public Grid_3x3(){}

        public Grid_3x3(int labelRow, int labelColumn, int side_length, int tagGridNbr)
        {
            //Set Name
            this.Name = "tableLayoutPanel_Grid_3x3_" + labelRow + "_" + labelColumn; // + i; to do in Sudoku_Grid

            //set tag for future and easier identification
            this.Tag = tagGridNbr;

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
                    this.Controls.Add(labelN, column, row); // Attention ! column first and then row
                }
            }
        }

        public void Fill(int[,] Grid_3x3)
        {
            List<Label> labelsList = new List<Label>();
            foreach (Label numberLabel in this.Controls)
            {
                labelsList.Add(numberLabel);
            }

            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    int[] coordinates = new int[2];
                    coordinates[0] = row;
                    coordinates[1] = column;
                    if (coordinates.SequenceEqual(((int[])labelsList[0].Tag))) //just to check if the simplified references with labelsList works
                    {
                        labelsList[0].Text = Grid_3x3[row, column].ToString();
                        labelsList.Remove(labelsList[0]);
                        Console.WriteLine("Coordinates "+ row +" " + column +" of Grid 3x3 nbr " + this.Tag + " filled correctly");
                    }
                    else
                    {
                        Console.WriteLine("there has been a problem with Grid 3x3 fill");
                    }
                }
            }
        }
    }
}

