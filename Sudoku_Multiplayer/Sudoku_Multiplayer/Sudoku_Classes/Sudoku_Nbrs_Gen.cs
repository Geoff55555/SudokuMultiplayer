using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sudoku_Multiplayer.Classes;

namespace Sudoku_Multiplayer
{
    [Serializable]
    class Sudoku_Nbrs_Gen
    {
        public int[,] fullGrid = new int[9, 9];
        public int[][] NumbersToKeep = new int[9][];
        public int keepCount = 0;
        public int hiddenCount = 0;

        Random rdm = new Random();
        List<int> availableRowList = new List<int>();
        IEnumerable<int> staticFullList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int newRdm = 0;
        private int stuck;

        private DateTime DateTime;

        public Sudoku_Nbrs_Gen(bool createGrid)
        {
            if (createGrid)
            {
                DateTime = DateTime.Now;
                //for the 8 first rows
                for (int row = 0; row < 8; row++)
                {
                    availableRowList.AddRange(staticFullList);
                    for (int column = 0; column < 9; column++)
                    {
                        try
                        {
                            if (DateTime.Now <= DateTime.AddSeconds(15)) //if within 15sec OK, else restart from 0
                            {
                                addRandomNumber(row, column);
                            }
                            else
                            {
                                fullGrid = new int[9, 9];
                                row = 0;
                                column = -1;
                                availableRowList.Clear();
                                availableRowList.AddRange(staticFullList);//re-add in available row list 
                                DateTime = DateTime.Now;
                            }
                        }
                        catch (DuplicateException)
                        {
                            stuck++;
                            if (stuck >= 5 || column == 8) //really stuck, need to restart that row
                            {
                                for (int i = 0; i < 9; i++)
                                {
                                    fullGrid[row, i] = 0;
                                }
                                column = -1;
                                availableRowList.Clear();
                                availableRowList.AddRange(staticFullList);//re-add in available row list 
                                Console.WriteLine("Stuck with this line, I restart it.");
                            }
                            else if (stuck < 5)
                            {
                                fullGrid[row, column] = 0;
                                column--;
                            }
                        }
                    }
                }

                //fill the last (determined) row
                for (int column = 0; column < 9; column++)
                {
                    int lastNumberPossible = detLastNumberInColumn(column);
                    fullGrid[8, column] = lastNumberPossible;
                    Console.WriteLine("The grid is fully generated with numbers");
                }
            }
            else
            {
                Console.WriteLine("The grid created and waiting for numbers (fill with file)");
            }
        }

        private int detLastNumberInColumn(int column)
        {
            List<int> numberListInTheColumn = new List<int>();
            numberListInTheColumn.AddRange(staticFullList);
            for (int row = 0; row < 8; row++)
            {
                numberListInTheColumn.Remove(fullGrid[row, column]);
            }
            int lastInTheList = numberListInTheColumn[0];
            return lastInTheList;
        }

        private void addRandomNumber(int row, int column)
        {
            newRdm = rdm.Next(0, 9); //it is [min; max[ !
            while (newRdm > (8 - column))//random number using the INDICE of the list to get only remaining available numbers for that row :D
            {
                newRdm = rdm.Next(0, 9);//it is [min; max[ !
            }
            fullGrid[row, column] = availableRowList[newRdm];
            CheckForDuplicates(row, column);
            //success
            availableRowList.Remove(availableRowList[newRdm]);
            stuck = 0;
        }

