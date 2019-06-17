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
            this.buttonGo = new System.Windows.Forms.Button();
            this.comboBox_Difficulty = new System.Windows.Forms.ComboBox();
            this.label_Difficulty = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonFill
            // 
            this.buttonFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFill.CausesValidation = false;
            this.buttonFill.Enabled = false;
            this.buttonFill.Location = new System.Drawing.Point(10, 445);
            this.buttonFill.Name = "buttonFill";
            this.buttonFill.Size = new System.Drawing.Size(178, 43);
            this.buttonFill.TabIndex = 30;
            this.buttonFill.TabStop = false;
            this.buttonFill.Text = "Fill that grid";
            this.buttonFill.UseVisualStyleBackColor = true;
            this.buttonFill.Click += new System.EventHandler(this.buttonFill_Click);
            this.buttonFill.Enter += new System.EventHandler(this.NeverFocusButton);
            // 
            // buttonHide
            // 
            this.buttonHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHide.CausesValidation = false;
            this.buttonHide.Enabled = false;
            this.buttonHide.Location = new System.Drawing.Point(10, 494);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(178, 43);
            this.buttonHide.TabIndex = 10;
            this.buttonHide.TabStop = false;
            this.buttonHide.Text = "Hide Randomly";
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            this.buttonHide.Enter += new System.EventHandler(this.NeverFocusButton);
            // 
            // labelNbrPreview
            // 
            this.labelNbrPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNbrPreview.AutoSize = true;
            this.labelNbrPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNbrPreview.Location = new System.Drawing.Point(92, 113);
            this.labelNbrPreview.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNbrPreview.Name = "labelNbrPreview";
            this.labelNbrPreview.Size = new System.Drawing.Size(0, 26);
            this.labelNbrPreview.TabIndex = 0;
            this.labelNbrPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerate.CausesValidation = false;
            this.buttonGenerate.Enabled = false;
            this.buttonGenerate.Location = new System.Drawing.Point(10, 347);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(178, 43);
            this.buttonGenerate.TabIndex = 20;
            this.buttonGenerate.TabStop = false;
            this.buttonGenerate.Text = "Generate New Sudoku grid";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            this.buttonGenerate.Enter += new System.EventHandler(this.NeverFocusButton);
            // 
            // buttonLoadGrid
            // 
            this.buttonLoadGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadGrid.CausesValidation = false;
            this.buttonLoadGrid.Enabled = false;
            this.buttonLoadGrid.Location = new System.Drawing.Point(103, 396);
            this.buttonLoadGrid.Name = "buttonLoadGrid";
            this.buttonLoadGrid.Size = new System.Drawing.Size(85, 43);
            this.buttonLoadGrid.TabIndex = 20;
            this.buttonLoadGrid.TabStop = false;
            this.buttonLoadGrid.Text = "Load grid";
            this.buttonLoadGrid.UseVisualStyleBackColor = true;
            this.buttonLoadGrid.Click += new System.EventHandler(this.buttonLoadGrid_Click);
            this.buttonLoadGrid.Enter += new System.EventHandler(this.NeverFocusButton);
            // 
            // buttonSaveGrid
            // 
            this.buttonSaveGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveGrid.CausesValidation = false;
            this.buttonSaveGrid.Enabled = false;
            this.buttonSaveGrid.Location = new System.Drawing.Point(10, 396);
            this.buttonSaveGrid.Name = "buttonSaveGrid";
            this.buttonSaveGrid.Size = new System.Drawing.Size(85, 43);
            this.buttonSaveGrid.TabIndex = 20;
            this.buttonSaveGrid.TabStop = false;
            this.buttonSaveGrid.Text = "Save grid";
            this.buttonSaveGrid.UseVisualStyleBackColor = true;
            this.buttonSaveGrid.Click += new System.EventHandler(this.buttonSaveGrid_Click);
            this.buttonSaveGrid.Enter += new System.EventHandler(this.NeverFocusButton);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(20, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number Preview";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox_Difficulty);
            this.panel1.Controls.Add(this.label_Difficulty);
            this.panel1.Controls.Add(this.buttonSaveGrid);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonFill);
            this.panel1.Controls.Add(this.labelNbrPreview);
            this.panel1.Controls.Add(this.buttonGenerate);
            this.panel1.Controls.Add(this.buttonGo);
            this.panel1.Controls.Add(this.buttonHide);
            this.panel1.Controls.Add(this.buttonLoadGrid);
            this.panel1.Location = new System.Drawing.Point(711, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 540);
            this.panel1.TabIndex = 31;
            // 
            // buttonGo
            // 
            this.buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGo.CausesValidation = false;
            this.buttonGo.Enabled = false;
            this.buttonGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGo.Location = new System.Drawing.Point(10, 13);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(178, 43);
            this.buttonGo.TabIndex = 10;
            this.buttonGo.TabStop = false;
            this.buttonGo.Text = "PLAY";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            this.buttonGo.Enter += new System.EventHandler(this.NeverFocusButton);
            // 
            // comboBox_Difficulty
            // 
            this.comboBox_Difficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Difficulty.Enabled = false;
            this.comboBox_Difficulty.FormattingEnabled = true;
            this.comboBox_Difficulty.Items.AddRange(new object[] {
            "1",
            "3",
            "5"});
            this.comboBox_Difficulty.Location = new System.Drawing.Point(10, 321);
            this.comboBox_Difficulty.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Difficulty.Name = "comboBox_Difficulty";
            this.comboBox_Difficulty.Size = new System.Drawing.Size(178, 21);
            this.comboBox_Difficulty.TabIndex = 32;
            // 
            // label_Difficulty
            // 
            this.label_Difficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Difficulty.AutoSize = true;
            this.label_Difficulty.Enabled = false;
            this.label_Difficulty.Location = new System.Drawing.Point(53, 297);
            this.label_Difficulty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Difficulty.Name = "label_Difficulty";
            this.label_Difficulty.Size = new System.Drawing.Size(98, 13);
            this.label_Difficulty.TabIndex = 31;
            this.label_Difficulty.Text = "Niveau de difficulté";
            // 
            // Game_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(914, 561);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.ComboBox comboBox_Difficulty;
        private System.Windows.Forms.Label label_Difficulty;
    }
}

