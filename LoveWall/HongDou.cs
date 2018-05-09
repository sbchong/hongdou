using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;

namespace LoveWall
{
    public class HongDou
    {
        public class ClientControl
        {
            //private Socket clientSocket;
            public Socket clientSocket;

            string msgrec;

            public ClientControl()
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }

            public bool Connect(string ip, int port)
            {
                try
                {
                    clientSocket.Connect(ip, port);
                    clientSocket.Send(Encoding.UTF8.GetBytes("haha hgx12345"));
                    clientSocket.Send(Encoding.UTF8.GetBytes("haha 1"));
                    clientSocket.Send(Encoding.UTF8.GetBytes("lalalala"));
                }
                catch
                {
                    return true;
                }
                //Thread threadReceive = new Thread();
                //threadReceive.IsBackground = true;
                //threadReceive.Start();
                
                return false;
            }

        }
    }
}
