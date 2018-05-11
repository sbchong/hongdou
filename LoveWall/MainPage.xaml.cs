using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Text.RegularExpressions;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace LoveWall
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        HongDou hongdou = new HongDou();
        private Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        string msgrec = "";
        bool userlogin;

        public MainPage()
        {
            this.InitializeComponent();
 
        }

        public string Receive()
        {
            byte[] msg = new byte[20 * 20];
            int msgLen = clientSocket.Receive(msg);
            msgrec = Encoding.UTF8.GetString(msg, 0, msgLen);
            //Receive();
            //await Receive();
            return msgrec;
        }

        public string Receive1()
        {

            byte[] msg = new byte[20 * 20];
            int msgLen = clientSocket.Receive(msg);
            // msgrec = Encoding.Unicode.GetString(msg, 0, msgLen);
            msgrec = Encoding.UTF8.GetString(msg, 0, msgLen);
            msgrec = Regex.Unescape(msgrec);

            return msgrec;
        }

        private async void PlayerButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            /*************
            MediaElement media = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream =
                await synth.SynthesizeTextToStreamAsync("游，gay");
            media.SetSource(stream, stream.ContentType);
            media.Play();
            ****************/
            clientSocket.Send(Encoding.UTF8.GetBytes("/login"));
            Receive();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            clientSocket.Connect("45.63.91.170", 20566);
            //clientSocket.Connect("127.0.0.1", 20567);

            //Receive();
            //Thread threadReceive = new Thread(Receive);
            //threadReceive.IsBackground = true;
            //threadReceive.Start();

            //clientSocket.Send(Encoding.UTF8.GetBytes("/login"));
            //clientSocket.Send(Encoding.UTF8.GetBytes("haha hgx12345"));
            //clientSocket.Send(Encoding.UTF8.GetBytes("/newMessage"));
            //clientSocket.Send(Encoding.UTF8.GetBytes("haha 1"));
            //clientSocket.Send(Encoding.UTF8.GetBytes("lalalala"));

        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //clientSocket.Send(Encoding.UTF8.GetBytes("arnold2 hgx12345"));
            //Receive();
            string username = Username.Text.Trim();
            int length = username.Length;
            string password = Password.Text.Trim();
            string newlogin = username + password;
            newlogin = newlogin.Insert(length, " ");
            clientSocket.Send(Encoding.UTF8.GetBytes(newlogin));
            string msg = Receive();
            if (msg == "/Successed\n")
            {

            }
            else
            {
                if (msg == "/WrongPassword\n")
                {
                    Loginmsg.Text = "密码错误，请检查后重试";
                }
                else if (msg == "/NoUsername\n")
                {
                    Loginmsg.Text = "用户名不存在";
                }
            }                      
        }

        private void SendButton1_Click(object sender, RoutedEventArgs e)
        {
            clientSocket.Send(Encoding.UTF8.GetBytes("/newMessage"));
            Receive();
        }

        private void SendButton2_Click(object sender, RoutedEventArgs e)
        {
            clientSocket.Send(Encoding.UTF8.GetBytes("User=kaka;;Anoymous=1;;Title=lalaka"));
            Receive();
        }

        private void SendButton3_Click(object sender, RoutedEventArgs e)
        {
            clientSocket.Send(Encoding.UTF8.GetBytes("啦啦啦啦 "));
            Receive();
        }

        private void GetButton1_Click(object sender, RoutedEventArgs e)
        {
            clientSocket.Send(Encoding.UTF8.GetBytes("/getMessages"));
            string msg = Receive1();
            /**********************************
            if (msg == "/sure")
            {
                clientSocket.Send(Encoding.UTF8.GetBytes("0"));
                msg = Receive1();
                string[] msglist = msg.Split();
                for (int i = 0; i < msglist.Length ; i++)
                {
                    //char[] flagf = { msg[i - 1], msg[i] };
                    //string flag = "]";
                    //if (flag == flagf[1].ToString())
                    if(msglist[i]=="]")
                    {
                        msglist[i] = "\n";
                        //flag = "\n";
                        //flagf = flag.ToCharArray();
                        //flagf = (char)92;
                    }
                    
                }
                //msg = msglist.Join();
                
                ViewText.Text = msglist.ToString();
                ***********************************************/
            ViewText.Text = msg;
        
        }
    

        private void GetButton2_Click(object sender, RoutedEventArgs e)
        {
            clientSocket.Send(Encoding.UTF8.GetBytes("0"));
            ViewText.Text = Receive1();
        }

        private void DetailButton1_Click(object sender, RoutedEventArgs e)
        {
            clientSocket.Send(Encoding.UTF8.GetBytes("/getDetals"));
            Receive();
        }

        private void DetailButton2_Click(object sender, RoutedEventArgs e)
        {
            clientSocket.Send(Encoding.UTF8.GetBytes("2"));
            ViewTextDetail.Text = "这里查看动态详情\n" + Receive1();
        }
    }
}
