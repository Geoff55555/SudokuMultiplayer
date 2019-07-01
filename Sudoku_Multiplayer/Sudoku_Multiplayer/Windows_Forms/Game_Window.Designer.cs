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
            this.labelNbrPreview = new System.Windows.Forms.Label();
            this.buttonGenerateRdm = new System.Windows.Forms.Button();
            this.buttonLoadFullGrid_AndHideNbrs = new System.Windows.Forms.Button();
            this.buttonSaveGrid = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Parameters = new System.Windows.Forms.Panel();
            this.panel_NewGameEditor = new System.Windows.Forms.Panel();
            this.comboBox_Difficulty = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label_Static_NewGame = new System.Windows.Forms.Label();
            this.label_Difficulty = new System.Windows.Forms.Label();
            this.radioButton_LoadParty = new System.Windows.Forms.RadioButton();
            this.radioButton_RdmParty = new System.Windows.Forms.RadioButton();
            this.button_FillAndHideRdm = new System.Windows.Forms.Button();
            this.buttonGo = new System.Windows.Forms.Button();
            this.panel_SudokuGrid = new System.Windows.Forms.Panel();
            this.openFileDialog_LoadGrid = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog_SaveGrid = new System.Windows.Forms.SaveFileDialog();
            this.panel_RdmParty = new System.Windows.Forms.Panel();
            this.panel_LoadParty = new System.Windows.Forms.Panel();
            this.button_LoadNbrsToKeep = new System.Windows.Forms.Button();
            this.panel_Parameters.SuspendLayout();
            this.panel_NewGameEditor.SuspendLayout();
            this.panel_RdmParty.SuspendLayout();
            this.panel_LoadParty.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNbrPreview
            // 
            this.labelNbrPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNbrPreview.AutoSize = true;
            this.labelNbrPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNbrPreview.Location = new System.Drawing.Point(37, 131);
            this.labelNbrPreview.MaximumSize = new System.Drawing.Size(227, 32);
            this.labelNbrPreview.MinimumSize = new System.Drawing.Size(227, 32);
            this.labelNbrPreview.Name = "labelNbrPreview";
            this.labelNbrPreview.Size = new System.Drawing.Size(227, 32);
            this.labelNbrPreview.TabIndex = 0;
            this.labelNbrPreview.Text = "Press a number";
            this.labelNbrPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonGenerateRdm
            // 
            this.buttonGenerateRdm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerateRdm.CausesValidation = false;
            this.buttonGenerateRdm.Enabled = false;
            this.buttonGenerateRdm.Location = new System.Drawing.Point(16, 56);
            this.buttonGenerateRdm.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGenerateRdm.Name = "buttonGenerateRdm";
            this.buttonGenerateRdm.Size = new System.Drawing.Size(239, 49);
            this.buttonGenerateRdm.TabIndex = 20;
            this.buttonGenerateRdm.TabStop = false;
            this.buttonGenerateRdm.Text = "Générer une nouvelles grille complète aléatoirement";
            this.buttonGenerateRdm.UseVisualStyleBackColor = true;
            this.buttonGenerateRdm.Click += new System.EventHandler(this.buttonGenerateRdm_Click);
            this.buttonGenerateRdm.Enter += new System.EventHandler(this.NeverFocusButton);
            // 
            // buttonLoadFullGrid_AndHideNbrs
            // 
            this.buttonLoadFullGrid_AndHideNbrs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadFullGrid_AndHideNbrs.CausesValidation = false;
            this.buttonLoadFullGrid_AndHideNbrs.Enabled = false;
            this.buttonLoadFullGrid_AndHideNbrs.Location = new System.Drawing.Point(16, 8);
            this.buttonLoadFullGrid_AndHideNbrs.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLoadFullGrid_AndHideNbrs.Name = "buttonLoadFullGrid_AndHideNbrs";
            this.buttonLoadFullGrid_AndHideNbrs.Size = new System.Drawing.Size(240, 29);
            this.buttonLoadFullGrid_AndHideNbrs.TabIndex = 20;
            this.buttonLoadFullGrid_AndHideNbrs.TabStop = false;
            this.buttonLoadFullGrid_AndHideNbrs.Text = "Charger une grille complète";
            this.buttonLoadFullGrid_AndHideNbrs.UseVisualStyleBackColor = true;
            this.buttonLoadFullGrid_AndHideNbrs.Click += new System.EventHandler(this.buttonLoadFullGrid_AndHideNbrs_Click);
            this.buttonLoadFullGrid_AndHideNbrs.Enter += new System.EventHandler(this.NeverFocusButton);
            // 
            // buttonSaveGrid
            // 
            this.buttonSaveGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveGrid.CausesValidation = false;
            this.buttonSaveGrid.Enabled = false;
            this.buttonSaveGrid.Location = new System.Drawing.Point(16, 113);
            this.buttonSaveGrid.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveGrid.Name = "buttonSaveGrid";
            this.buttonSaveGrid.Size = new System.Drawing.Size(240, 33);
            this.buttonSaveGrid.TabIndex = 20;
            this.buttonSaveGrid.TabStop = false;
            this.buttonSaveGrid.Text = "Enregistrer la grille complète";
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
            this.label1.Location = new System.Drawing.Point(48, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number Preview";
            // 
            // panel_Parameters
            // 
            this.panel_Parameters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Parameters.Controls.Add(this.panel_NewGameEditor);
            this.panel_Parameters.Controls.Add(this.label1);
            this.panel_Parameters.Controls.Add(this.labelNbrPreview);
            this.panel_Parameters.Controls.Add(this.buttonGo);
            this.panel_Parameters.Location = new System.Drawing.Point(699, 12);
            this.panel_Parameters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Parameters.Name = "panel_Parameters";
            this.panel_Parameters.Size = new System.Drawing.Size(302, 665);
            this.panel_Parameters.TabIndex = 31;
            // 
            // panel_NewGameEditor
            // 
            this.panel_NewGameEditor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_NewGameEditor.Controls.Add(this.panel_LoadParty);
            this.panel_NewGameEditor.Controls.Add(this.panel_RdmParty);
            this.panel_NewGameEditor.Controls.Add(this.label_Static_NewGame);
            this.panel_NewGameEditor.Controls.Add(this.radioButton_LoadParty);
            this.panel_NewGameEditor.Controls.Add(this.radioButton_RdmParty);
            this.panel_NewGameEditor.Location = new System.Drawing.Point(8, 185);
            this.panel_NewGameEditor.Name = "panel_NewGameEditor";
            this.panel_NewGameEditor.Size = new System.Drawing.Size(281, 466);
            this.panel_NewGameEditor.TabIndex = 0;
            // 
            // comboBox_Difficulty
            // 
            this.comboBox_Difficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Difficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Difficulty.Enabled = false;
            this.comboBox_Difficulty.FormattingEnabled = true;
            this.comboBox_Difficulty.Items.AddRange(new object[] {
            "1",
            "3",
            "5"});
            this.comboBox_Difficulty.Location = new System.Drawing.Point(16, 26);
            this.comboBox_Difficulty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Difficulty.Name = "comboBox_Difficulty";
            this.comboBox_Difficulty.Size = new System.Drawing.Size(239, 24);
            this.comboBox_Difficulty.TabIndex = 32;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.CausesValidation = false;
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(17, 79);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(239, 38);
            this.button3.TabIndex = 30;
            this.button3.TabStop = false;
            this.button3.Text = "LANCER LA PARTIE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonFill_Click);
            this.button3.Enter += new System.EventHandler(this.NeverFocusButton);
            // 
            // label_Static_NewGame
            // 
            this.label_Static_NewGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Static_NewGame.AutoSize = true;
            this.label_Static_NewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Static_NewGame.Location = new System.Drawing.Point(71, 0);
            this.label_Static_NewGame.MaximumSize = new System.Drawing.Size(140, 17);
            this.label_Static_NewGame.MinimumSize = new System.Drawing.Size(140, 17);
            this.label_Static_NewGame.Name = "label_Static_NewGame";
            this.label_Static_NewGame.Size = new System.Drawing.Size(140, 17);
            this.label_Static_NewGame.TabIndex = 31;
            this.label_Static_NewGame.Text = "Nouvelle Partie";
            this.label_Static_NewGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Difficulty
            // 
            this.label_Difficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Difficulty.AutoSize = true;
            this.label_Difficulty.Enabled = false;
            this.label_Difficulty.Location = new System.Drawing.Point(105, 7);
            this.label_Difficulty.MaximumSize = new System.Drawing.Size(62, 17);
            this.label_Difficulty.MinimumSize = new System.Drawing.Size(62, 17);
            this.label_Difficulty.Name = "label_Difficulty";
            this.label_Difficulty.Size = new System.Drawing.Size(62, 17);
            this.label_Difficulty.TabIndex = 31;
            this.label_Difficulty.Text = "Difficulté";
            this.label_Difficulty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton_LoadParty
            // 
            this.radioButton_LoadParty.AutoSize = true;
            this.radioButton_LoadParty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_LoadParty.Location = new System.Drawing.Point(19, 312);
            this.radioButton_LoadParty.Name = "radioButton_LoadParty";
            this.radioButton_LoadParty.Size = new System.Drawing.Size(169, 24);
            this.radioButton_LoadParty.TabIndex = 0;
            this.radioButton_LoadParty.TabStop = true;
            this.radioButton_LoadParty.Text = "Charger une partie";
            this.radioButton_LoadParty.UseVisualStyleBackColor = true;
            this.radioButton_LoadParty.CheckedChanged += new System.EventHandler(this.radioButton_LoadParty_CheckedChanged);
            // 
            // radioButton_RdmParty
            // 
            this.radioButton_RdmParty.AutoSize = true;
            this.radioButton_RdmParty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_RdmParty.Location = new System.Drawing.Point(19, 28);
            this.radioButton_RdmParty.Name = "radioButton_RdmParty";
            this.radioButton_RdmParty.Size = new System.Drawing.Size(145, 24);
            this.radioButton_RdmParty.TabIndex = 0;
            this.radioButton_RdmParty.TabStop = true;
            this.radioButton_RdmParty.Text = "Partie Aléatoire";
            this.radioButton_RdmParty.UseVisualStyleBackColor = true;
            this.radioButton_RdmParty.CheckedChanged += new System.EventHandler(this.radioButton_RdmParty_CheckedChanged);
            // 
            // button_FillAndHideRdm
            // 
            this.button_FillAndHideRdm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_FillAndHideRdm.CausesValidation = false;
            this.button_FillAndHideRdm.Enabled = false;
            this.button_FillAndHideRdm.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_FillAndHideRdm.Location = new System.Drawing.Point(16, 154);
            this.button_FillAndHideRdm.Margin = new System.Windows.Forms.Padding(4);
            this.button_FillAndHideRdm.Name = "button_FillAndHideRdm";
            this.button_FillAndHideRdm.Size = new System.Drawing.Size(239, 78);
            this.button_FillAndHideRdm.TabIndex = 30;
            this.button_FillAndHideRdm.TabStop = false;
            this.button_FillAndHideRdm.Text = "LANCER LA PARTIE";
            this.button_FillAndHideRdm.UseVisualStyleBackColor = true;
            this.button_FillAndHideRdm.Click += new System.EventHandler(this.buttonFillAndHideRdm_Click);
            this.button_FillAndHideRdm.Enter += new System.EventHandler(this.NeverFocusButton);
            // 
            // buttonGo
            // 
            this.buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGo.CausesValidation = false;
            this.buttonGo.Enabled = false;
            this.buttonGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGo.Location = new System.Drawing.Point(8, 16);
            this.buttonGo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(281, 53);
            this.buttonGo.TabIndex = 10;
            this.buttonGo.TabStop = false;
            this.buttonGo.Text = "PLAY";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            this.buttonGo.Enter += new System.EventHandler(this.NeverFocusButton);
            // 
            // panel_SudokuGrid
            // 
            this.panel_SudokuGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_SudokuGrid.Location = new System.Drawing.Point(12, 12);
            this.panel_SudokuGrid.MaximumSize = new System.Drawing.Size(665, 665);
            this.panel_SudokuGrid.MinimumSize = new System.Drawing.Size(665, 665);
            this.panel_SudokuGrid.Name = "panel_SudokuGrid";
            this.panel_SudokuGrid.Size = new System.Drawing.Size(665, 665);
            this.panel_SudokuGrid.TabIndex = 32;
            // 
            // openFileDialog_LoadGrid
            // 
            this.openFileDialog_LoadGrid.FileName = "openFileDialog";
            // 
            // panel_RdmParty
            // 
            this.panel_RdmParty.Controls.Add(this.comboBox_Difficulty);
            this.panel_RdmParty.Controls.Add(this.button_FillAndHideRdm);
            this.panel_RdmParty.Controls.Add(this.buttonGenerateRdm);
            this.panel_RdmParty.Controls.Add(this.label_Difficulty);
            this.panel_RdmParty.Controls.Add(this.buttonSaveGrid);
            this.panel_RdmParty.Enabled = false;
            this.panel_RdmParty.Location = new System.Drawing.Point(3, 53);
            this.panel_RdmParty.Name = "panel_RdmParty";
            this.panel_RdmParty.Size = new System.Drawing.Size(271, 246);
            this.panel_RdmParty.TabIndex = 0;
            // 
            // panel_LoadParty
            // 
            this.panel_LoadParty.Controls.Add(this.button_LoadNbrsToKeep);
            this.panel_LoadParty.Controls.Add(this.buttonLoadFullGrid_AndHideNbrs);
            this.panel_LoadParty.Controls.Add(this.button3);
            this.panel_LoadParty.Enabled = false;
            this.panel_LoadParty.Location = new System.Drawing.Point(3, 335);
            this.panel_LoadParty.Name = "panel_LoadParty";
            this.panel_LoadParty.Size = new System.Drawing.Size(271, 121);
            this.panel_LoadParty.TabIndex = 0;
            // 
            // button_LoadNbrsToKeep
            // 
            this.button_LoadNbrsToKeep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_LoadNbrsToKeep.CausesValidation = false;
            this.button_LoadNbrsToKeep.Enabled = false;
            this.button_LoadNbrsToKeep.Location = new System.Drawing.Point(16, 42);
            this.button_LoadNbrsToKeep.Margin = new System.Windows.Forms.Padding(4);
            this.button_LoadNbrsToKeep.Name = "button_LoadNbrsToKeep";
            this.button_LoadNbrsToKeep.Size = new System.Drawing.Size(240, 29);
            this.button_LoadNbrsToKeep.TabIndex = 20;
            this.button_LoadNbrsToKeep.TabStop = false;
            this.button_LoadNbrsToKeep.Text = "Charger les nombres à garder";
            this.button_LoadNbrsToKeep.UseVisualStyleBackColor = true;
            this.button_LoadNbrsToKeep.Click += new System.EventHandler(this.button_LoadNbrsToKeep_Click);
            this.button_LoadNbrsToKeep.Enter += new System.EventHandler(this.NeverFocusButton);
            // 
            // Game_Window
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1020, 688);
            this.Controls.Add(this.panel_SudokuGrid);
            this.Controls.Add(this.panel_Parameters);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Game_Window";
            this.Text = "Sudoku Multiplayer";
            this.panel_Parameters.ResumeLayout(false);
            this.panel_Parameters.PerformLayout();
            this.panel_NewGameEditor.ResumeLayout(false);
            this.panel_NewGameEditor.PerformLayout();
            this.panel_RdmParty.ResumeLayout(false);
            this.panel_RdmParty.PerformLayout();
            this.panel_LoadParty.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelNbrPreview;
        private System.Windows.Forms.Button buttonGenerateRdm;
        private System.Windows.Forms.Button buttonLoadFullGrid_AndHideNbrs;
        private System.Windows.Forms.Button buttonSaveGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_Parameters;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.ComboBox comboBox_Difficulty;
        private System.Windows.Forms.Label label_Difficulty;
        private System.Windows.Forms.Panel panel_SudokuGrid;
        private System.Windows.Forms.OpenFileDialog openFileDialog_LoadGrid;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_SaveGrid;
        private System.Windows.Forms.Panel panel_NewGameEditor;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label_Static_NewGame;
        private System.Windows.Forms.RadioButton radioButton_RdmParty;
        private System.Windows.Forms.Button button_FillAndHideRdm;
        private System.Windows.Forms.RadioButton radioButton_LoadParty;
        private System.Windows.Forms.Panel panel_LoadParty;
        private System.Windows.Forms.Panel panel_RdmParty;
        private System.Windows.Forms.Button button_LoadNbrsToKeep;
    }
}

