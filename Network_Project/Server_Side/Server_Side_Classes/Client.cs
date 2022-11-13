using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace Network_Project.Server_Side_Classes
{
    public enum SentDataType : int
    {
        StringType = 1,
        ImageType,
        VideoType,
        MusicType,
        DocumentType,
        publicKey
    }

    public struct Buffer_Recieve
    {
        public const int BUFFER_SIZE = 2048;
        public byte[] buffer;
        public int toRecieve;
        public MemoryStream memory;
        public Buffer_Recieve(int toRecieve)
        {
            buffer = new byte[BUFFER_SIZE];
            this.toRecieve = toRecieve;
            memory = new MemoryStream(this.toRecieve);
        }
        public void Dispose()
        {
            buffer = null;
            toRecieve = 0;
            Close();
            if (memory != null)
                memory.Dispose();
        }
        public void Close()
        {
            if(memory != null && memory.CanWrite)
            {
                memory.Close();
            }
        }
    }

    public class Client : ClientBase
    {
        //byte[] buffLength;
        //Buffer_Recieve recieve;
        //Socket socket;
        public Client(Socket socket ) : base(socket)
        {
            
        }
        public IPEndPoint EndPoint 
        {
            get
            {
                if(socket != null && socket.Connected)
                {
                    return (IPEndPoint)socket.RemoteEndPoint;
                }
                return new IPEndPoint(IPAddress.None, 0);
            }
        }

        public delegate void DisconnectedEventHandler(Client sender);
        public event DisconnectedEventHandler Disconnected;

        public delegate void DataRecievedEventHandelr(Client sender, Buffer_Recieve buffer_Recieve);
        public event DataRecievedEventHandelr DataRecieved;

        public delegate void OnSendEventHandler(Client sender, int length);
        public event OnSendEventHandler OnSend;

        public void Close()
        {
            if (socket != null)
            {
                socket.Disconnect(false);
                socket.Close();
            }
            recieve.Dispose();
            socket = null;
            buffLength = null;
            Disconnected = null;
            DataRecieved = null;
        }

        public void SendData(byte[] data, int startIndex, int length)
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
            socket.BeginReceive(buffLength, 0, buffLength.Length, SocketFlags.None, RecieveCallBack, null);
        }

        private void RecieveCallBack(IAsyncResult ar)
        {
            try
            {
                int reciveLength = socket.EndReceive(ar);
                if (reciveLength == 0)
                {
                    if (Disconnected != null)
                    {
                        Disconnected(this);
                        return;
                    }
                    if(reciveLength != 4)
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
                        if (Disconnected != null)
                        {
                            Disconnected(this);
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
            if(recieveLength <= 0)
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
            if(DataRecieved != null)
            {
                recieve.memory.Position = 0;
                DataRecieved(this, recieve);
            }
            recieve.Dispose();
            RecieveAsync();
        }
    }
}
