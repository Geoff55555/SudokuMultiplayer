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
        public int rowCorr = 0;
        public int colCorr = 0;

        public Grid_3x3() { }

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
            //--According to the Grid Tag, calculate the real coordinates of the label (not relative to the grid_3x3 but relative to the grid_9x9)
            switch (Tag)
            {
                case 1:
                    break;
                case 2:
                    colCorr = 3;
                    break;
                case 3:
                    colCorr = 6;
                    break;
                case 4:
                    rowCorr = 3;
                    break;
                case 5:
                    rowCorr = 3;
                    colCorr = 3;
                    break;
                case 6:
                    rowCorr = 3;
                    colCorr = 6;
                    break;
                case 7:
                    rowCorr = 6;
                    break;
                case 8:
                    rowCorr = 6;
                    colCorr = 3;
                    break;
                case 9:
                    rowCorr = 6;
                    colCorr = 6;
                    break;
                default:
                    break;
            }
            //--Add the number label
            for (int row = 0; row < 3; row++) //for each line
            {
                for (int column = 0; column < 3; column++) //fill every case (per column)
                {
                    Sudoku_Numb_Label labelN = new Sudoku_Numb_Label(row + rowCorr, column + colCorr);
                    this.Controls.Add(labelN, column, row); // Attention ! column first and then row
                }
            }
        }

        public void Fill(int[,] Grid_3x3)
        {
            //get all the labels in this grid and place them in a list
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
                    coordinates[0] = row + rowCorr;
                    coordinates[1] = column + colCorr;
                    if (coordinates.SequenceEqual(((int[])labelsList[0].Tag))) //just to check if the simplified references with labelsList works
                    {
                        labelsList[0].Text = Grid_3x3[row, column].ToString();
                        Console.WriteLine("Coordinates [ " + coordinates[0] + " , " + coordinates[1] + " ] of Grid 3x3 nbr " + this.Tag + " filled correctly with " + labelsList[0].Text);
                        labelsList.Remove(labelsList[0]);//so the next label is always in list case #0
                    }
                    else
                    {
                        Console.WriteLine("There has been a problem with Grid 3x3 fill");
                    }
                }
            }
        }
    }
}

