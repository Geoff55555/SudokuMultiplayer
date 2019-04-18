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
        List<int> numbersList = new List<int>();
        IEnumerable<int> staticFullList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int newRdm = 0;

        public Sudoku_Grid()
        {
            for (int row = 0; row < 9; row++)
            {
                numbersList.AddRange(staticFullList);
                for (int column = 0; column < 9; column++)
                {
                    newRdm = rdm.Next(0, 8 - column); //random number using the INDICE of the list to get only remaining numbers :D
                    if (numbersList.Contains(numbersList[newRdm]))
                    {
                        grid[row, column] = numbersList[newRdm];
                        numbersList.Remove(numbersList[newRdm]);
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
                    Console.WriteLine("[" + r + "," + c +"] :"+ grid[r,c]);
                }
            }
        }
    }
}
