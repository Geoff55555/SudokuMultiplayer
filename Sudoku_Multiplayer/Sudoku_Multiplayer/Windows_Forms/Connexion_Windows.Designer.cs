namespace Sudoku_Multiplayer
{
    partial class Connexion_Windows
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
            this.panelHost = new System.Windows.Forms.Panel();
            this.label_Status_CoToClient = new System.Windows.Forms.Label();
            this.button_OpenConnexionToClient = new System.Windows.Forms.Button();
            this.label_IPHost = new System.Windows.Forms.Label();
            this.textBox_HostPortChosen = new System.Windows.Forms.TextBox();
            this.label_StaticClientState = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_StaticIPHost = new System.Windows.Forms.Label();
            this.panelClient = new System.Windows.Forms.Panel();
            this.label_Status_CoToHost = new System.Windows.Forms.Label();
            this.buttonConnectToHost = new System.Windows.Forms.Button();
            this.textBox_IP_X4 = new System.Windows.Forms.TextBox();
            this.textBox_IP_X3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_IP_X2 = new System.Windows.Forms.TextBox();
            this.textBox_HostPort = new System.Windows.Forms.TextBox();
            this.textBox_IP_X1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Point = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_StaticEnterIPHost = new System.Windows.Forms.Label();
            this.radioButtonHost = new System.Windows.Forms.RadioButton();
            this.radioButtonClient = new System.Windows.Forms.RadioButton();
            this.buttonReady = new System.Windows.Forms.Button();
            this.panel_Player = new System.Windows.Forms.Panel();
            this.label_MsgReceived = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_NameConnectedPlayer = new System.Windows.Forms.Label();
            this.label_NameOtherPlayer = new System.Windows.Forms.Label();
            this.label_Static_NamePlayer = new System.Windows.Forms.Label();
            this.textBox_Msg = new System.Windows.Forms.TextBox();
            this.textBox_NamePlayer = new System.Windows.Forms.TextBox();
            this.label_Static_DiscussWith = new System.Windows.Forms.Label();
            this.panel_Config = new System.Windows.Forms.Panel();
            this.comboBox_Difficulty = new System.Windows.Forms.ComboBox();
            this.comboBox_GameMode = new System.Windows.Forms.ComboBox();
            this.label_GameMode = new System.Windows.Forms.Label();
            this.label_Difficulty = new System.Windows.Forms.Label();
            this.panelHost.SuspendLayout();
            this.panelClient.SuspendLayout();
            this.panel_Player.SuspendLayout();
            this.panel_Config.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHost
            // 
            this.panelHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHost.Controls.Add(this.label_Status_CoToClient);
            this.panelHost.Controls.Add(this.button_OpenConnexionToClient);
            this.panelHost.Controls.Add(this.label_IPHost);
            this.panelHost.Controls.Add(this.textBox_HostPortChosen);
            this.panelHost.Controls.Add(this.label_StaticClientState);
            this.panelHost.Controls.Add(this.label2);
            this.panelHost.Controls.Add(this.label_StaticIPHost);
            this.panelHost.Enabled = false;
            this.panelHost.Location = new System.Drawing.Point(11, 50);
            this.panelHost.Name = "panelHost";
            this.panelHost.Size = new System.Drawing.Size(539, 140);
            this.panelHost.TabIndex = 0;
            // 
            // label_Status_CoToClient
            // 
            this.label_Status_CoToClient.AutoSize = true;
            this.label_Status_CoToClient.Location = new System.Drawing.Point(169, 112);
            this.label_Status_CoToClient.Name = "label_Status_CoToClient";
            this.label_Status_CoToClient.Size = new System.Drawing.Size(239, 17);
            this.label_Status_CoToClient.TabIndex = 0;
            this.label_Status_CoToClient.Text = "Choisir un port et ouvrir la connexion";
            // 
            // button_OpenConnexionToClient
            // 
            this.button_OpenConnexionToClient.Location = new System.Drawing.Point(162, 63);
            this.button_OpenConnexionToClient.Name = "button_OpenConnexionToClient";
            this.button_OpenConnexionToClient.Size = new System.Drawing.Size(174, 29);
            this.button_OpenConnexionToClient.TabIndex = 5;
            this.button_OpenConnexionToClient.Text = "Ouvrir la connexion";
            this.button_OpenConnexionToClient.UseVisualStyleBackColor = true;
            this.button_OpenConnexionToClient.Click += new System.EventHandler(this.button_OpenConnexionToClient_Click);
            // 
            // label_IPHost
            // 
            this.label_IPHost.AutoSize = true;
            this.label_IPHost.Location = new System.Drawing.Point(138, 20);
            this.label_IPHost.Name = "label_IPHost";
            this.label_IPHost.Size = new System.Drawing.Size(56, 17);
            this.label_IPHost.TabIndex = 0;
            this.label_IPHost.Text = "X.X.X.X";
            // 
            // textBox_HostPortChosen
            // 
            this.textBox_HostPortChosen.Location = new System.Drawing.Point(379, 17);
            this.textBox_HostPortChosen.MaxLength = 4;
            this.textBox_HostPortChosen.Name = "textBox_HostPortChosen";
            this.textBox_HostPortChosen.Size = new System.Drawing.Size(61, 22);
            this.textBox_HostPortChosen.TabIndex = 3;
            this.textBox_HostPortChosen.Text = "1025";
            // 
            // label_StaticClientState
            // 
            this.label_StaticClientState.AutoSize = true;
            this.label_StaticClientState.Location = new System.Drawing.Point(17, 112);
            this.label_StaticClientState.Name = "label_StaticClientState";
            this.label_StaticClientState.Size = new System.Drawing.Size(146, 17);
            this.label_StaticClientState.TabIndex = 0;
            this.label_StaticClientState.Text = "Etat connexion invité :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mon port :";
            // 
            // label_StaticIPHost
            // 
            this.label_StaticIPHost.AutoSize = true;
            this.label_StaticIPHost.Location = new System.Drawing.Point(18, 20);
            this.label_StaticIPHost.Name = "label_StaticIPHost";
            this.label_StaticIPHost.Size = new System.Drawing.Size(114, 17);
            this.label_StaticIPHost.TabIndex = 0;
            this.label_StaticIPHost.Text = "Mon adresse IP :";
            // 
            // panelClient
            // 
            this.panelClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelClient.Controls.Add(this.label_Status_CoToHost);
            this.panelClient.Controls.Add(this.buttonConnectToHost);
            this.panelClient.Controls.Add(this.textBox_IP_X4);
            this.panelClient.Controls.Add(this.textBox_IP_X3);
            this.panelClient.Controls.Add(this.label5);
            this.panelClient.Controls.Add(this.textBox_IP_X2);
            this.panelClient.Controls.Add(this.textBox_HostPort);
            this.panelClient.Controls.Add(this.textBox_IP_X1);
            this.panelClient.Controls.Add(this.label3);
            this.panelClient.Controls.Add(this.label1);
            this.panelClient.Controls.Add(this.label_Point);
            this.panelClient.Controls.Add(this.label4);
            this.panelClient.Controls.Add(this.label_StaticEnterIPHost);
            this.panelClient.Enabled = false;
            this.panelClient.Location = new System.Drawing.Point(12, 263);
            this.panelClient.Name = "panelClient";
            this.panelClient.Size = new System.Drawing.Size(538, 219);
            this.panelClient.TabIndex = 1;
            // 
            // label_Status_CoToHost
            // 
            this.label_Status_CoToHost.AutoSize = true;
            this.label_Status_CoToHost.Location = new System.Drawing.Point(181, 178);
            this.label_Status_CoToHost.Name = "label_Status_CoToHost";
            this.label_Status_CoToHost.Size = new System.Drawing.Size(214, 17);
            this.label_Status_CoToHost.TabIndex = 0;
            this.label_Status_CoToHost.Text = "Entrer les coordonnées de l\'hôte";
            // 
            // buttonConnectToHost
            // 
            this.buttonConnectToHost.Location = new System.Drawing.Point(161, 117);
            this.buttonConnectToHost.Name = "buttonConnectToHost";
            this.buttonConnectToHost.Size = new System.Drawing.Size(174, 29);
            this.buttonConnectToHost.TabIndex = 5;
            this.buttonConnectToHost.Text = "Se connecter";
            this.buttonConnectToHost.UseVisualStyleBackColor = true;
            this.buttonConnectToHost.Click += new System.EventHandler(this.buttonConnectToHost_Click);
            // 
            // textBox_IP_X4
            // 
            this.textBox_IP_X4.Location = new System.Drawing.Point(413, 14);
            this.textBox_IP_X4.MaxLength = 3;
            this.textBox_IP_X4.Name = "textBox_IP_X4";
            this.textBox_IP_X4.Size = new System.Drawing.Size(61, 22);
            this.textBox_IP_X4.TabIndex = 3;
            this.textBox_IP_X4.Text = "46";
            // 
            // textBox_IP_X3
            // 
            this.textBox_IP_X3.Location = new System.Drawing.Point(328, 15);
            this.textBox_IP_X3.MaxLength = 3;
            this.textBox_IP_X3.Name = "textBox_IP_X3";
            this.textBox_IP_X3.Size = new System.Drawing.Size(61, 22);
            this.textBox_IP_X3.TabIndex = 2;
            this.textBox_IP_X3.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Etat connexion à l\'hôte :";
            // 
            // textBox_IP_X2
            // 
            this.textBox_IP_X2.Location = new System.Drawing.Point(243, 15);
            this.textBox_IP_X2.MaxLength = 3;
            this.textBox_IP_X2.Name = "textBox_IP_X2";
            this.textBox_IP_X2.Size = new System.Drawing.Size(61, 22);
            this.textBox_IP_X2.TabIndex = 1;
            this.textBox_IP_X2.Text = "168";
            // 
            // textBox_HostPort
            // 
            this.textBox_HostPort.Location = new System.Drawing.Point(157, 66);
            this.textBox_HostPort.MaxLength = 4;
            this.textBox_HostPort.Name = "textBox_HostPort";
            this.textBox_HostPort.Size = new System.Drawing.Size(61, 22);
            this.textBox_HostPort.TabIndex = 4;
            this.textBox_HostPort.Text = "1025";
            // 
            // textBox_IP_X1
            // 
            this.textBox_IP_X1.Location = new System.Drawing.Point(158, 15);
            this.textBox_IP_X1.MaxLength = 3;
            this.textBox_IP_X1.Name = "textBox_IP_X1";
            this.textBox_IP_X1.Size = new System.Drawing.Size(61, 22);
            this.textBox_IP_X1.TabIndex = 0;
            this.textBox_IP_X1.Text = "192";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(395, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = ".";
            // 
            // label_Point
            // 
            this.label_Point.AutoSize = true;
            this.label_Point.Location = new System.Drawing.Point(225, 15);
            this.label_Point.Name = "label_Point";
            this.label_Point.Size = new System.Drawing.Size(12, 17);
            this.label_Point.TabIndex = 0;
            this.label_Point.Text = ".";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Entrer l\'IP de l\'hôte :";
            // 
            // label_StaticEnterIPHost
            // 
            this.label_StaticEnterIPHost.AutoSize = true;
            this.label_StaticEnterIPHost.Location = new System.Drawing.Point(17, 18);
            this.label_StaticEnterIPHost.Name = "label_StaticEnterIPHost";
            this.label_StaticEnterIPHost.Size = new System.Drawing.Size(135, 17);
            this.label_StaticEnterIPHost.TabIndex = 6;
            this.label_StaticEnterIPHost.Text = "Entrer l\'IP de l\'hôte :";
            // 
            // radioButtonHost
            // 
            this.radioButtonHost.AutoSize = true;
            this.radioButtonHost.Location = new System.Drawing.Point(12, 23);
            this.radioButtonHost.Name = "radioButtonHost";
            this.radioButtonHost.Size = new System.Drawing.Size(149, 21);
            this.radioButtonHost.TabIndex = 2;
            this.radioButtonHost.Text = "J\'accueille la partie";
            this.radioButtonHost.UseVisualStyleBackColor = true;
            this.radioButtonHost.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radioButtonHost_MouseDown);
            // 
            // radioButtonClient
            // 
            this.radioButtonClient.AutoSize = true;
            this.radioButtonClient.Location = new System.Drawing.Point(11, 236);
            this.radioButtonClient.Name = "radioButtonClient";
            this.radioButtonClient.Size = new System.Drawing.Size(145, 21);
            this.radioButtonClient.TabIndex = 2;
            this.radioButtonClient.Text = "Je rejoins la partie";
            this.radioButtonClient.UseVisualStyleBackColor = true;
            this.radioButtonClient.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radioButtonClient_MouseDown);
            // 
            // buttonReady
            // 
            this.buttonReady.Enabled = false;
            this.buttonReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReady.Location = new System.Drawing.Point(828, 50);
            this.buttonReady.Name = "buttonReady";
            this.buttonReady.Size = new System.Drawing.Size(128, 432);
            this.buttonReady.TabIndex = 1;
            this.buttonReady.Text = "Je suis prêt !";
            this.buttonReady.UseVisualStyleBackColor = true;
            this.buttonReady.Click += new System.EventHandler(this.buttonReady_Click);
            // 
            // panel_Player
            // 
            this.panel_Player.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Player.Controls.Add(this.label_MsgReceived);
            this.panel_Player.Controls.Add(this.label6);
            this.panel_Player.Controls.Add(this.label_NameConnectedPlayer);
            this.panel_Player.Controls.Add(this.label_NameOtherPlayer);
            this.panel_Player.Controls.Add(this.label_Static_NamePlayer);
            this.panel_Player.Controls.Add(this.textBox_Msg);
            this.panel_Player.Controls.Add(this.textBox_NamePlayer);
            this.panel_Player.Controls.Add(this.label_Static_DiscussWith);
            this.panel_Player.Enabled = false;
            this.panel_Player.Location = new System.Drawing.Point(570, 196);
            this.panel_Player.Name = "panel_Player";
            this.panel_Player.Size = new System.Drawing.Size(238, 286);
            this.panel_Player.TabIndex = 6;
            // 
            // label_MsgReceived
            // 
            this.label_MsgReceived.AutoSize = true;
            this.label_MsgReceived.Location = new System.Drawing.Point(17, 205);
            this.label_MsgReceived.MaximumSize = new System.Drawing.Size(200, 70);
            this.label_MsgReceived.MinimumSize = new System.Drawing.Size(200, 70);
            this.label_MsgReceived.Name = "label_MsgReceived";
            this.label_MsgReceived.Size = new System.Drawing.Size(200, 70);
            this.label_MsgReceived.TabIndex = 0;
            this.label_MsgReceived.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Message reçu";
            // 
            // label_NameConnectedPlayer
            // 
            this.label_NameConnectedPlayer.AutoSize = true;
            this.label_NameConnectedPlayer.Location = new System.Drawing.Point(17, 111);
            this.label_NameConnectedPlayer.Name = "label_NameConnectedPlayer";
            this.label_NameConnectedPlayer.Size = new System.Drawing.Size(163, 17);
            this.label_NameConnectedPlayer.TabIndex = 0;
            this.label_NameConnectedPlayer.Text = "Lui envoyer un message";
            // 
            // label_NameOtherPlayer
            // 
            this.label_NameOtherPlayer.BackColor = System.Drawing.Color.Transparent;
            this.label_NameOtherPlayer.Location = new System.Drawing.Point(56, 83);
            this.label_NameOtherPlayer.Name = "label_NameOtherPlayer";
            this.label_NameOtherPlayer.Size = new System.Drawing.Size(115, 22);
            this.label_NameOtherPlayer.TabIndex = 0;
            this.label_NameOtherPlayer.Text = "Inconnu";
            // 
            // label_Static_NamePlayer
            // 
            this.label_Static_NamePlayer.AutoSize = true;
            this.label_Static_NamePlayer.Location = new System.Drawing.Point(19, 12);
            this.label_Static_NamePlayer.Name = "label_Static_NamePlayer";
            this.label_Static_NamePlayer.Size = new System.Drawing.Size(105, 17);
            this.label_Static_NamePlayer.TabIndex = 0;
            this.label_Static_NamePlayer.Text = "Nom du Joueur";
            // 
            // textBox_Msg
            // 
            this.textBox_Msg.Location = new System.Drawing.Point(20, 140);
            this.textBox_Msg.MaxLength = 180;
            this.textBox_Msg.Name = "textBox_Msg";
            this.textBox_Msg.Size = new System.Drawing.Size(197, 22);
            this.textBox_Msg.TabIndex = 3;
            this.textBox_Msg.Text = "Message fairplay";
            this.textBox_Msg.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_Msg_PreviewKeyDown);
            // 
            // textBox_NamePlayer
            // 
            this.textBox_NamePlayer.Location = new System.Drawing.Point(20, 39);
            this.textBox_NamePlayer.MaxLength = 15;
            this.textBox_NamePlayer.Name = "textBox_NamePlayer";
            this.textBox_NamePlayer.Size = new System.Drawing.Size(197, 22);
            this.textBox_NamePlayer.TabIndex = 3;
            this.textBox_NamePlayer.Text = "Inconnu";
            this.textBox_NamePlayer.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_NamePlayer_PreviewKeyDown);
            // 
            // label_Static_DiscussWith
            // 
            this.label_Static_DiscussWith.Location = new System.Drawing.Point(17, 67);
            this.label_Static_DiscussWith.Name = "label_Static_DiscussWith";
            this.label_Static_DiscussWith.Size = new System.Drawing.Size(154, 42);
            this.label_Static_DiscussWith.TabIndex = 0;
            this.label_Static_DiscussWith.Text = "Discussion instantanée\r\navec ";
            // 
            // panel_Config
            // 
            this.panel_Config.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Config.Controls.Add(this.comboBox_Difficulty);
            this.panel_Config.Controls.Add(this.comboBox_GameMode);
            this.panel_Config.Controls.Add(this.label_GameMode);
            this.panel_Config.Controls.Add(this.label_Difficulty);
            this.panel_Config.Enabled = false;
            this.panel_Config.Location = new System.Drawing.Point(570, 50);
            this.panel_Config.Name = "panel_Config";
            this.panel_Config.Size = new System.Drawing.Size(238, 140);
            this.panel_Config.TabIndex = 7;
            // 
            // comboBox_Difficulty
            // 
            this.comboBox_Difficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Difficulty.FormattingEnabled = true;
            this.comboBox_Difficulty.Items.AddRange(new object[] {
            "1",
            "3",
            "5"});
            this.comboBox_Difficulty.Location = new System.Drawing.Point(22, 94);
            this.comboBox_Difficulty.Name = "comboBox_Difficulty";
            this.comboBox_Difficulty.Size = new System.Drawing.Size(195, 24);
            this.comboBox_Difficulty.TabIndex = 4;
            this.comboBox_Difficulty.SelectedIndexChanged += new System.EventHandler(this.comboBox_Difficulty_SelectedIndexChanged);
            // 
            // comboBox_GameMode
            // 
            this.comboBox_GameMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_GameMode.FormattingEnabled = true;
            this.comboBox_GameMode.Items.AddRange(new object[] {
            "Co-opération"});
            this.comboBox_GameMode.Location = new System.Drawing.Point(21, 41);
            this.comboBox_GameMode.Name = "comboBox_GameMode";
            this.comboBox_GameMode.Size = new System.Drawing.Size(196, 24);
            this.comboBox_GameMode.TabIndex = 4;
            this.comboBox_GameMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_GameMode_SelectedIndexChanged);
            // 
            // label_GameMode
            // 
            this.label_GameMode.AutoSize = true;
            this.label_GameMode.Location = new System.Drawing.Point(19, 17);
            this.label_GameMode.Name = "label_GameMode";
            this.label_GameMode.Size = new System.Drawing.Size(86, 17);
            this.label_GameMode.TabIndex = 0;
            this.label_GameMode.Text = "Mode de jeu";
            // 
            // label_Difficulty
            // 
            this.label_Difficulty.AutoSize = true;
            this.label_Difficulty.Location = new System.Drawing.Point(18, 69);
            this.label_Difficulty.Name = "label_Difficulty";
            this.label_Difficulty.Size = new System.Drawing.Size(128, 17);
            this.label_Difficulty.TabIndex = 0;
            this.label_Difficulty.Text = "Niveau de difficulté";
            // 
            // Connexion_Windows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 497);
            this.Controls.Add(this.panel_Config);
            this.Controls.Add(this.panel_Player);
            this.Controls.Add(this.radioButtonClient);
            this.Controls.Add(this.buttonReady);
            this.Controls.Add(this.radioButtonHost);
            this.Controls.Add(this.panelClient);
            this.Controls.Add(this.panelHost);
            this.Name = "Connexion_Windows";
            this.Text = "Sudoku Multiplayer Start Up - Connexion";
            this.panelHost.ResumeLayout(false);
            this.panelHost.PerformLayout();
            this.panelClient.ResumeLayout(false);
            this.panelClient.PerformLayout();
            this.panel_Player.ResumeLayout(false);
            this.panel_Player.PerformLayout();
            this.panel_Config.ResumeLayout(false);
            this.panel_Config.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHost;
        private System.Windows.Forms.Label label_Status_CoToClient;
        private System.Windows.Forms.Label label_IPHost;
        private System.Windows.Forms.Label label_StaticClientState;
        private System.Windows.Forms.Label label_StaticIPHost;
        private System.Windows.Forms.Panel panelClient;
        private System.Windows.Forms.Label label_Status_CoToHost;
        private System.Windows.Forms.Button buttonConnectToHost;
        private System.Windows.Forms.TextBox textBox_IP_X4;
        private System.Windows.Forms.TextBox textBox_IP_X3;
        private System.Windows.Forms.TextBox textBox_IP_X2;
        private System.Windows.Forms.TextBox textBox_IP_X1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Point;
        private System.Windows.Forms.Label label_StaticEnterIPHost;
        private System.Windows.Forms.RadioButton radioButtonHost;
        private System.Windows.Forms.RadioButton radioButtonClient;
        private System.Windows.Forms.Button buttonReady;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_HostPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_HostPortChosen;
        private System.Windows.Forms.Button button_OpenConnexionToClient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel_Player;
        private System.Windows.Forms.Label label_MsgReceived;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_NameConnectedPlayer;
        private System.Windows.Forms.Label label_Static_DiscussWith;
        private System.Windows.Forms.Label label_Static_NamePlayer;
        private System.Windows.Forms.TextBox textBox_Msg;
        private System.Windows.Forms.TextBox textBox_NamePlayer;
        private System.Windows.Forms.Panel panel_Config;
        private System.Windows.Forms.ComboBox comboBox_Difficulty;
        private System.Windows.Forms.ComboBox comboBox_GameMode;
        private System.Windows.Forms.Label label_GameMode;
        private System.Windows.Forms.Label label_Difficulty;
        private System.Windows.Forms.Label label_NameOtherPlayer;
    }
}