using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Server_SerialComm
{
    public class Server : Control //pour pvr utiliser le Invoke sur le Server ! #invoke-ception 8D
    {
        Socket listenSocket;
        IPAddress serverIP;
        IPEndPoint serverEndPoint;
        
        //to enable more than one client connected to the server
        public List<Client> ClientList = new List<Client>();

        //events to launch
        public event EventHandler<commArgs> Connection;
        public event EventHandler<commArgs> InfoExchange;

        //public variable
        public bool isConnected = false;

        //Constructor
        public Server(string ip, int port)
        {
            //init the socket
            listenSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);

            serverIP = IPAddress.Parse(ip);
            serverEndPoint = new IPEndPoint(serverIP, port);
            listenSocket.Bind(serverEndPoint);

            listenSocket.Listen(10);

            acceptConnection();
        }

        //Accept and add client with connection Socket
        public void acceptConnection()
        {
            if (listenSocket.Connected == false)
            {
                listenSocket.BeginAccept(acceptConnectionCallback, null);
            }
        }

        private void acceptConnectionCallback(IAsyncResult ar)
        {
            //quand le server accepte la connection, il reçoit le socket de communication avec le client --> Il faut garder ce Socket!
            AddClient(listenSocket.EndAccept(ar));

            //notify the new connection
            commArgs connectionInfo = new commArgs();
            connectionInfo.Info = "Connected to Client";
            isConnected = true;
            launchWithInvokeCheck(Connection, this, connectionInfo);

            acceptConnection();
        }

        private void AddClient(Socket clientSocket)
        {
            Client newClient = new Client(clientSocket); //special constructor for client coming from a server
            //add methods to the new client : the events launched by the clients will all be RE-Launched by the server with its own infoExchange and Connexion events !! --> Invoke-ception 8)
            newClient.infoExchange += newClient_InfoExchange; //rappel en fr : les events lancés par les clients seront tous récup par le server qui enverra son propre event correspondant
            newClient.Connection += newClient_Connection; //rappel en fr : les events lancés par les clients seront tous récup par le server qui enverra son propre event correspondant
            ClientList.Add(newClient);
        }

        private void newClient_InfoExchange(object sender, commArgs e)
        {
            this.launchWithInvokeCheck(InfoExchange, sender, e);
        }

        private void newClient_Connection(object sender, commArgs e)
        {
            //if connection is lost, dispose that sender to the garbage collector
            if (!((Client)sender).isConnected)
            {
                sender = null;
                isConnected = false;
            }
            this.launchWithInvokeCheck(Connection, sender, e);
            
        }


        //check method
        private void launchWithInvokeCheck(EventHandler<commArgs> ASyncMethod, object sender, commArgs e)
        {
            if (ASyncMethod == null)
            {
                Console.WriteLine("Delegate sync method launch by " + sender + " has not been defined");
            }
            else
            {
                if (ASyncMethod.Target is Control)
                {
                    if (((Control)ASyncMethod.Target).InvokeRequired)
                    {
                        ((Control)ASyncMethod.Target).Invoke(ASyncMethod, sender, e);
                    }
                    else
                    {
                        ASyncMethod(sender, e);
                    }
                }
            }
        }
    }
}
