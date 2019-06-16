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
    class Client
    {
        Socket commSocket;

        public event EventHandler<commArgs> infoExchange;
        public event EventHandler<commArgs> Connection;
        public object info;

        public Client()
        {
            commSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }

        public Client(Socket commS)//lorsqu'il est instancié par un serveur
        {
            commSocket = commS;
            this.ReceiveMsg();
        }

        //connection to server
        public void ConnectToServer(string serverIP, int port)
        {
            commSocket.BeginConnect(IPAddress.Parse(serverIP), port, connectCallback, null);
        }

        private void connectCallback(IAsyncResult ar)
        {
            try
            {
                commSocket.EndConnect(ar);
                commArgs connectSuccess = new commArgs("Connected to Server");
                connectSuccess.coSuccess = true;
                launchWithInvokeCheck(Connection, this, connectSuccess);
                this.ReceiveMsg();
            }
            catch
            {
                commArgs connectFail = new commArgs("Failed to find server");
                connectFail.coSuccess = false;
                launchWithInvokeCheck(Connection, this, connectFail);
            }
        }

        //info Exchange
        //--receive
        public void ReceiveMsg()
        {
            byte[] buffer = new byte[256];
            commSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, receiveMsgCallback, buffer);
        }

        private void receiveMsgCallback(IAsyncResult ar)
        {
            commArgs comm = new commArgs();
            try
            {
                byte[] tempBuffer = (byte[])ar.AsyncState;
                commSocket.EndReceive(ar);
                comm.message += Encoding.ASCII.GetString(tempBuffer); //ssi les bytes reçus correspondent à un string
                if (commSocket.Available > 0)
                {
                    byte[] recursiveBuffer = new byte[256];
                    commSocket.BeginReceive(recursiveBuffer, 0, recursiveBuffer.Length, SocketFlags.None, receiveMsgCallback, recursiveBuffer);
                }
                else
                {
                    launchWithInvokeCheck(infoExchange, this, comm);
                }
            }
            catch
            {
                comm.message = "Connexion Lost";
                try { launchWithInvokeCheck(infoExchange, this, comm); } catch { comm.message = "Connexion Lost."; comm.coSuccess = false; }
            }
        }

        //--send
        public void SendMsg(string toSend) //ssi le msg envoyé correspond à un string
        {
            byte[] bytesToSend = Encoding.ASCII.GetBytes(toSend);
            commArgs comm = new commArgs("Message sent...");
            try { launchWithInvokeCheck(infoExchange, this, comm); } catch { comm.message = "Connexion Lost."; comm.coSuccess = false; }
            commSocket.BeginSend(bytesToSend, 0, bytesToSend.Length, SocketFlags.None, sendCallback, bytesToSend);
        }

        private void sendCallback(IAsyncResult ar)
        {
            commSocket.EndSend(ar);
            commArgs comm = new commArgs("The message sent has been received");
            try { launchWithInvokeCheck(infoExchange, this, comm); } catch { comm.message = "Connexion Lost."; comm.coSuccess = false; }
        }

        //Making sure everything isn't mest up with asynchrone stuff
        private void launchWithInvokeCheck(EventHandler<commArgs> syncMethod, object sender, commArgs e)
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
            else
            {
                Console.WriteLine("!! " + syncMethod.Target.GetType() + "is NOT Control nor SERVER");
            }
        }
    }
}
