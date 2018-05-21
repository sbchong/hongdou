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
using Windows.UI.ViewManagement;
using Windows.UI;

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
            BackButton.Visibility = Visibility.Collapsed;            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var view = ApplicationView.GetForCurrentView();

            // active  
            //view.TitleBar.BackgroundColor = Color.FromArgb(255, 8, 87, 180);
            view.TitleBar.BackgroundColor = Colors.LightBlue;
            view.TitleBar.ForegroundColor = Colors.Black;

            // inactive  
            //view.TitleBar.InactiveBackgroundColor = Color.FromArgb(255, 8, 87, 180);
            
            view.TitleBar.InactiveForegroundColor = Colors.Black;

            // button  
            //view.TitleBar.ButtonBackgroundColor = Color.FromArgb(255, 8, 87, 180);
            view.TitleBar.ButtonForegroundColor = Colors.Black;

            view.TitleBar.ButtonHoverBackgroundColor = Colors.LightBlue;
            view.TitleBar.ButtonHoverForegroundColor = Colors.White;

            view.TitleBar.ButtonPressedBackgroundColor = Colors.LightBlue;
            view.TitleBar.ButtonPressedForegroundColor = Colors.White;

            view.TitleBar.ButtonInactiveBackgroundColor = Colors.DarkGray;
            view.TitleBar.ButtonInactiveForegroundColor = Colors.Gray;
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
                BackButton.Visibility = Visibility.Collapsed;
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
                if (!App.Loginstatus)
                {
                    MyFrame.Navigate(typeof(LoginPage));
                    BackButton.Visibility = Visibility.Visible;
                    //if (MyFrame.Navigate(typeof(HomePage)))
                    //{
                    //    BackButton.Width = 0;
                    // }
                    //  else
                    //{
                    //   BackButton.Width = 50;
                    // }
                }

                else
                {
                    MyFrame.Navigate(typeof(UserPage));
                    BackButton.Visibility = Visibility.Visible;
                }
            }
            if (SendListBoxItems.IsSelected)
            {
                MyFrame.Navigate(typeof(SendPage));
                BackButton.Visibility = Visibility.Visible;
            }
        }
    }
}
