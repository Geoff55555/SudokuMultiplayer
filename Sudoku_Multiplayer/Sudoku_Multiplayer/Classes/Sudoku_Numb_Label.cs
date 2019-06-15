using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Multiplayer.Classes
{
    class Sudoku_Numb_Label : Label
    {
        public int[] Coordinates = new int[2];
        public event EventHandler<CaseClick> CaseClick;

        //Constructor to fill Grid_3x3
        public Sudoku_Numb_Label(int row, int column)
        {
            //Set tag for future identification : they are the coordinates
            Coordinates[0] = row;
            Coordinates[1] = column;
            this.Tag = Coordinates;
            //Set font size
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.Size = new System.Drawing.Size(this.Parent.Width, this.Parent.Height);

            //Make it fill its container
            this.Dock = System.Windows.Forms.DockStyle.Fill;

            //Set Location
            //this.Location = new System.Drawing.Point(0, 0); //if it fills the container, location has no more sense

            //Set alignment
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //Set the margins
            this.Margin = new Padding(0);

            //Set event on click
            this.Click += new System.EventHandler(this.labelClick);
        }

        //Constructor for notes
        public Sudoku_Numb_Label(int note)
        {
            //Make it fill its container
            this.Dock = System.Windows.Forms.DockStyle.Fill;

            //Set font size
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.Size = new System.Drawing.Size(this.Parent.Width, this.Parent.Height);

            //Set Location and Alignment
            this.Location = new System.Drawing.Point();
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //Set Text
            this.Text = note.ToString();
        }

        //methods
        //when the case is clicked for delegate methods
        void OnCaseClick(object sender, CaseClick c)
        {
            if (CaseClick != null)
            {
                CaseClick(sender, c);
            }
        }

        //for HIGHLIGHTS
        public void labelClick(object sender, EventArgs e)
        {
            this.BackColor = Color.Teal;
            string message = "Label clicked is : [ " + this.Coordinates[0] + " , " + this.Coordinates[1] + " ]";
            CaseClick c = new CaseClick();
            c.message = message;
            Console.WriteLine(message);

            noHighlight();//before higlighting, reset to no highlight so the past highlight is removed
            highlightThisLabelGrid();
            highlightNextColAndRow();

            OnCaseClick(this, c);
        }

        private void noHighlight()
        {
            foreach (Control grid in this.Parent.Parent.Controls)
            {
                if (grid is Grid_3x3)
                {
                    foreach (Control label in grid.Controls)
                    {
                        if (label is Label)
                        {
                            ((Label)label).BackColor = Color.Transparent;
                        }
                    }
                }
            }
        }

        private void highlightThisLabelGrid()
        {
            foreach (Label label in this.Parent.Controls)
            {
                if ((((int[])label.Tag)[0] == this.Coordinates[0] && ((int[])label.Tag)[1] != this.Coordinates[1]) || (((int[])label.Tag)[0] != this.Coordinates[0] && ((int[])label.Tag)[1] == this.Coordinates[1]))
                {
                    label.BackColor = Color.Teal;
                }
                else if (((int[])label.Tag)[0] == this.Coordinates[0] && ((int[])label.Tag)[1] == this.Coordinates[1])
                {
                    label.BackColor = Color.LightSeaGreen;
                }
            }
        }

        private void highlightNextColAndRow()
        {
            List<Grid_3x3> gridList = new List<Grid_3x3>();
            gridList = FindAdjacentGrids();
            highlight(gridList);
        }

        private void highlight(List<Grid_3x3> gridList)
        {
            //act on 2 first (--> horizontal) adjacent grid
            for (int gridIndex = 0; gridIndex < 2; gridIndex++)
            {
                //preparation of a list of the coordinates to highlight
                List<int[]> listCoordToHighlight = new List<int[]>();
                for (int col = 0; col < 3; col++)
                {
                    int thisRow = this.Coordinates[0];
                    int[] coordTemp = new int[] { thisRow, col + gridList[gridIndex].colCorr};
                    listCoordToHighlight.Add(coordTemp);
                }

                //highlight based on the list
                foreach (Label label in gridList[gridIndex].Controls)
                {
                    if (((int[])label.Tag).SequenceEqual(listCoordToHighlight[0]) || ((int[])label.Tag).SequenceEqual(listCoordToHighlight[1]) || ((int[])label.Tag).SequenceEqual(listCoordToHighlight[2]))
                    {
                        label.BackColor = Color.Teal;
                    }
                    else
                    {
                        label.BackColor = Color.Transparent;
                    }
                }
            }

            //act on 2 last (--> vertical) adjacent grid
            for (int gridIndex = 2; gridIndex < 4; gridIndex++)
            {
                //preparation of a list of the coordinates to highlight
                List<int[]> listCoordToHighlight = new List<int[]>();
                for (int row = 0; row < 3; row++)
                {
                    int thisCol = this.Coordinates[1];
                    int[] coordTemp = new int[] { row + gridList[gridIndex].rowCorr, thisCol };
                    listCoordToHighlight.Add(coordTemp);
                }

                //highlight based on the list
                foreach (Label label in gridList[gridIndex].Controls)
                {
                    if (((int[])label.Tag).SequenceEqual(listCoordToHighlight[0]) || ((int[])label.Tag).SequenceEqual(listCoordToHighlight[1]) || ((int[])label.Tag).SequenceEqual(listCoordToHighlight[2]))
                    {
                        label.BackColor = Color.Teal;
                    }
                }
            }
        }

        //Function to find all adjacent grids
        public List<Grid_3x3> FindAdjacentGrids()
        {
            List<Grid_3x3> gridList = new List<Grid_3x3>();
            switch (this.Parent.Tag)
            {
                case 1:
                    add4Grids_3x3(gridList, 2, 3, 4, 7);
                    break;
                case 2:
                    add4Grids_3x3(gridList, 1, 3, 5, 8);
                    break;
                case 3:
                    add4Grids_3x3(gridList, 1, 2, 6, 9);
                    break;
                case 4:
                    add4Grids_3x3(gridList, 5, 6, 1, 7);
                    break;
                case 5:
                    add4Grids_3x3(gridList, 4, 6, 2, 8);
                    break;
                case 6:
                    add4Grids_3x3(gridList, 4, 5, 3, 9);
                    break;
                case 7:
                    add4Grids_3x3(gridList, 8, 9, 1, 4);
                    break;
                case 8:
                    add4Grids_3x3(gridList, 7, 9, 2, 5);
                    break;
                case 9:
                    add4Grids_3x3(gridList, 7, 8, 3, 6);
                    break;
            }
            return gridList;
        }

        //Add the adjacent grids to a list of adj grids
        private void add4Grids_3x3(List<Grid_3x3> gridList, int adjGh1, int adjGh2, int adjGv1, int adjGv2)
        {
            //to add in correct order
            gridList.Add(add1Grid_3x3(adjGh1));
            gridList.Add(add1Grid_3x3(adjGh2));
            gridList.Add(add1Grid_3x3(adjGv1));
            gridList.Add(add1Grid_3x3(adjGv2));
        }

        //to simplify the add4Grids
        private Grid_3x3 add1Grid_3x3(int adjG)
        {
            Grid_3x3 _1grid = new Grid_3x3();

            foreach (Grid_3x3 grid in this.Parent.Parent.Controls)
            {
                if ((int)grid.Tag == adjG)
                {
                    _1grid = grid;
                    break;
                }
            }
            return _1grid;
        }


    }
}
