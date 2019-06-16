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
            this.buttonFill = new System.Windows.Forms.Button();
            this.buttonHide = new System.Windows.Forms.Button();
            this.labelNbrPreview = new System.Windows.Forms.Label();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonLoadGrid = new System.Windows.Forms.Button();
            this.buttonSaveGrid = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonFill
            // 
            this.buttonFill.CausesValidation = false;
            this.buttonFill.Location = new System.Drawing.Point(212, 162);
            this.buttonFill.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFill.Name = "buttonFill";
            this.buttonFill.Size = new System.Drawing.Size(177, 53);
            this.buttonFill.TabIndex = 30;
            this.buttonFill.TabStop = false;
            this.buttonFill.Text = "Fill that grid";
            this.buttonFill.UseVisualStyleBackColor = true;
            this.buttonFill.Click += new System.EventHandler(this.buttonFill_Click);
            this.buttonFill.Enter += new System.EventHandler(this.NeverFocusButton);
            // 
            // buttonHide
            // 
            this.buttonHide.CausesValidation = false;
            this.buttonHide.Location = new System.Drawing.Point(212, 251);
            this.buttonHide.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(177, 53);
            this.buttonHide.TabIndex = 10;
            this.buttonHide.TabStop = false;
            this.buttonHide.Text = "Hide Randomly";
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            this.buttonHide.Enter += new System.EventHandler(this.NeverFocusButton);
            // 
            // labelNbrPreview
            // 
            this.labelNbrPreview.AutoSize = true;
            this.labelNbrPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNbrPreview.Location = new System.Drawing.Point(206, 366);
            this.labelNbrPreview.Name = "labelNbrPreview";
            this.labelNbrPreview.Size = new System.Drawing.Size(0, 32);
            this.labelNbrPreview.TabIndex = 0;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.CausesValidation = false;
            this.buttonGenerate.Location = new System.Drawing.Point(212, 5);
            this.buttonGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(177, 53);
            this.buttonGenerate.TabIndex = 20;
            this.buttonGenerate.TabStop = false;
            this.buttonGenerate.Text = "Generate Sudoku grid";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            this.buttonGenerate.Enter += new System.EventHandler(this.NeverFocusButton);
            // 
            // buttonLoadGrid
            // 
            this.buttonLoadGrid.CausesValidation = false;
            this.buttonLoadGrid.Location = new System.Drawing.Point(212, 81);
            this.buttonLoadGrid.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLoadGrid.Name = "buttonLoadGrid";
            this.buttonLoadGrid.Size = new System.Drawing.Size(177, 53);
            this.buttonLoadGrid.TabIndex = 20;
            this.buttonLoadGrid.TabStop = false;
            this.buttonLoadGrid.Text = "Load grid";
            this.buttonLoadGrid.UseVisualStyleBackColor = true;
            this.buttonLoadGrid.Click += new System.EventHandler(this.buttonLoadGrid_Click);
            this.buttonLoadGrid.Enter += new System.EventHandler(this.NeverFocusButton);
            // 
            // buttonSaveGrid
            // 
            this.buttonSaveGrid.CausesValidation = false;
            this.buttonSaveGrid.Location = new System.Drawing.Point(17, 81);
            this.buttonSaveGrid.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveGrid.Name = "buttonSaveGrid";
            this.buttonSaveGrid.Size = new System.Drawing.Size(177, 53);
            this.buttonSaveGrid.TabIndex = 20;
            this.buttonSaveGrid.TabStop = false;
            this.buttonSaveGrid.Text = "Save grid";
            this.buttonSaveGrid.UseVisualStyleBackColor = true;
            this.buttonSaveGrid.Click += new System.EventHandler(this.buttonSaveGrid_Click);
            this.buttonSaveGrid.Enter += new System.EventHandler(this.NeverFocusButton);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(206, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number Preview";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSaveGrid);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonFill);
            this.panel1.Controls.Add(this.labelNbrPreview);
            this.panel1.Controls.Add(this.buttonGenerate);
            this.panel1.Controls.Add(this.buttonHide);
            this.panel1.Controls.Add(this.buttonLoadGrid);
            this.panel1.Location = new System.Drawing.Point(797, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 456);
            this.panel1.TabIndex = 31;
            // 
            // Game_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1218, 690);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Game_Window";
            this.Text = "Sudoku Multiplayer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFill;
        private System.Windows.Forms.Button buttonHide;
        private System.Windows.Forms.Label labelNbrPreview;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonLoadGrid;
        private System.Windows.Forms.Button buttonSaveGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}

