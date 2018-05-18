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
using HongDou;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace LoveWall
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        string msgrec = "";
        public MainPage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(HomePage));
           // BackButton.Width = 0;
            /**************************************************************
            try
            {
                clientSocket.Connect("45.63.91.170", 20566);
                clientSocket.Send(Encoding.UTF8.GetBytes("/getMessages"));
                msgrec = Receive1();
                if (msgrec == "/sure\n")
                {
                    clientSocket.Send(Encoding.UTF8.GetBytes("0"));
                    msgrec = Receive1();
                }

                MyFrame.Navigate(typeof(HomePage),msgrec);
            }
            catch
            {

            }
            ************************************************************/
        }

        


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MyFrame.CanGoBack)
            {
                MyFrame.GoBack();
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(HomePage));
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(LoginPage));
        }

        private void MyMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HomeListBoxItems.IsSelected)
            {
                MyFrame.Navigate(typeof(HomePage));
                //if (MyFrame.Navigate(typeof(HomePage)))
                //{
                //    BackButton.Width = 0;
                //}
               // else
               // {
                 //   BackButton.Width = 50;
               // }
            }
            if (UserListBoxItems.IsSelected)
            {
                MyFrame.Navigate(typeof(LoginPage));
                //if (MyFrame.Navigate(typeof(HomePage)))
                //{
                //    BackButton.Width = 0;
               // }
              //  else
                //{
                 //   BackButton.Width = 50;
               // }
            }
        }
    }
}
