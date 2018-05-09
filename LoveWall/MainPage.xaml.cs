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
            clientSocket.Send(Encoding.UTF8.GetBytes("haha hgx12345"));
            Receive();
        }
    }
}
