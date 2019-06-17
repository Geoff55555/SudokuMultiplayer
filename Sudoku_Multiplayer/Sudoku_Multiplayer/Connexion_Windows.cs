﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client_Server_SerialComm;

namespace Sudoku_Multiplayer
{
    public partial class Connexion_Windows : Form
    {
        Server server;
        string myIP;
        int myPort; //always >1024 to avoid any conflict
        Client client;
        bool isHost = false;

        public Connexion_Windows()
        {
            InitializeComponent();
            //to enable preview key down event
            this.KeyPreview = true;
            //init comboBoxes
            comboBox_GameMode.SelectedIndex = 0;
            comboBox_Difficulty.SelectedIndex = 0;
        }

        //selection mode
        private void radioButtonHost_MouseDown(object sender, MouseEventArgs e)
        {
            //display modify
            radioButtonClient.Checked = false;
            panelHost.Enabled = true;
            panelClient.Enabled = false;

            //display computer IP
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() && server == null)
            {
                try { myIP = GetLocalIPAddress(); } catch { label_IPHost.Text = "Pas d'adresse IPv4 trouvée..."; }
                label_IPHost.Text = myIP;
            }
        }

        private void radioButtonClient_MouseDown(object sender, MouseEventArgs e)
        {
            //display modify
            radioButtonHost.Checked = false;
            panelClient.Enabled = true;
            panelHost.Enabled = false;

            //create necessary objects to be Client
            if (client == null) //if clicked and client has been already created
            {
                client = new Client();
                client.Connection += client_Connection;
                client.infoExchange += client_infoExchange;
            }
        }

        //delegate methode for events on Info Exchange
        private void client_infoExchange(object sender, commArgs e)
        {
            //We don't want to react if this is the client that sent the name, so we only care if this message is received
            if (e.Info == "Message Received")
            {
                label_NameOtherPlayer.Text = e.Message;
            }
            else if (e.Info == "Object Received")
            {
                label_MsgReceived.Text = (string)e.ObjectData;
            }
            else if (e.Info == "Connexion Lost with the Server.")
            {
                panelClient.Enabled = true;
                panel_Player.Enabled = false;
                buttonReady.Enabled = false;
            }
        }

        private void server_InfoExchange(object sender, commArgs e)
        {
            //We don't want to react if this is the server that sent the name, so we only care if this message is received
            if (e.Info == "Message Received")
            {
                label_NameOtherPlayer.Text = e.Message;
            }
            else if (e.Info == "Object Received")
            {
                label_MsgReceived.Text = e.Message;
            }
        }

        //getting my IP address
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());//has to ask who's the network big host
            foreach (var ip in host.AddressList) //the pc has multiple ip addresses IPv6 or IPv4 following the focus : local or network stuff
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        //in case of connection detected to the server
        private void server_Connection(object sender, commArgs e)
        {
            label_Status_CoToClient.ForeColor = Color.Black;
            label_Status_CoToClient.Text = e.Info;
            if (radioButtonHost.Checked && server.isConnected)
            {
                //When connexion is established with client:
                panelHost.Enabled = false;
                panel_Config.Enabled = true;
                panel_Player.Enabled = true;
                buttonReady.Enabled = true;
                isHost = true;
                //every client is listening when created
                //for (int client = 0; client < server.ClientList.Count; client++)
                //{
                //    server.ClientList[client].ReceiveData();
                //}
            }
            else
            {
                panelHost.Enabled = true;
                panel_Config.Enabled = false;
                panel_Player.Enabled = false;
                buttonReady.Enabled = false;
                isHost = true;

                label_Status_CoToClient.ForeColor = Color.DarkRed;
            }
        }

        //in case of connection from client to server
        private void client_Connection(object sender, commArgs e)
        {
            label_Status_CoToHost.ForeColor = Color.Black;
            label_Status_CoToHost.Text = e.Info;
            if (client.isConnected)
            {
                panelClient.Enabled = false;
                panel_Player.Enabled = true;
                buttonReady.Enabled = true;
                client.ReceiveData();
            }
            else
            {
                panelClient.Enabled = true;
                panel_Player.Enabled = false;
                buttonReady.Enabled = false;
                label_Status_CoToHost.ForeColor = Color.DarkRed;
                //connexion lost with server, mandatory to restart
                radioButtonHost.Checked = true;
                radioButtonHost_MouseDown(this, null);
            }
        }

        //buttons
        private void buttonConnectToHost_Click(object sender, EventArgs e)
        {
            if (!client.isConnected)
            {
                string serverIP = textBox_IP_X1.Text + "." + textBox_IP_X2.Text + "." + textBox_IP_X3.Text + "." + textBox_IP_X4.Text;
                int serverPort = int.Parse(textBox_HostPort.Text.ToString());
                label_Status_CoToHost.Text = "Recherche de l'hôte en cours...";
                client.ConnectToServer(serverIP, serverPort);
            }
            else
            {
                client = new Client();
                client.Connection += client_Connection;
                client.infoExchange += client_infoExchange;
            }
        }

        private void button_OpenConnexionToClient_Click(object sender, EventArgs e)
        {
            //check entered port
            try
            {
                if (int.Parse(textBox_HostPortChosen.Text) > 1024)
                {
                    myPort = int.Parse(textBox_HostPortChosen.Text);
                    //create necessary objects to be Host + skip if clicked and host has been already created
                    if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() && server == null)
                    {
                        //visuals
                        ((Control)sender).Enabled = false;
                        label_Status_CoToClient.Text = "En attente de connexion...";
                        //launch connexion waiting
                        server = new Server(myIP, myPort);
                        server.Connection += server_Connection;
                        server.InfoExchange += server_InfoExchange;
                        server.acceptConnection();
                        textBox_HostPortChosen.Text = myPort.ToString();
                    }
                    else if (server != null)
                    {
                        //do nothing
                    }
                    else
                    {
                        label_IPHost.ForeColor = Color.DarkRed;
                        label_IPHost.Text = "PAS DE CONNEXION RÉSEAU !\nRedémarrer l'application avec un connexion valide svp";
                    }
                }
                else
                {
                    label_Status_CoToClient.Text = "Port invalide. Le prendre >1024 pour éviter tout conflit.";
                }

            }
            catch
            {
                label_Status_CoToClient.Text = "Port invalide. Nombre >1024 pour éviter tout conflit.";
            }
        }

        private void textBox_NamePlayer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (isHost)
                {
                    for (int client = 0; client < server.ClientList.Count; client++)
                    {
                        server.ClientList[client].SendData(textBox_NamePlayer.Text, "name");
                    }
                }
                else
                {
                    client.SendData(textBox_NamePlayer.Text, "name");
                }
            }
        }

        private void textBox_Msg_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (isHost)
                {
                    for (int client = 0; client < server.ClientList.Count; client++)
                    {
                        server.ClientList[client].SendData(textBox_Msg.Text, "name");
                    }
                }
                else
                {
                    client.SendData(textBox_Msg.Text, "name");
                }
            }
        }

        private void buttonReady_Click(object sender, EventArgs e)
        {
            this.Hide();
            Game_Window newGame = new Game_Window(isHost, int.Parse(comboBox_Difficulty.Text));
            newGame.ShowDialog();
            this.ShowDialog();
        }

    }
}
