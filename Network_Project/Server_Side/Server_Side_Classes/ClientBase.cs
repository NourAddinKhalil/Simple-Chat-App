using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Network_Project.Server_Side_Classes
{
    public class ClientBase
    {
        protected byte[] buffLength;
        protected Buffer_Recieve recieve;
        protected Socket socket;

        public string ID { get; private set; }

        private static int counter = 0;
        public ClientBase(Socket socket)
        {
            ID = $"CLient {++counter}";
            this.socket = socket;
            buffLength = new byte[4];
        }
    }
}
