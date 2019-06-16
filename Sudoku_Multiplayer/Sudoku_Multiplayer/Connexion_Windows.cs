using System;
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

        public Connexion_Windows()
        {
            InitializeComponent();
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
            label_Status_CoToClient.Text = e.message;
            if (radioButtonHost.Checked && e.coSuccess)
            {
                //When connexion is established with client:
                panelHost.Enabled = false;
                buttonReady.Enabled = true;
            }
            else
            {
                label_Status_CoToClient.ForeColor = Color.DarkRed;
            }
        }

        //in case of connection from client to server
        private void client_Connection(object sender, commArgs e)
        {
            label_Status_CoToHost.ForeColor = Color.Black;
            label_Status_CoToHost.Text = e.message;
            if (e.coSuccess)
            {
                panelClient.Enabled = false;
                buttonReady.Enabled = true;
            }
            else
            {
                label_Status_CoToHost.ForeColor = Color.DarkRed;
            }
        }

        //buttons
        private void buttonConnectToHost_Click(object sender, EventArgs e)
        {
            string serverIP = textBox_IP_X1.Text + "." + textBox_IP_X2.Text + "." + textBox_IP_X3.Text + "." + textBox_IP_X4.Text;
            int serverPort = int.Parse(textBox_HostPort.Text.ToString());
            label_Status_CoToHost.Text = "Recherche de l'hôte en cours...";
            client.ConnectToServer(serverIP, serverPort);
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

        private void buttonReady_Click(object sender, EventArgs e)
        {
            this.Hide();
            Game_Window newGame = new Game_Window();
            newGame.ShowDialog();
            this.ShowDialog();
        }
    }
}
