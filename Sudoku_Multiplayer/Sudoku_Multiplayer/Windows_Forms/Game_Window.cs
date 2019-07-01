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

        Sudoku_Nbrs_Gen generatedGridNbrs = new Sudoku_Nbrs_Gen(false);
        Grid_9x9 visualGrid = new Grid_9x9();
        List<int> nbrsAdmittedStaticList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //for easier and quicker access to the cells
        List<Sudoku_Label_Nbr> allCellsList;
        Sudoku_Label_Nbr clickedCaseTemp;
        Sudoku_Label_Nbr receivedCase;
        int hiddenCount = 0;
        bool gameIsOver;

        //initialisation of the game window
        public Game_Window(Server setServer, Client setClient, bool setIsHost, int setDifficulty)
        {
            InitializeComponent();

            this.isHost = setIsHost;
            if (isHost)
            {
                server = setServer;
                server.InfoExchange += server_InfoExchange;
                buttonGo.Enabled = true;
            }
            else
            {
                client = setClient;
                client.InfoExchange += client_infoExchange;
                client.ReceiveData();
            }

            //visual grid size adjustement to the dedicated panel
            this.panel_SudokuGrid.Controls.Add(visualGrid);
            visualGrid.ChangeSize(visualGrid.Parent.Size);
            Console.WriteLine("Height and Width of the grid : " + visualGrid.Size.Height.ToString() + " " + visualGrid.Size.Width.ToString());

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

            //to have all cells accessible quickly and easily
            allCellsList = visualGrid.GetAllChilds();
        }

        //onInfoExchange
        private void client_infoExchange(object sender, commArgs e)
        {
            if (e.Reception)
            {
                if (e.ObjectData is int[])
                {
                    foreach (Control grid_9x9 in this.panel_SudokuGrid.Controls)
                    {
                        if (grid_9x9 is Grid_9x9)
                        {
                            foreach (Control grid_3x3 in grid_9x9.Controls)
                            {
                                if (grid_3x3 is Grid_3x3)
                                {
                                    foreach (Sudoku_Label_Nbr caseLabel in grid_3x3.Controls)
                                    {
                                        if (caseLabel.Coordinates[0] == ((int[])e.ObjectData)[0] && caseLabel.Coordinates[1] == ((int[])e.ObjectData)[1])
                                        {
                                            receivedCase = caseLabel;
                                            receivedCase.Text = ((int[])e.ObjectData)[2].ToString();
                                            receivedCase.isRight = true;
                                            Console.WriteLine("We received a case ! Coordinates are : [ " + receivedCase.Coordinates[0] + " , " + receivedCase.Coordinates[1] + " ]" +
                                                "\nAnd the number is " + receivedCase.Text);
                                            receivedCase.BackColor = Color.DeepSkyBlue;
                                            hiddenCount -= 1;
                                            Console.WriteLine(hiddenCount + "case(s) left to find until the end !");
                                            checkEndGame();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (e.ObjectData is Sudoku_Nbrs_Gen)
                {
                    generatedGridNbrs = (Sudoku_Nbrs_Gen)e.ObjectData;
                    visualGrid.Fill(generatedGridNbrs);
                    //hiddenCount = visualGrid.HideDetermined(generatedGridNbrs.NumbersToKeep);
                    visualGrid.HideDetermined(generatedGridNbrs.NumbersToKeep);
                }
                else if (e.ObjectData is string)
                {
                    switch (((string)e.ObjectData).Split(',')[0])
                    {
                        case "hiddenCount":
                            hiddenCount = int.Parse(((string)e.ObjectData).Split(',')[1]);
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Data received but not managed");
                }
            }
        }

        private void server_InfoExchange(object sender, commArgs e)
        {
            if (e.Reception)
            {
                if (e.ObjectData is int[])
                {
                    foreach (Control grid_9x9 in this.panel_SudokuGrid.Controls)
                    {
                        if (grid_9x9 is Grid_9x9)
                        {
                            foreach (Control grid_3x3 in grid_9x9.Controls)
                            {
                                if (grid_3x3 is Grid_3x3)
                                {
                                    foreach (Sudoku_Label_Nbr caseLabel in grid_3x3.Controls)
                                    {
                                        if (caseLabel.Coordinates[0] == ((int[])e.ObjectData)[0] && caseLabel.Coordinates[1] == ((int[])e.ObjectData)[1])
                                        {
                                            receivedCase = caseLabel;
                                            receivedCase.Text = ((int[])e.ObjectData)[2].ToString();
                                            receivedCase.isRight = true;
                                            Console.WriteLine("We received a case ! Coordinates are : [ " + receivedCase.Coordinates[0] + " , " + receivedCase.Coordinates[1] + " ]" +
                                                "\nAnd the number is " + receivedCase.Text);
                                            receivedCase.BackColor = Color.DeepSkyBlue;
                                            hiddenCount -= 1;
                                            Console.WriteLine(hiddenCount + "case(s) left to find until the end !");
                                            checkEndGame();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Data received but not managed");
                }
            }
        }

        //event when a case of the grid is clicked
        private void caseIsClicked(object sender, CaseClick e)
        {
            if (!gameIsOver)
            {
                clickedCaseTemp = (Sudoku_Label_Nbr)sender;
                Console.WriteLine("Case Clicked is : [ " + clickedCaseTemp.Coordinates[0] + " , " + clickedCaseTemp.Coordinates[1] + " ] and has been put in temporary memory to be re-used easily");
            }
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
                            Console.WriteLine(hiddenCount + "case(s) left to find until the end !");


                            //share result
                            if (isHost)
                            {
                                for (int client = 0; client < server.ClientList.Count; client++)
                                {
                                    int[] coordAndNbr = new int[3];
                                    coordAndNbr[0] = clickedCaseTemp.Coordinates[0];
                                    coordAndNbr[1] = clickedCaseTemp.Coordinates[1];
                                    coordAndNbr[2] = int.Parse(clickedCaseTemp.Text);
                                    server.ClientList[client].SendData(coordAndNbr);
                                    Console.WriteLine("The case (coord and text) has been sent to the client(s).");

                                    //server.ClientList[client].SendData(clickedCaseTemp.Coordinates, "coord");
                                    //Console.WriteLine("Coordinates are sent to the client.");
                                    //no more used because the 2d pack is not always received
                                    //server.ClientList[client].SendData(clickedCaseTemp.Text, "nbr");
                                    //Console.WriteLine("The number is sent to the client.");
                                }
                            }
                            else
                            {
                                int[] coordAndNbr = new int[3];
                                coordAndNbr[0] = clickedCaseTemp.Coordinates[0];
                                coordAndNbr[1] = clickedCaseTemp.Coordinates[1];
                                coordAndNbr[2] = int.Parse(clickedCaseTemp.Text);
                                client.SendData(coordAndNbr);
                                Console.WriteLine("The case (coord and text) has been sent to the server.");

                                //no more used because the 2d pack is not always received
                                //client.SendData(clickedCaseTemp.Coordinates, "coord");
                                //Console.WriteLine("Coordinates are sent to the server.");
                                //client.SendData(clickedCaseTemp.Text, "nbr");
                                //Console.WriteLine("The number is sent to the server.");
                            }

                            //END GAME check and if true, changes the color of all cells
                            checkEndGame();
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
                if (clickedCaseTemp != null && !gameIsOver)
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

                    //would work if the list was created with line order but it is with by grid3x3 order
                    //int nbrOfCellInTheList = (clickedCaseTemp.Coordinates[0]+1+rowMove)* (clickedCaseTemp.Coordinates[0]+1 + rowMove)-1;//+1 is to avoid multiply error caused by a position 0
                    //allCellsList[nbrOfCellInTheList].labelClick(allCellsList[nbrOfCellInTheList], null);

                    //best solution
                    //coord of new clicked case
                    int[] newCoord = new int[2];
                    newCoord[0] = clickedCaseTemp.Coordinates[0] + rowMove;
                    newCoord[1] = clickedCaseTemp.Coordinates[1] + colMove;

                    for (int i = 0; i < allCellsList.Count; i++)
                    {
                        if (allCellsList[i].Coordinates.SequenceEqual(newCoord))
                        {
                            allCellsList[i].LabelClick(allCellsList[i], null);
                            //Case handled, return true to say we're done
                            return true;
                        }
                    }

                    //old solution
                    ////Find all adjacent grid and put it in a list
                    //List<Grid_3x3> grid_3x3_list = new List<Grid_3x3>();
                    //grid_3x3_list = clickedCaseTemp.FindAdjacentGrids();
                    ////also don't forget the grid_3x3 of the current clicked case
                    //grid_3x3_list.Add((Grid_3x3)clickedCaseTemp.Parent);
                    //foreach (Grid_3x3 grid_3x3 in grid_3x3_list)
                    //{
                    //    foreach (Control labelCase in grid_3x3.Controls)
                    //    {
                    //        if (labelCase is Sudoku_Label_Nbr)
                    //        {
                    //            if (((Sudoku_Label_Nbr)labelCase).Coordinates[0] == clickedCaseTemp.Coordinates[0] + rowMove && ((Sudoku_Label_Nbr)labelCase).Coordinates[1] == clickedCaseTemp.Coordinates[1] + colMove)
                    //            {
                    //                ((Sudoku_Label_Nbr)labelCase).labelClick(labelCase, null);
                    //                //Case handled, return true to say we're done
                    //                return true;
                    //            }
                    //        }
                    //    }
                    //}
                }
            }
            //if here, maybe it is a number input, so we're not done
            return false;
        }

        private void PressNumberToWrite(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (nbrsAdmittedStaticList.Contains(int.Parse(e.KeyChar.ToString())) && !gameIsOver)
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
            //hiddenCount = visualGrid.HideDetermined(casesToHide);
            visualGrid.HideDetermined(casesToHide);
        }

        private void checkEndGame()
        {
            if (hiddenCount == 0)
            {
                labelNbrPreview.ForeColor = Color.LimeGreen;
                labelNbrPreview.Text = "YOU \nWON !";
                if (clickedCaseTemp != null)
                {
                    clickedCaseTemp.NoHighlight(false);
                }
                //unlock new grid editor
                panel_NewGameEditor.Enabled = true;
                //to avoid any new highligh
                gameIsOver = true;
            }
        }

        //Buttons

        //loaded party
        private void buttonLoadFullGrid_AndHideNbrs_Click(object sender, EventArgs e)
        {
            //open dialog to chose the file of sudoku grid
            OpenFileDialog windowToLoadFile = new OpenFileDialog();
            windowToLoadFile.Filter = "Text files (*.txt)|*.txt";

            if (windowToLoadFile.ShowDialog() == DialogResult.OK)
            {
                TextReader tr = new StreamReader(windowToLoadFile.FileName);

                Console.WriteLine("Grid file is beeing loaded : ");
                //read line of the file
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        generatedGridNbrs.fullGrid[row, col] = int.Parse(tr.ReadLine());
                        //display it to check
                        Console.Write(generatedGridNbrs.fullGrid[row, col].ToString());
                    }
                    //new line in console
                    Console.Write("\n");
                }
                //close the stream
                tr.Close();
            }
        }

        private void buttonSaveGrid_Click(object sender, EventArgs e)
        {
            //open the dialog to save the file if necesseray
            SaveFileDialog windowToSaveFile = new SaveFileDialog();
            windowToSaveFile.Filter = "Text files (*.txt)|*.txt";

            if (windowToSaveFile.ShowDialog() == DialogResult.OK)
            {
                TextWriter tw = new StreamWriter(windowToSaveFile.FileName);

                Console.WriteLine("Grid file is beeing saved : ");
                //write of text to the file
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        tw.WriteLine(generatedGridNbrs.fullGrid[row, col]);
                        Console.Write(generatedGridNbrs.fullGrid[row, col]);
                    }
                    Console.Write("\n");
                }

                //close the stream
                tw.Close();
            }
        }

        //rdm party
        private void buttonGenerateRdm_Click(object sender, EventArgs e)
        {
            generatedGridNbrs = new Sudoku_Nbrs_Gen(true);
            generatedGridNbrs.ShowInConsole();
        }

        private void buttonFillAndHideRdm_Click(object sender, EventArgs e)
        {
            visualGrid.Fill(generatedGridNbrs);
            hiddenCount = visualGrid.HideRandom(Difficulty);
        }

        //load party
        private void radioButton_LoadParty_CheckedChanged(object sender, EventArgs e)
        {
            panel_RdmParty.Enabled = false;
            panel_LoadParty.Enabled = true;
        }

        private void radioButton_RdmParty_CheckedChanged(object sender, EventArgs e)
        {
            panel_RdmParty.Enabled = true;
            panel_LoadParty.Enabled = false;
        }
        
        //still to do
        private void button_LoadNbrsToKeep_Click(object sender, EventArgs e)
        {

        }

        //-----------------------------------
        //visual grid
        private void buttonFill_Click(object sender, EventArgs e)
        {
            visualGrid.Fill(generatedGridNbrs);
        }

        //launch the game -- debug
        private void buttonGo_Click(object sender, EventArgs e)
        {
            launchTheGame_Debug();
        }

        private void launchTheGame_Debug()
        {
            //making sure the game is init
            gameIsOver = false;

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
            this.hiddenCount = generatedGridNbrs.hiddenCount;


            //send it to client
            //--cannot serialize the whole grid

            //--send the grid with wholes
            for (int client = 0; client < server.ClientList.Count; client++)
            {
                server.ClientList[client].SendData(generatedGridNbrs);
            }

            //fill the visual
            visualGrid.Fill(generatedGridNbrs);

            //determine how many nbrs will be hidden
            //hiddenCount = visualGrid.KeepDetermined(generatedGridNbrs.NumbersToKeep);
            visualGrid.KeepDetermined(generatedGridNbrs.NumbersToKeep);
            Console.WriteLine("Nbrs of cases to discover is " + hiddenCount);

            //send that number
            string hiddenCountToSend = "hiddenCount,";
            hiddenCountToSend += this.hiddenCount.ToString();
            for (int client = 0; client < server.ClientList.Count; client++)
            {
                server.ClientList[client].SendData(hiddenCountToSend);
            }

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

        //for pratical use
        private void NeverFocusButton(object sender, EventArgs e)
        {
            visualGrid.Focus();
        }

    }
}
