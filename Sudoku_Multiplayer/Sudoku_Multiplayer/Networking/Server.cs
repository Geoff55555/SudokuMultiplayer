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
    class Server : Control //pour pvr utiliser le Invoke dessus !
    {
        Socket listenSocket;
        IPAddress serverIP;
        IPEndPoint serverEndPoint;

        List<Client> clientList = new List<Client>();

        public event EventHandler<commArgs> Connection;
        public event EventHandler<commArgs> InfoExchange;

        public Server(string ip, int port)//port should always be >1024 to avoid any conflicts
        {
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
            //quand le server accepte la connection, il reçoit le socket de communication avec le client --> Il faut le garder !
            AddClient(listenSocket.EndAccept(ar));
            commArgs connectionInfo = new commArgs("Connected to Client");
            connectionInfo.coSuccess = true;
            launchWithInvokeCheck(Connection, this, connectionInfo);
        }

        private void AddClient(Socket clientSocket)
        {
            Client newClient = new Client(clientSocket);
            newClient.infoExchange += newClient_InfoExchange; //les events lancés par les clients seront tous récup par le server qui enverra son propre event correspondant
            clientList.Add(newClient);
        }

        private void newClient_InfoExchange(object sender, commArgs e)
        {
            launchWithInvokeCheck(InfoExchange, sender, e);
        }

        //check method
        private void launchWithInvokeCheck(EventHandler<commArgs> syncMethod, object sender, commArgs e)
        {
            if (syncMethod != null)//when connexion is lost
            {
                if (syncMethod.Target is Control)
                {
                    if (((Control)syncMethod.Target).InvokeRequired)
                    {
                        ((Control)syncMethod.Target).Invoke(syncMethod, sender, e);
                    }
                    else
                    {
                        syncMethod(sender, e);
                    }
                }
            }
        }
    }
}
