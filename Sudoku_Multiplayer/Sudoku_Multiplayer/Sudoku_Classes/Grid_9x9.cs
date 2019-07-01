using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Multiplayer.Classes
{
    class Grid_9x9 : TableLayoutPanel
    {
        public int side_length = 540; //default value
        Random rdm = new Random();

        public Grid_9x9()
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
            int gridNbr = 1; //grid nbr from 1 to 9
            for (int row = 0; row < RowCount; row++)
            {
                for (int column = 0; column < ColumnCount; column++)
                {
                    this.Controls.Add(new Grid_3x3(row, column, (side_length - 20) / 3, gridNbr), column, row);// Attention ! column first and then row
                    gridNbr++;
                }
            }
        }

        public void ChangeSize(System.Drawing.Size size)
        {
            this.Size = size;
        }

        public List<Sudoku_Label_Nbr> GetAllChilds()
        {
            List<Sudoku_Label_Nbr> allCellsList = new List<Sudoku_Label_Nbr>();
            foreach (Control grid_3x3 in this.Controls)
            {
                if (grid_3x3 is Grid_3x3)
                {
                    foreach (Control label in grid_3x3.Controls)
                    {
                        if (label is Sudoku_Label_Nbr)
                        {
                            allCellsList.Add((Sudoku_Label_Nbr)label);
                        }
                    }
                }
            }
            return allCellsList;
        }

        public void Fill(Sudoku_Nbrs_Gen generatedGrid)
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
                        reducedTo3x3_Grid = generatedGrid.reduceGrid(0, 0);
                        break;
                    case 2:
                        reducedTo3x3_Grid = generatedGrid.reduceGrid(0, 3);
                        break;
                    case 3:
                        reducedTo3x3_Grid = generatedGrid.reduceGrid(0, 6);
                        break;
                    case 4:
                        reducedTo3x3_Grid = generatedGrid.reduceGrid(3, 0);
                        break;
                    case 5:
                        reducedTo3x3_Grid = generatedGrid.reduceGrid(3, 3);
                        break;
                    case 6:
                        reducedTo3x3_Grid = generatedGrid.reduceGrid(3, 6);
                        break;
                    case 7:
                        reducedTo3x3_Grid = generatedGrid.reduceGrid(6, 0);
                        break;
                    case 8:
                        reducedTo3x3_Grid = generatedGrid.reduceGrid(6, 3);
                        break;
                    case 9:
                        reducedTo3x3_Grid = generatedGrid.reduceGrid(6, 6);
                        break;
                }
                gridList[tag - 1].Fill(reducedTo3x3_Grid);
            }
        }

        //Hide method --> Random 2-3 cases hidden in each 3x3 grid
        void hideInGrid3x3_FromList(Control control, List<int> casesToHide)
        {
            //int hiddenCount4ThatGrid = 0;
            foreach (Control LabelControl in control.Controls)
            {
                if (LabelControl is Sudoku_Label_Nbr)
                {
                    if (LabelControl.Text != "" && casesToHide.Contains(int.Parse(LabelControl.Text)))
                    {
                        casesToHide.Remove(int.Parse(LabelControl.Text));
                        LabelControl.Text = "";
                        //so the label is no more filled with the right number
                        ((Sudoku_Label_Nbr)LabelControl).isRight = false;
                        //hiddenCount4ThatGrid += 1;
                        //break; //look directly for the next label
                    }
                    else if (casesToHide.Count == 0)
                    {
                        break;
                    }
                }
            }
            //return hiddenCount4ThatGrid;
        }

        public int HideRandom(int Difficulty)
        {
            int hiddenCount = 0;
            foreach (Control control in this.Controls)
            {
                if (control is Grid_3x3)
                {
                    int hideRdm = rdm.Next(1, Difficulty + 1); //it is [min; max[ !
                    //int hideRdm = 8;
                    //create a list of the numbers to hide randomly
                    List<int> casesToHide = new List<int>();
                    List<int> availableToBeHidden = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    for (int i = 0; i < hideRdm; i++)
                    {
                        int caseToHide = rdm.Next(0, availableToBeHidden.Count);//it is [min; max[ !
                        casesToHide.Add(availableToBeHidden[caseToHide]);
                        availableToBeHidden.Remove(availableToBeHidden[caseToHide]);
                    }
                    //all the cases we want to hide are in the array
                    //Now we'll remove the corresponding labels in the grid
                    hideInGrid3x3_FromList(control, casesToHide);
                }
            }
            return hiddenCount;
        }

        public void KeepDetermined(int[][] tag_NumbersToKeep)
        {
            //int hiddenCount = 0;
            //transformation from nbrs to keep (easier to input) to nbrs to hide
            //--will get all nbrs to hide
            int[][] tag_NumbersToHide = new int[9][];
            //--check every grid
            foreach (Control grid_3x3 in this.Controls)
            {
                //--start from everything to hide
                List<int> fullListTheOnesToHide = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                //--remove the ones to keep in every grid
                if (grid_3x3 is Grid_3x3)
                {
                    //check the entire the line (knowing that the line number = the grid tag-1) of the ones to keep and remove them from the list of the ones to hide (yes, it's a bit messy)
                    for (int IndexOfOneTokeep = 0; IndexOfOneTokeep < tag_NumbersToKeep[(int)grid_3x3.Tag - 1].Length; IndexOfOneTokeep++)
                    {
                        fullListTheOnesToHide.Remove(tag_NumbersToKeep[(int)grid_3x3.Tag - 1][IndexOfOneTokeep]);
                    }
                    //it only remains the ones to hide int fullListTheOnesToHide
                    //hiddenCount += hideInGrid3x3_FromList(grid_3x3, fullListTheOnesToHide, hiddenCount);
                    hideInGrid3x3_FromList(grid_3x3, fullListTheOnesToHide);
                    fullListTheOnesToHide.Clear();
                }
            }
            //return hiddenCount;
        }

        public int HideDetermined(int[][] tag_NumbersToHide)
        {
            int hiddenCount = 0;
            //--check every grid
            foreach (Control control in this.Controls)
            {
                //--start from everything to hide
                List<int> fullListTheOnesToKeep = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                if (control is Grid_3x3)
                {
                    //check all the line (corresponding to grid tag) of the ones to keep and remove them
                    for (int IndexOfOneToHide = 0; IndexOfOneToHide < tag_NumbersToHide[(int)control.Tag - 1].Length; IndexOfOneToHide++)
                    {
                        fullListTheOnesToKeep.Remove(tag_NumbersToHide[(int)control.Tag - 1][IndexOfOneToHide]);
                    }
                    //it only remains the ones to hide int fullListTheOnesToHide
                    hideInGrid3x3_FromList(control, fullListTheOnesToKeep);
                    fullListTheOnesToKeep.Clear();
                }
            }
            return hiddenCount;
        }


    }

    //Test if UNIQUE SOLUTION -->recup en 1 SudokuGrid et écrire une méthode de test dedans --> Semblable au CheckDupliactes mais plus de random, on test tous les nombres des cases vides(établir un max pour que ça prenne pas 5jours)
}

