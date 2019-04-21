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
        public int[,] grid = new int[9, 9];
        Random rdm = new Random();
        Random rdmMANDATORY = new Random();
        List<int> numbersListRow = new List<int>();
        List<int> numbersListGridCol1 = new List<int>();
        List<int> numbersListGridCol2 = new List<int>();
        List<int> numbersList_NO_MANDATORYGridCol2 = new List<int>();
        List<int> numbersListGridCol3 = new List<int>();
        List<int> numbersList_NO_MANDATORYGridCol3 = new List<int>();
        IEnumerable<int> staticFullList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int newRdm;
        int newNbrToAdd;
        int newRdmMANDATORY;

        public Sudoku_Grid()
        {
            int gridTag = 1;
            for (int row = 0; row < 9; row++)
            {
                numbersListRow.AddRange(staticFullList);
                if (row % 3 == 0)
                {
                    numbersListGridCol1.AddRange(staticFullList);
                    numbersListGridCol2.AddRange(staticFullList);
                    numbersList_NO_MANDATORYGridCol2.AddRange(staticFullList);
                    numbersListGridCol3.AddRange(staticFullList);
                    numbersList_NO_MANDATORYGridCol3.AddRange(staticFullList);
                }

                for (int column = 0; column < 9; column++)
                {
                    if (column % 3 == 0 && column != 0)
                    {
                        gridTag++;
                        //gridTag = gridTag + 3;
                    }

                    if (column == 0 && row != 0 && ((row + 1) % 3 != 0))
                    {
                        gridTag = gridTag - 2;
                    }

                    switch (gridTag)
                    {
                        case 1:
                            newRdm = rdm.Next(0, 8 - column); //random number using the INDICE of the list to get only remaining numbers :D
                            newNbrToAdd = numbersListRow[newRdm];
                            while (!numbersListGridCol1.Contains(newNbrToAdd))
                            {
                                newRdm = rdm.Next(0, 8 - column);//re-seek a number that matches both constrains unique in row (.Next(range in remaining numbers)--> OK) and grid (number is in the available list of the grid)
                                newNbrToAdd = numbersListRow[newRdm];
                            }
                            if (!numbersListGridCol2.Contains(newNbrToAdd))//if the number is already in tag 2
                            {
                                newRdmMANDATORY = rdmMANDATORY.Next(0, 8 - column);
                                int newNbrMANDATORY = numbersListRow[newRdmMANDATORY];
                                while (numbersListGridCol3.Contains(newNbrMANDATORY))//we need a nbr already written in tag 3
                                {
                                    newRdmMANDATORY = rdmMANDATORY.Next(0, numbersListRow.Count - 1);
                                    newNbrMANDATORY = numbersListRow[newRdmMANDATORY];
                                }
                                numbersList_NO_MANDATORYGridCol2.Remove(newNbrMANDATORY);
                            }
                            else if (!numbersListGridCol3.Contains(newNbrToAdd))
                            {
                                newRdmMANDATORY = rdmMANDATORY.Next(0, 8 - column);
                                int newNbrMANDATORY = numbersListRow[newRdmMANDATORY];
                                while (numbersListGridCol2.Contains(newNbrMANDATORY))
                                {
                                    newRdmMANDATORY = rdmMANDATORY.Next(0, numbersListRow.Count - 1);
                                    newNbrMANDATORY = numbersListRow[newRdmMANDATORY];
                                }
                                numbersList_NO_MANDATORYGridCol3.Remove(newNbrMANDATORY);
                            }
                            grid[row, column] = numbersListRow[newRdm];
                            numbersListGridCol1.Remove(numbersListRow[newRdm]);
                            numbersListRow.Remove(numbersListRow[newRdm]);
                            break;
                        case 2:
                            newRdm = rdm.Next(0, 8 - column); //random number using the INDICE of the list to get only remaining numbers :D
                            newNbrToAdd = numbersListRow[newRdm];
                            if (numbersListGridCol2.Contains(newNbrToAdd) && numbersList_NO_MANDATORYGridCol2.Count == 9)
                            //if there are no mandatory numbers
                            {
                                grid[row, column] = newNbrToAdd;
                                numbersListGridCol2.Remove(newNbrToAdd);
                                numbersListRow.Remove(newNbrToAdd);
                            }
                            else
                            {
                                if (numbersList_NO_MANDATORYGridCol2.Count < 9 && !numbersList_NO_MANDATORYGridCol2.Contains(newNbrToAdd))
                                //if there is are mandatory numbers, then they should be mandatory and randomely chosen among the possibilities
                                {
                                    numbersList_NO_MANDATORYGridCol2.Add(newNbrToAdd);
                                    grid[row, column] = newNbrToAdd;
                                    numbersListGridCol2.Remove(newNbrToAdd);
                                    numbersListRow.Remove(newNbrToAdd);
                                }
                                else
                                {
                                    goto case 2; //re-seek a number that matches both constrains unique in row (.Next(range in remaining numbers)--> OK) and grid (number is in the available list of the grid)
                                }
                            }
                            break;
                        case 3:
                            newRdm = rdm.Next(0, 8 - column); //random number using the INDICE of the list to get only remaining numbers :D
                            newNbrToAdd = numbersListRow[newRdm];
                            if (numbersListGridCol3.Contains(newNbrToAdd))
                            {
                                grid[row, column] = newNbrToAdd;
                                numbersListGridCol3.Remove(newNbrToAdd);
                                if (numbersList_NO_MANDATORYGridCol3.Count < 9 && !numbersList_NO_MANDATORYGridCol3.Contains(newNbrToAdd))
                                {
                                    numbersList_NO_MANDATORYGridCol3.Add(newNbrToAdd);
                                }
                                numbersListRow.Remove(newNbrToAdd);
                            }
                            else
                            {
                                goto case 3; //re-seek a number that matches both constrains unique in row (.Next(range in remaining numbers)--> OK) and grid (number is in the available list of the grid)
                            }
                            break;
                        case 4:
                            goto case 1;
                        case 5:
                            goto case 2;
                        case 6:
                            goto case 3;
                        case 7:
                            goto case 1;
                        case 8:
                            goto case 2;
                        case 9:
                            goto case 3;

                    }
                }
            }
        }

        public void ShowInConsole()
        {
            for (int r = 0; r < 9; r++)
            {
                Console.WriteLine("\n");
                for (int c = 0; c < 9; c++)
                {
                    Console.WriteLine("[" + r + "," + c + "] :" + grid[r, c]);
                }
            }
        }
    }
}
