using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Multiplayer.Classes
{
    class Sudoku_Numb_Label : Label
    {
        public int[] casePos = new int[2];
        //Constructor for generated Grid
        public Sudoku_Numb_Label(int row, int column)
        {
            //Set tag for future identification
            casePos[0] = row;
            casePos[1] = column;
            this.Tag = casePos;
            //Set font size
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.Size = new System.Drawing.Size(this.Parent.Width, this.Parent.Height);

            //Make it fill its container
            this.Dock = System.Windows.Forms.DockStyle.Fill;

            //Set Location
            //this.Location = new System.Drawing.Point(0, 0); //if i fills the container, location has no more sense

            //Set alignment
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //Set Text : Random Number
            //Complete_Sudoku_Grid_Generator Generated_Grid = new Complete_Sudoku_Grid_Generator();
            //this.Text = Generated_Grid(xPos, yPos);
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
    }
}
