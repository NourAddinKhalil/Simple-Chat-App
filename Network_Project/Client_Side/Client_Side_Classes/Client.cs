using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Network_Project.Server_Side_Classes;
using System.Diagnostics;

namespace Client_Side.Client_Side_Classes
{
    public class Client : ClientBase
    {
        public delegate void OnConnectedEventHandler(Client sender, bool connected);
        public event OnConnectedEventHandler OnConnected;

        public delegate void OnSendEventHandler(Client sender, int length);
        public event OnSendEventHandler OnSend;

        public delegate void DataRecievedEventHandelr(Client sender, Buffer_Recieve buffer_Recieve);
        public event DataRecievedEventHandelr DataRecieved;

        public delegate void OnDisConnectedEventHandler(Client sender);
        public event OnDisConnectedEventHandler OnDisConnected;

        public delegate void OnConnectedExceptionEventHandler();
        public event OnConnectedExceptionEventHandler OnConnectExecption;

        //Socket socket;
        public RSAClientSide rsa;

        public Client() : base(null)
        {
            socket = NewSocket;
            rsa = new RSAClientSide();
        }

        internal void ReIntializeRSA()
        {
            rsa = new RSAClientSide();
        }

        private Socket NewSocket
        {
            get
            {
                return new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); ;
            }
        }

        public bool Connected 
        {
            get
            {
                if (socket != null)
                {
                    return socket.Connected;
                }
                return false;
            }
        }

        public void Conncet(string ipAddress , int port)
        {
            try
            {
                if (socket == null)
                    socket = NewSocket;
                socket.BeginConnect(ipAddress, port, ConnectCallBack, null);
            }
            catch
            {
                OnConnectExecption?.Invoke();
            }
        }

        private void ConnectCallBack(IAsyncResult ar)
        {
            try
            {
                socket.EndConnect(ar);
                OnConnected?.Invoke(this, Connected);
            }
            catch (Exception ex)
            {
                var st = new StackTrace(ex, true);
                var frame = st.GetFrame(0);
                var line = frame.GetFileLineNumber();
                Console.WriteLine($"Error At Line : {line} \n Message : {ex.Message}");
                OnConnectExecption?.Invoke();
            }
        }

        public void SendData (byte[] data , int startIndex , int length)
        {
            //inform the server how much data will recieve
            socket.BeginSend(BitConverter.GetBytes(length), 0, 4, SocketFlags.None, SendCallBack, null);
            //send the actual data
            socket.BeginSend(data, startIndex, length, SocketFlags.None, SendCallBack, null);
        }

        private void SendCallBack(IAsyncResult ar)
        {
            try
            {
                int sentLength = socket.EndSend(ar);
                OnSend?.Invoke(this, sentLength);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RecieveAsync()
        {
            if (Connected)
                socket.BeginReceive(buffLength, 0, buffLength.Length, SocketFlags.None, RecieveCallBack, null);
        }

        private void RecieveCallBack(IAsyncResult ar)
        {
            try
            {
                int reciveLength = socket.EndReceive(ar);
                if (reciveLength == 0)
                {
                    if (OnDisConnected != null)
                    {
                        OnDisConnected(this);
                        return;
                    }
                    if (reciveLength != 4)
                    {
                        throw new Exception("Recieve Length Not Equal 4");
                    }

                }
            }
            catch (SocketException ex)
            {
                switch (ex.SocketErrorCode)
                {
                    case SocketError.ConnectionAborted:
                    case SocketError.ConnectionReset:
                        if (OnDisConnected != null)
                        {
                            OnDisConnected(this);
                            return;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            recieve = new Buffer_Recieve(BitConverter.ToInt32(buffLength, 0));
            socket.BeginReceive(recieve.buffer, 0, recieve.buffer.Length, SocketFlags.None, RecievePacketCallBack, null);
        }

        private void RecievePacketCallBack(IAsyncResult ar)
        {
            int recieveLength = socket.EndReceive(ar);
            if (recieveLength <= 0)
            {
                return;
            }
            recieve.memory.Write(recieve.buffer, 0, recieveLength);
            recieve.toRecieve -= recieveLength;
            if (recieve.toRecieve > 0)
            {
                Array.Clear(recieve.buffer, 0, recieve.buffer.Length);
                socket.BeginReceive(recieve.buffer, 0, recieve.buffer.Length, SocketFlags.None, RecievePacketCallBack, null);
                return;
            }
            if (DataRecieved != null)
            {
                recieve.memory.Position = 0;
                DataRecieved(this, recieve);
            }
            recieve.Dispose();
            RecieveAsync();
        }

        public void Disconnect()
        {
            if (socket != null && socket.Connected)
            {
                socket.Close();
                socket = null;
                OnDisConnected?.Invoke(this);
            }
        }
    }
}