        public void CheckForDuplicates(int row, int column)
        {
            //in whole row
            for (int columnTest = 0; columnTest < 9; columnTest++)
            {
                if (column != columnTest && this.fullGrid[row, column] == this.fullGrid[row, columnTest])
                {
                    throw new DuplicateException(row, columnTest);
                }
            }

            //in whole column
            for (int rowTest = 0; rowTest < 9; rowTest++)
            {
                if (row != rowTest && this.fullGrid[row, column] == this.fullGrid[rowTest, column])
                {
                    throw new DuplicateException(rowTest, column);
                }
            }

            //in whole sub grid
            int[,] subGrid = new int[3, 3];
            subGrid = reduceGrid(row, column);

            for (int rowTest = 0; rowTest < 3; rowTest++)
            {
                for (int columnTest = 0; columnTest < 3; columnTest++)
                {
                    int rowTest9x9 = rowTest + seekFirst_RowOrCol_ofSubGrid(row, "Row");
                    int columnTest9x9 = columnTest + seekFirst_RowOrCol_ofSubGrid(column, "Column");

                    if (row != rowTest9x9 && column != columnTest9x9 && fullGrid[row, column] == subGrid[rowTest, columnTest])
                    {
                        int rowOfDuplicate = rowTest9x9;
                        int columnOfDuplicate = columnTest9x9;
                        throw new DuplicateException(rowOfDuplicate, columnOfDuplicate);
                    }
                }
            }
        }

        //method that reduces the big 9x9 generated grid into a smaller 3x3 grid
        public int[,] reduceGrid(int caseRow, int caseColumn)
        {
            int firstRow9x9 = seekFirst_RowOrCol_ofSubGrid(caseRow, "Row");
            int firstColumn9x9 = seekFirst_RowOrCol_ofSubGrid(caseColumn, "Column");

            int[,] reducedGrid = new int[3, 3];
            for (int rowG9x9 = firstRow9x9; rowG9x9 < firstRow9x9 + 3; rowG9x9++)
            {
                for (int columnG9x9 = firstColumn9x9; columnG9x9 < firstColumn9x9 + 3; columnG9x9++)
                {
                    //simplify coordinated in reduced grid
                    int rowG3x3 = rowG9x9 - firstRow9x9;
                    int columnG3x3 = columnG9x9 - firstColumn9x9;

                    reducedGrid[rowG3x3, columnG3x3] = this.fullGrid[rowG9x9, columnG9x9];
                }
            }
            return reducedGrid;
        }

        private int seekFirst_RowOrCol_ofSubGrid(int RowOrColumn, string ColumnOrRow)
        {
            int firstIn9x9;
            if (RowOrColumn >= 0 && RowOrColumn < 3)
            {
                firstIn9x9 = 0;
            }
            else if (RowOrColumn >= 3 && RowOrColumn < 6)
            {
                firstIn9x9 = 3;

            }
            else if (RowOrColumn >= 6 && RowOrColumn < 9)
            {
                firstIn9x9 = 6;
            }
            else
            {
                throw new Exception(ColumnOrRow + " is Out of Range");
            }
            return firstIn9x9;
        }

        public void ShowInConsole()
        {
            for (int r = 0; r < 9; r++)
            {
                Console.WriteLine("\n");
                for (int c = 0; c < 9; c++)
                {
                    Console.WriteLine("[" + r + "," + c + "] :" + fullGrid
[r, c]);
                }
            }
        }

        //method to hide


        public void RdmNbrsToKeep(int hideRdm)
        {
            int[][] gridReady = new int[9][];
            for (int row = 0; row < 9; row++)
            {
                List<int> availableToBeHidden = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                for (int i = 0; i < rdm.Next(1, hideRdm + 1); i++)
                {
                    int caseToHide = rdm.Next(0, availableToBeHidden.Count);//it is [min; max[ !
                    availableToBeHidden.Remove(availableToBeHidden[caseToHide]);
                }
                //list contains all random nbrs to keep on a row
                gridReady[row] = new int[availableToBeHidden.Count];
                //put the list in the according row of gridReady 
                for (int indexList = 0; indexList < availableToBeHidden.Count; indexList++)
                {
                    gridReady[row][indexList] = availableToBeHidden[indexList];
                    keepCount += 1;
                }
            }
            hiddenCount = 81 - keepCount;
            NumbersToKeep = gridReady;
            //then use
            //hiddenCount = visualGrid.HideDetermined(casesToHide);
        }

    }
}
