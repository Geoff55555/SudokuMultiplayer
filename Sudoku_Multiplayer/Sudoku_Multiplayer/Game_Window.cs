using Sudoku_Multiplayer.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Multiplayer
{
    public partial class Game_Window : Form
    {
        Sudoku_Grid generatedGrid = new Sudoku_Grid(false);
        Complete_Sudoku_Grid_Generator visualGrid = new Complete_Sudoku_Grid_Generator();
        List<int> nbrsAdmittedStaticList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Sudoku_Numb_Label clickedCaseTemp;

        //initialisation of the game window
        public Game_Window()
        {
            InitializeComponent();
            this.Controls.Add(visualGrid);

            this.KeyPress += new KeyPressEventHandler(PressNumberToWrite);
            this.KeyUp += new KeyEventHandler(keyIsUp);
            this.KeyPreview = true;

            foreach (Control gridcontrol in visualGrid.Controls)
            {
                foreach (Control caseControls in gridcontrol.Controls)
                {
                    if (caseControls is Sudoku_Numb_Label)
                    {
                        ((Sudoku_Numb_Label)caseControls).CaseClick += caseIsClicked;
                    }
                }
            }
            //for test purposes
            //this.Controls.Add(new Grid_3x3(3, 3));
            //Grid_3x3 sdGrid = new Grid_3x3(3, 3);
            //sdGrid.Location = new System.Drawing.Point(sdGrid.side_length,0);
            //Controls.Add(sdGrid);
        }

        //event when a case of the grid is clicked
        private void caseIsClicked(object sender, CaseClick e)
        {
            clickedCaseTemp = (Sudoku_Numb_Label)sender;
            Console.WriteLine("Case Clicked is : [ " + clickedCaseTemp.Coordinates[0] + " , " + clickedCaseTemp.Coordinates[1] + " ] and has been put in temporary memory to be re-used easily");
        }

        //Event on Key pressing
        private void keyIsUp(object sender, KeyEventArgs e) //keydown and keypress don't works: only KeyUp works, idk why...
        {
            //we don't want the button to get focus after our click
            visualGrid.Focus();

            //ENTER KEY
            if (e.KeyData == Keys.Enter)
            {
                try
                {
                    if (nbrsAdmittedStaticList.Contains(int.Parse(labelNbrPreview.Text)))
                    {
                        clickedCaseTemp.Text = labelNbrPreview.Text;
                        labelNbrPreview.Text = "ENTERED IN THE GRID";
                    }
                }
                catch
                {
                    //do nothing
                }
            }
            //ARROW KEYS for cool navigation in the grid
            else if (e.KeyData == Keys.Up || e.KeyData == Keys.Down || e.KeyData == Keys.Right || e.KeyData == Keys.Left)
            {
                if (clickedCaseTemp != null)
                {
                    //Determine the movement of clicked case according to the e.KeyData
                    int rowMove = 0;
                    int colMove = 0;
                    switch (e.KeyData)
                    {
                        case Keys.Up:
                            rowMove = -1;
                            break;
                        case Keys.Down:
                            rowMove = 1;
                            break;
                        case Keys.Right:
                            colMove = 1;
                            break;
                        case Keys.Left:
                            colMove = -1;
                            break;
                    }
                    //Find all adjacent grid and put it in a list
                    List<Grid_3x3> grid_3x3_list = new List<Grid_3x3>();
                    grid_3x3_list = clickedCaseTemp.FindAdjacentGrids();
                    //also don't forget the grid_3x3 of the current clicked case
                    grid_3x3_list.Add((Grid_3x3)clickedCaseTemp.Parent);
                    foreach (Grid_3x3 grid_3x3 in grid_3x3_list)
                    {
                        foreach (Control labelCase in grid_3x3.Controls)
                        {
                            if (labelCase is Sudoku_Numb_Label)
                            {
                                if (((Sudoku_Numb_Label)labelCase).Coordinates[0] == clickedCaseTemp.Coordinates[0] + rowMove && ((Sudoku_Numb_Label)labelCase).Coordinates[1] == clickedCaseTemp.Coordinates[1] + colMove)
                                {
                                    ((Sudoku_Numb_Label)labelCase).labelClick(labelCase, null);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }


        private void PressNumberToWrite(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (nbrsAdmittedStaticList.Contains(int.Parse(e.KeyChar.ToString())))
                {
                    labelNbrPreview.Text = e.KeyChar.ToString();
                }
            }
            catch
            {
                Console.WriteLine("Wrong entry on keyboard");
            }
        }

        //Buttons
        private void buttonFill_Click(object sender, EventArgs e)
        {
            visualGrid.Fill(generatedGrid);
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            visualGrid.HideRandom(9);
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            generatedGrid = new Sudoku_Grid(true);
            generatedGrid.ShowInConsole();
        }

        private void buttonSaveGrid_Click(object sender, EventArgs e)
        {
            TextWriter tw = new StreamWriter("saved_grid.txt");

            //write of text to the file
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    tw.WriteLine(generatedGrid.grid[row, col]);
                }
            }

            //close the stream
            tw.Close();
        }

        private void buttonLoadGrid_Click(object sender, EventArgs e)
        {
            TextReader tr = new StreamReader("saved_grid.txt");

            //read line of the file
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    generatedGrid.grid[row, col] = int.Parse(tr.ReadLine());
                }
            }

            //close the stream
            tr.Close();
        }

        private void NeverFocusedButton(object sender, EventArgs e)
        {
            //we never want the button to get focus
            visualGrid.Focus();
        }
    }
}
