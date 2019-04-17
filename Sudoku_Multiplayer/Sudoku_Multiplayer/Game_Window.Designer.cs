namespace Sudoku_Multiplayer
{
    partial class Game_Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel_Sudoku_Grid = new System.Windows.Forms.TableLayoutPanel();
            this.Number1_1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel_Sudoku_Grid.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_Sudoku_Grid
            // 
            this.tableLayoutPanel_Sudoku_Grid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel_Sudoku_Grid.ColumnCount = 3;
            this.tableLayoutPanel_Sudoku_Grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Sudoku_Grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Sudoku_Grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Sudoku_Grid.Controls.Add(this.Number1_1, 0, 0);
            this.tableLayoutPanel_Sudoku_Grid.Location = new System.Drawing.Point(660, 198);
            this.tableLayoutPanel_Sudoku_Grid.Name = "tableLayoutPanel_Sudoku_Grid";
            this.tableLayoutPanel_Sudoku_Grid.RowCount = 3;
            this.tableLayoutPanel_Sudoku_Grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Sudoku_Grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Sudoku_Grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Sudoku_Grid.Size = new System.Drawing.Size(209, 203);
            this.tableLayoutPanel_Sudoku_Grid.TabIndex = 0;
            // 
            // Number1_1
            // 
            this.Number1_1.AutoSize = true;
            this.Number1_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Number1_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Number1_1.Location = new System.Drawing.Point(6, 3);
            this.Number1_1.Name = "Number1_1";
            this.Number1_1.Size = new System.Drawing.Size(59, 63);
            this.Number1_1.TabIndex = 0;
            this.Number1_1.Text = "1";
            this.Number1_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Game_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1406, 1055);
            this.Controls.Add(this.tableLayoutPanel_Sudoku_Grid);
            this.Name = "Game_Window";
            this.Text = "Sudoku Multiplayer";
            this.tableLayoutPanel_Sudoku_Grid.ResumeLayout(false);
            this.tableLayoutPanel_Sudoku_Grid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Sudoku_Grid;
        private System.Windows.Forms.Label Number1_1;
    }
}

