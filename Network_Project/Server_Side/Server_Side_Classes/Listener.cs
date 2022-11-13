using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Network_Project.Server_Side_Classes
{
    public class Listener
    {
        public delegate void SocketAcceptedHandler(Socket sender);
        public event SocketAcceptedHandler Accepted;

        private Socket listener;
        public int port;
        public RSAServerSide rsa;
        public bool Running 
        {
            get; 
            private set; 
        }
        public Listener()
        {
            port = 0;
            rsa = new RSAServerSide();
        }
        public void  Stop()
        {
            if (!Running)
                return;
            listener.Close();
            Running = false;
        }

        public void Start(int port)
        {
            if (Running)
                return;
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Any, port));
            listener.Listen(0);
            listener.BeginAccept(AcceptedCallBack, null);
            Running = true;
        }

        private void AcceptedCallBack(IAsyncResult ar)
        {
            try
            {
                Socket sock = listener.EndAccept(ar);
                Accepted?.Invoke(sock);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (Running)
            {
                try
                {
                    listener.BeginAccept(AcceptedCallBack, null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
