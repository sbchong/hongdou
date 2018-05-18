using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace HongDou
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class HomePage : Page
    {
        private Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        string msgrec = "";
        HongDouClass hongdou = new HongDouClass();
       

        public HomePage()
        {
            this.InitializeComponent();
            hongdou.Connect();
            ViewText.Text= hongdou.ReceiveMessages();
            /*************************************************
            try
            {
                clientSocket.Connect("45.63.91.170", 20566);
                clientSocket.Send(Encoding.UTF8.GetBytes("/getMessages"));
                msgrec = hongdou.Receive1();
                if (msgrec == "/sure\n")
                {
                    clientSocket.Send(Encoding.UTF8.GetBytes("0"));
                    msgrec = hongdou.Receive1();
                    ViewText.Text = msgrec;
                }

                //MyFrame.Navigate(typeof(HomePage), msgrec);
            }
            catch
            {

            }
            ************************************************/

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //string  msgrec = (string)e.Parameter;
            //ViewText.Text = msgrec;
            //base.OnNavigatedFrom(e);
        }
    

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
           
            Frame.Navigate(typeof(SendPage));
        }
    }
}
