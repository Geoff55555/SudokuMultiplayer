using System;
using System.Collections.Generic;
using System.Drawing;
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
                    this.Controls.Add(new Grid_3x3(row, column, (side_length - 20) / 3, gridNbr), column, row);// Attention ! column first and then row
                    gridNbr++;
                }
            }
        }

        public void Fill(int[,] generatedGrid)
        {
            //Control[] allGrids = this.Controls.Find("tableLayoutPanel_Grid_3x3_", true);
            List<Grid_3x3> gridList = new List<Grid_3x3>();
            foreach (Grid_3x3 grid_3x3 in this.Controls) //go through all grids
            {
                gridList.Add(grid_3x3);
            }

            for (int tag = 1; tag <= 9; tag++) //to go through all tags
            {
                int[,] reducedTo3x3_Grid = new int[3, 3];
                switch (tag) //depending on the tag (grid number), the part of the whole 9x9 grid to reduce will be determined
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
                        reducedTo3x3_Grid = reduceGrid(generatedGrid, 1, 0);
                        break;
                    case 5:
                        reducedTo3x3_Grid = reduceGrid(generatedGrid, 1, 3);
                        break;
                    case 6:
                        reducedTo3x3_Grid = reduceGrid(generatedGrid, 1, 6);
                        break;
                    case 7:
                        reducedTo3x3_Grid = reduceGrid(generatedGrid, 2, 0);
                        break;
                    case 8:
                        reducedTo3x3_Grid = reduceGrid(generatedGrid, 2, 3);
                        break;
                    case 9:
                        reducedTo3x3_Grid = reduceGrid(generatedGrid, 2, 6);
                        break;
                }
                gridList[tag - 1].Fill(reducedTo3x3_Grid);
            }
        }

        //method that reduces the big 9x9 generated grid into a smaller 3x3 grid
        int[,] reduceGrid(int[,] Grid9x9, int firstRow9x9, int firstColumn9x9)
        {
            int[,] reducedGrid = new int[3, 3];
            for (int rowG9x9 = firstRow9x9; rowG9x9 < firstRow9x9 + 3; rowG9x9++)
            {
                for (int columnG9x9 = firstColumn9x9; columnG9x9 < firstColumn9x9 + 3; columnG9x9++)
                {
                    //simplify coordinated in reduced grid
                    int rowG3x3 = rowG9x9 - firstRow9x9;
                    int columnG3x3 = columnG9x9 - firstColumn9x9;

                    reducedGrid[rowG3x3, columnG3x3] = Grid9x9[rowG9x9, columnG9x9];
                }
            }
            return reducedGrid;
        }
    }
}
