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
        public int side_length = 540;

        public Complete_Sudoku_Grid_Generator()
        {
            //whole grid style
            this.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.Margin = new System.Windows.Forms.Padding(0);

            this.Size = new System.Drawing.Size(side_length, side_length);
            this.Location = new System.Drawing.Point(0, 0);

            //Columns set
            this.ColumnCount = 3;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));

            //Rows set
            this.RowCount = 3;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));

            //fill with grid_3x3
            int gridNbr = 1;
            for (int row = 0; row < RowCount; row++)
            {
                for (int column = 0; column < ColumnCount; column++)
                {
                    this.Controls.Add(new Grid_3x3(column, row, (side_length - 20) / 3, gridNbr), column, row);
                    gridNbr++;
                }
            }
        }

        public void Fill(int[,] generatedGrid)
        {
            //Control[] allGrids = this.Controls.Find("tableLayoutPanel_Grid_3x3_", true);
            for (int tag = 1; tag <= 9; tag++) //to go through all tags
            {
                foreach (Grid_3x3 grid_3x3 in this.Controls) //go through all grids
                {
                    if (((int)grid_3x3.Tag) == tag) //target only one grid
                    {
                        int[,] reducedTo3x3_Grid = new int[3, 3];
                        switch (tag)//depending on the tag, the little grid to add will be determined
                        {
                            case 1:
                                reducedTo3x3_Grid = reduceGrid(generatedGrid, 0, 0);
                                break;
                            case 2:
                                reducedTo3x3_Grid = reduceGrid(generatedGrid, 0, 3);
                                break;
                            case 3:
                                reducedTo3x3_Grid = reduceGrid(generatedGrid, 0, 6);
                                break;
                            case 4:
                                reducedTo3x3_Grid = reduceGrid(generatedGrid, 3, 0);
                                break;
                            case 5:
                                reducedTo3x3_Grid = reduceGrid(generatedGrid, 3, 3);
                                break;
                            case 6:
                                reducedTo3x3_Grid = reduceGrid(generatedGrid, 3, 6);
                                break;
                            case 7:
                                reducedTo3x3_Grid = reduceGrid(generatedGrid, 6, 0);
                                break;
                            case 8:
                                reducedTo3x3_Grid = reduceGrid(generatedGrid, 6, 3);
                                break;
                            case 9:
                                reducedTo3x3_Grid = reduceGrid(generatedGrid, 6, 6);
                                break;
                        }
                        grid_3x3.Fill(reducedTo3x3_Grid);
                    }
                }
            }
        }

        int[,] reduceGrid(int[,] bigGrid, int firstRow, int firstColumn)
        {
            int[,] reducedGrid = new int[3, 3];
            for (int rowBigG = firstRow; rowBigG < firstRow + 3; rowBigG++)
            {
                for (int columnBigG = firstColumn; columnBigG < firstColumn + 3; columnBigG++)
                {
                    //simplify coordinated in reduced grid
                    int rowReduG = rowBigG - firstRow;
                    int columnReduG = columnBigG - firstColumn;

                    reducedGrid[rowReduG, columnReduG] = bigGrid[rowBigG, columnBigG];
                }
            }
            return reducedGrid;
        }
    }
}
