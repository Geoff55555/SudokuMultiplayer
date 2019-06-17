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
        public bool isConnected = false; //vérifier connection perdue?
        public bool isServer = false;
        public Client()
        {
            commSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }

        public Client(Socket commS)//lorsqu'il est instancié par un serveur
        {
            commSocket = commS;
            //this.ReceiveMsg();
            this.ReceiveData();
            isConnected = true;
            isServer = true;
        }

        //connection to server
        public void ConnectToServer(string serverIP, int port)
        {
            try { commSocket.BeginConnect(IPAddress.Parse(serverIP), port, connectCallback, null); } catch { isConnected = false; commSocket = new Socket(SocketType.Stream, ProtocolType.Tcp); }
        }

        private void connectCallback(IAsyncResult ar)
        {
            try { commSocket.EndConnect(ar); } catch { isConnected = false; }
            commArgs connectSuccess = new commArgs();
            isConnected = true;
            connectSuccess.Info = "Connected to Server";
            launchWithInvokeCheck(Connection, this, connectSuccess);
            //this.ReceiveMsg();
            // this.ReceiveData();
        }

        //info Exchange
        //--receive RECEIVING MESSAGE IS INCOMPATIBLE WITH RECEIVING DATA
        //public void ReceiveMsg() 
        //{
        //    byte[] buffer = new byte[256];
        //    commSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, receiveMsgCallback, buffer);
        //}

        //private void receiveMsgCallback(IAsyncResult ar)
        //{
        //    commArgs comm = new commArgs();

        //    if (isConnected)
        //    {
        //        byte[] tempBuffer = (byte[])ar.AsyncState;
        //        try { commSocket.EndReceive(ar); } catch { isConnected = false; }
        //        comm.Message += Encoding.ASCII.GetString(tempBuffer); //ssi les bytes reçus correspondent à un string
        //        if (commSocket.Available > 0)
        //        {
        //            byte[] recursiveBuffer = new byte[256];
        //            commSocket.BeginReceive(recursiveBuffer, 0, recursiveBuffer.Length, SocketFlags.None, receiveMsgCallback, recursiveBuffer);
        //        }
        //        else
        //        {
        //            comm.Info = "Message Received";
        //            comm.Reception = true;
        //            launchWithInvokeCheck(infoExchange, this, comm);
        //            ReceiveMsg();
        //        }
        //    }
        //    else
        //    {
        //        comm.Info = "Not Connected !";
        //        launchWithInvokeCheck(infoExchange, this, comm);
        //    }
        //}

        public void ReceiveData()
        {
            SerialObject receivedData = new SerialObject();
            try
            {
                commSocket.BeginReceive(receivedData.Serialized, 0, receivedData.Serialized.Length, SocketFlags.None, receiveDataCallback, receivedData);
            }
            catch { isConnected = false; }
        }

        private void receiveDataCallback(IAsyncResult ar)
        {
            try
            {
                int DataSize = commSocket.EndReceive(ar);
                SerialObject receivedData = (SerialObject)ar.AsyncState;
                receivedData.AddDataToBeSerialized(DataSize);

                if (commSocket.Available > 0)
                {
                    commSocket.BeginReceive(receivedData.Serialized, 0, receivedData.Serialized.Length, SocketFlags.None, receiveDataCallback, receivedData);
                }
                else
                {
                    commArgs comm = new commArgs();
                    comm.Info = "Object Received";
                    comm.Reception = true;
                    receivedData.Deserialize();
                    comm.ObjectData = receivedData.Deserialized;
                    launchWithInvokeCheck(infoExchange, this, comm);
                    ReceiveData();
                }
            }
            catch (System.Net.Sockets.SocketException e)
            {
                commArgs connexionLost = new commArgs();
                connexionLost.Info = "Connexion Lost with the ";
                if (isServer)
                {
                    connexionLost.Info += "Client.";
                    isConnected = false;

                }
                else
                {
                    connexionLost.Info += "Server.";
                    isConnected = false;
                }
                launchWithInvokeCheck(Connection, this, connexionLost);
            }


        }

        //--send
        //SEND MESSAGE IS USELESS WITH SEND DATA
        //public void SendMsg(string toSend) //ssi le msg envoyé correspond à un string
        //{
        //    if (isConnected)
        //    {
        //        byte[] bytesToSend = Encoding.ASCII.GetBytes(toSend);
        //        commArgs comm = new commArgs();
        //        comm.Info = "Message sent...";
        //        launchWithInvokeCheck(infoExchange, this, comm);
        //        commSocket.BeginSend(bytesToSend, 0, bytesToSend.Length, SocketFlags.None, sendMsgCallback, bytesToSend);
        //    }
        //    else
        //    {
        //        sendErrorNotConnected();
        //    }
        //}

        //private void sendMsgCallback(IAsyncResult ar)
        //{
        //    commSocket.EndSend(ar);
        //    commArgs comm = new commArgs();
        //    comm.Info = "The message sent has been received";
        //    launchWithInvokeCheck(infoExchange, this, comm);
        //}

        public void SendData(object data, string param)
        {
            if (isConnected)
            {
                SerialObject objectToSend = new SerialObject();
                objectToSend.Deserialized = data;
                objectToSend.Serialize();
                byte[] objectSerialized = objectToSend.Serialized;
                commSocket.BeginSend(objectSerialized, 0, objectSerialized.Length, SocketFlags.None, sendDataCallback, objectToSend);
            }
            else
            {
                sendErrorNotConnected();
            }
        }

        private void sendDataCallback(IAsyncResult ar)
        {
            commSocket.EndSend(ar);
            commArgs comm = new commArgs();
            comm.Info = "The object data has been sent";
            launchWithInvokeCheck(infoExchange, this, comm);
        }

        //Making sure everything isn't messed up with asynchrone stuff
        private void launchWithInvokeCheck(EventHandler<commArgs> syncMethod, object sender, commArgs e)
        {
            if (syncMethod == null)
            {
                Console.WriteLine("Delegate sync method launch by " + sender + " has not been defined");
            }
            else
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
                    Console.WriteLine("!! " + syncMethod.Target.GetType() + "is NOT Control (nor SERVER)");
                }
            }
        }

        private void sendErrorNotConnected()
        {
            commArgs comm = new commArgs();
            comm.Info = "Not connected !";
            launchWithInvokeCheck(infoExchange, this, comm);
        }
    }
}
