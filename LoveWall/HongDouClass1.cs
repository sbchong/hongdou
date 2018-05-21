using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace HongDou
{
    internal class HongDouClass
    {
        public Socket clientSocket;

        string msgrec;

        public HongDouClass()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public bool Connect()
        {
            try
            {
                clientSocket.Connect("45.63.91.170", 20566);
                return true;
                //clientSocket.Connect(ip, port);
                //clientSocket.Send(Encoding.UTF8.GetBytes("haha hgx12345"));
                //clientSocket.Send(Encoding.UTF8.GetBytes("haha 1"));
                //clientSocket.Send(Encoding.UTF8.GetBytes("lalalala"));
            }
            catch
            {
                return false;
            }
            //Thread threadReceive = new Thread();
            //threadReceive.IsBackground = true;
            //threadReceive.Start();

            
        }

        public string Login(string username,string password)
        {
            clientSocket.Send(Encoding.UTF8.GetBytes("/login"));
            Receive();
            string usermessage = username + password;
            usermessage = usermessage.Insert(username.Length, " ");
            clientSocket.Send(Encoding.UTF8.GetBytes(usermessage));
            string logininfo = Receive();
            if (logininfo == "/Successed\n")
            {
                return "登录成功";
            }
            else
            {
                if (logininfo == "/WrongPassword\n")
                {
                    return "密码错误，请检查后重试";
                }
                //if(logininfo == "/NoUsername\n")
                else
                {
                    return "用户名不存在";
                }
            }
        }

        public void Send(string msg)
        {
            clientSocket.Send(Encoding.UTF8.GetBytes(msg));
        }

        public string ReceiveMessages()
        {
            clientSocket.Send(Encoding.UTF8.GetBytes("/getMessages"));
            Receive();
            clientSocket.Send(Encoding.UTF8.GetBytes("0"));
            return Receive1();
        }

        public string Receive()
        {
            byte[] msg = new byte[5 * 5];
            int msgLen = clientSocket.Receive(msg);
            msgrec = Encoding.UTF8.GetString(msg, 0, msgLen);
            //Receive();
            //await Receive();
            return msgrec;
        }

        public string Receive1()
        {

            byte[] msg = new byte[30 * 30];
            int msgLen = clientSocket.Receive(msg);
            // msgrec = Encoding.Unicode.GetString(msg, 0, msgLen);
            msgrec = Encoding.UTF8.GetString(msg, 0, msgLen);
            msgrec = Regex.Unescape(msgrec);

            return msgrec;
        }
    }
}