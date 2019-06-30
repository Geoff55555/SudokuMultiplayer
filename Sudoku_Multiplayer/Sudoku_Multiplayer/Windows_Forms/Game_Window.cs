using Client_Server_SerialComm;
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
        //attributes
        Client client;
        Server server;
        bool isHost = true;
        int Difficulty = 1;
        Random rdm = new Random();
        //--for reception of special pack
        bool isWaitingforCase = false;

        Sudoku_Nbrs_Gen generatedGridNbrs = new Sudoku_Nbrs_Gen(false);
        Grid_9x9 visualGrid = new Grid_9x9();
        List<int> nbrsAdmittedStaticList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Sudoku_Label_Nbr clickedCaseTemp;
        Sudoku_Label_Nbr receivedCase;
        int hiddenCount = 0;

        //initialisation of the game window
        public Game_Window(Server setServer, Client setClient, bool setIsHost, int setDifficulty)
        {
            this.isHost = setIsHost;
            if (isHost)
            {
                server = setServer;
                server.InfoExchange += server_InfoExchange;
            }
            else
            {
                client = setClient;
                client.infoExchange += client_infoExchange;
            }

            InitializeComponent();
            if (isHost)
            {
                buttonGo.Enabled = true;
            }
            this.Controls.Add(visualGrid);

            //difficulty set
            Difficulty = setDifficulty;
            comboBox_Difficulty.SelectedItem = setDifficulty;

            //Add events to manage keys press
            this.KeyPress += new KeyPressEventHandler(PressNumberToWrite);
            this.KeyPreview = true;

            //Add event click to every label added in grid 9x9
            foreach (Control gridcontrol in visualGrid.Controls)
            {
                foreach (Control caseControls in gridcontrol.Controls)
                {
                    if (caseControls is Sudoku_Label_Nbr)
                    {
                        ((Sudoku_Label_Nbr)caseControls).CaseClick += caseIsClicked;
                    }
                }
            }
        }

        //onInfoExchange
        private void client_infoExchange(object sender, commArgs e)
        {
            if (e.ObjectData is Sudoku_Nbrs_Gen)
            {
                generatedGridNbrs = (Sudoku_Nbrs_Gen)e.ObjectData;
                visualGrid.Fill(generatedGridNbrs);
                hiddenCount = visualGrid.HideDetermined(generatedGridNbrs.NumbersToKeep);
            }
            else if (e.ObjectData is int[])
            {
                foreach (Control grid_9x9 in this.Controls)
                {
                    if (grid_9x9 is Grid_9x9)
                    {
                        foreach (Control grid_3x3 in grid_9x9.Controls)
                        {
                            if (grid_3x3 is Grid_3x3)
                            {
                                foreach (Sudoku_Label_Nbr caseLabel in grid_3x3.Controls)
                                {
                                    if (caseLabel.Coordinates.SequenceEqual((int[])e.ObjectData))
                                    {
                                        receivedCase = caseLabel;
                                        Console.WriteLine("We received a case ! Coordinates are : [ " + receivedCase.Coordinates[0] + " , " + receivedCase.Coordinates[1] + " ]");
                                        //coordinates just received --> waiting for number
                                        isWaitingforCase = true;
                                        Console.WriteLine("Waiting for the number...");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (e.ObjectData is string)
            {
                if (isWaitingforCase)
                {
                    receivedCase.Text = (string)e.ObjectData;
                    receivedCase.BackColor = Color.DeepSkyBlue;
                    isWaitingforCase = false;
                    Console.WriteLine("We received the number ! It is : " + receivedCase.Text);
                    hiddenCount -= 1;
                }
            }
            else if(e.Reception)
            {
                Console.WriteLine("Data received but not managed");
            }
        }

        private void server_InfoExchange(object sender, commArgs e)
        {
            if (e.ObjectData is int[])
            {
                foreach (Control grid_9x9 in this.Controls)
                {
                    if (grid_9x9 is Grid_9x9)
                    {
                        foreach (Control grid_3x3 in grid_9x9.Controls)
                        {
                            if (grid_3x3 is Grid_3x3)
                            {
                                foreach (Sudoku_Label_Nbr caseLabel in grid_3x3.Controls)
                                {
                                    if (caseLabel.Coordinates.SequenceEqual((int[])e.ObjectData))
                                    {
                                        receivedCase = caseLabel;
                                        Console.WriteLine("We received a case ! Coordinates are : [ " + receivedCase.Coordinates[0] + " , " + receivedCase.Coordinates[1] + " ]");
                                        //coordinates just received --> waiting for number
                                        isWaitingforCase = true;
                                        Console.WriteLine("Waiting for the number...");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (e.ObjectData is string)
            {
                if (isWaitingforCase)
                {
                    receivedCase.Text = (string)e.ObjectData;
                    receivedCase.BackColor = Color.DeepSkyBlue;
                    isWaitingforCase = false;
                    Console.WriteLine("We received the number ! It is : " + receivedCase.Text);
                    hiddenCount -= 1;
                }
            }
            else if (e.Reception)
            {
                Console.WriteLine("Data received but not managed");
            }
        }

        //event when a case of the grid is clicked
        private void caseIsClicked(object sender, CaseClick e)
        {
            clickedCaseTemp = (Sudoku_Label_Nbr)sender;
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
                        labelNbrPreview.Text = "In the \nGrid";
                        //check if was the right number
                        int rightNumb = generatedGridNbrs.fullGrid[clickedCaseTemp.Coordinates[0], clickedCaseTemp.Coordinates[1]];
                        if (int.Parse(clickedCaseTemp.Text) == rightNumb)
                        {
                            clickedCaseTemp.ForeColor = Color.PaleGreen;
                            clickedCaseTemp.isRight = true;
                            hiddenCount -= 1;

                            //share result
                            if (isHost)
                            {
                                for (int client = 0; client < server.ClientList.Count; client++)
                                {
                                    server.ClientList[client].SendData(clickedCaseTemp.Coordinates, "coord");
                                    Console.WriteLine("Coordinates are sent to the client.");
                                    server.ClientList[client].SendData(clickedCaseTemp.Text, "nbr");
                                    Console.WriteLine("The number is sent to the client.");
                                }
                            }
                            else
                            {
                                client.SendData(clickedCaseTemp.Coordinates, "coord");
                                Console.WriteLine("Coordinates are sent to the server.");
                                client.SendData(clickedCaseTemp.Text, "nbr");
                                Console.WriteLine("The number is sent to the server.");
                            }

                            //END GAME
                            if (hiddenCount == 0)
                            {
                                labelNbrPreview.ForeColor = Color.LimeGreen;
                                labelNbrPreview.Text = "YOU \nWON !";
                                clickedCaseTemp.noHighlight(false);
                                //unlock new grid editor
                                buttonGenerate.Enabled = true;
                                buttonSaveGrid.Enabled = true;
                                buttonLoadGrid.Enabled = true;
                                buttonFill.Enabled = true;
                                buttonHide.Enabled = true;
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
                            if (labelCase is Sudoku_Label_Nbr)
                            {
                                if (((Sudoku_Label_Nbr)labelCase).Coordinates[0] == clickedCaseTemp.Coordinates[0] + rowMove && ((Sudoku_Label_Nbr)labelCase).Coordinates[1] == clickedCaseTemp.Coordinates[1] + colMove)
                                {
                                    ((Sudoku_Label_Nbr)labelCase).labelClick(labelCase, null);
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

        //methods
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
            visualGrid.Fill(generatedGridNbrs);
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            hiddenCount = visualGrid.HideRandom(Difficulty);
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            generatedGridNbrs = new Sudoku_Nbrs_Gen(true);
            generatedGridNbrs.ShowInConsole();
        }

        private void buttonSaveGrid_Click(object sender, EventArgs e)
        {
            TextWriter tw = new StreamWriter("saved_grid.txt");

            //write of text to the file
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    tw.WriteLine(generatedGridNbrs.fullGrid[row, col]);
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
                    generatedGridNbrs.fullGrid[row, col] = int.Parse(tr.ReadLine());
                }
            }

            //close the stream
            tr.Close();
        }

        private void NeverFocusButton(object sender, EventArgs e)
        {
            visualGrid.Focus();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            //load a grid
            TextReader tr = new StreamReader("saved_grid.txt");

            //read line of the file
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    generatedGridNbrs.fullGrid[row, col] = int.Parse(tr.ReadLine());
                }
            }
            //close the stream
            tr.Close();

            //determine the nbrs to hide --> written in generatedGrid.NbrsToHide
            generatedGridNbrs.RdmNbrsToKeep(Difficulty);

            //send it to client
            //--cannot serialize the whole grid

            //--send the grid with wholes
            for (int client = 0; client < server.ClientList.Count; client++)
            {
                server.ClientList[client].SendData(generatedGridNbrs, "generatedGrid");
            }

            //fill the visual
            visualGrid.Fill(generatedGridNbrs);
            hiddenCount = visualGrid.KeepDetermined(generatedGridNbrs.NumbersToKeep);
            //hiddenCount = visualGrid.HideRandom(Difficulty);

            //int[][] casesToHide = new int[9][];
            //casesToHide[0] = new int[] { 2, 3, 4 };
            //casesToHide[1] = new int[] { 2, 3, 4 };
            //casesToHide[2] = new int[] { 2, 3, 4 };
            //casesToHide[3] = new int[] { 2, 3, 4 };
            //casesToHide[4] = new int[] { 2, 3, 4 };
            //casesToHide[5] = new int[] { 2, 3, 4 };
            //casesToHide[6] = new int[] { 2, 3, 4 };
            //casesToHide[7] = new int[] { 2, 3, 4 };
            //casesToHide[8] = new int[] { 2, 3, 4 };
            //hiddenCount = visualGrid.KeepDetermined(casesToHide);
        }
    }
}
