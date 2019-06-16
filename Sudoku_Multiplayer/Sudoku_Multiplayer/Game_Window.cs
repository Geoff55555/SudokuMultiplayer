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
        int hiddenCount = 0;

        //initialisation of the game window
        public Game_Window()
        {
            InitializeComponent();
            this.Controls.Add(visualGrid);

            this.KeyPress += new KeyPressEventHandler(PressNumberToWrite);
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

        //so grateful for thos explainations http://umaranis.com/2013/07/09/handle-arrow-key-events-in-windows-forms-net/
        //Pressing of a key is detected and handled in Windows Form using KeyPress, KeyDown or similar events.
        //But these events does not fire when arrow keys are pressed.One way to get around it is to set KeyPreview as true for your Form.In many cases, this also doesn’t work, for instance, when you have buttons on your Form.
        //In such cases, ProcessCmdKey can be overridden to detect and handle arrow key events.
        //After handling the arrow key event if you do not want the standard arrow key functionality to kick in, return true rather than calling return base.ProcessCmdKey(ref msg, keyData); Standard functionality could be to move focus to the next or previous control.
        //Returning true from ProcessCmdKey means event has been handled and should not be routed further for processing.
        //So it catches ALL (raw) keyboard input ! --> Not so nice if we want to get the caracters of the keys. Rather use KeyPress for the numbers
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //ENTER KEY
            if (keyData == Keys.Enter)
            {
                try
                {
                    //if the number is a number from 1 to 9 and if it is not right yet
                    if (nbrsAdmittedStaticList.Contains(int.Parse(labelNbrPreview.Text)) && !clickedCaseTemp.isRight)
                    {
                        //Sets the number in the grid
                        clickedCaseTemp.Text = labelNbrPreview.Text;
                        labelNbrPreview.Text = "WATCH IN \nTHE GRID";
                        //check if was the right number
                        int rightNumb = generatedGrid.grid[clickedCaseTemp.Coordinates[0], clickedCaseTemp.Coordinates[1]];
                        if (int.Parse(clickedCaseTemp.Text) == rightNumb)
                        {
                            clickedCaseTemp.ForeColor = Color.PaleGreen;
                            clickedCaseTemp.isRight = true;
                            hiddenCount -= 1;
                            if (hiddenCount == 0)
                            {
                                labelNbrPreview.ForeColor = Color.LimeGreen;
                                labelNbrPreview.Text = "YOU \nWON !";
                                clickedCaseTemp.noHighlight(false);
                            }
                            //Case handled, return true to say we're done
                            return true;
                        }
                        else
                        {
                            clickedCaseTemp.ForeColor = Color.DarkRed;
                            clickedCaseTemp.isRight = false;
                            //Case handled, return true to say we're done
                            return true;
                        }
                    }
                }
                catch
                {
                    //do nothing
                }
            }
            //ARROW KEYS for cool navigation in the grid
            else if (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Right || keyData == Keys.Left)
            {
                if (clickedCaseTemp != null)
                {
                    //Determine the movement of clicked case according to the e.KeyData
                    int rowMove = 0;
                    int colMove = 0;
                    switch (keyData)
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
                                    //Case handled, return true to say we're done
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            //if here, maybe it is a number input, so we're not done
            return false;
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

        private void hideDetermined()
        {
            int[][] casesToHide = new int[9][];
            casesToHide[0] = new int[] { 2, 3, 4 };
            casesToHide[1] = new int[] { 2, 3, 4 };
            casesToHide[2] = new int[] { 2, 3, 4 };
            casesToHide[3] = new int[] { 2, 3, 4 };
            casesToHide[4] = new int[] { 2, 3, 4 };
            casesToHide[5] = new int[] { 2, 3, 4 };
            casesToHide[6] = new int[] { 2, 3, 4 };
            casesToHide[7] = new int[] { 2, 3, 4 };
            casesToHide[8] = new int[] { 2, 3, 4 };
            hiddenCount = visualGrid.HideDetermined(casesToHide);
        }

        //Buttons
        private void buttonFill_Click(object sender, EventArgs e)
        {
            visualGrid.Fill(generatedGrid);
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            hiddenCount = visualGrid.HideRandom(3);
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

        private void NeverFocusButton(object sender, EventArgs e)
        {
            visualGrid.Focus();
        }
    }
}
