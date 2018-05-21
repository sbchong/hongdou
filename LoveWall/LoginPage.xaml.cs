using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using LoveWall;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace HongDou
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        HongDouClass hongdou = new HongDouClass();

        public LoginPage()
        {
            this.InitializeComponent();
            //if (!App.Loginstatus)
            //{
                if (hongdou.Connect())
                {

                }
                else
                {

                }
            //}
           // else
           // {
           //     Frame.Navigate(typeof(UserPage));
            //}
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = Username.Text;
            string password = Password.Password;
            //string logininfo = hongdou.Login();
            if (hongdou.Login(username,password) == "登录成功")
            {
                App.Loginstatus = true;
                App.staUsername = username;
                Frame.Navigate(typeof(UserPage));
            }
            else
            {
                Loginmsg.Text = "登录失败，请检查用户名和密码";
            }
            
        }

        private void NewUserButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NewUserPage));
        }
    }
}
