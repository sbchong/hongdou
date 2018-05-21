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
    public sealed partial class NewUserPage : Page
    {
        HongDouClass hongdou = new HongDouClass();

        public NewUserPage()
        {
            this.InitializeComponent();
            hongdou.Connect();
        }

        public string Checked()
        {
            string checkedStatus;
            if ((bool)BoyChecked.IsChecked)
            {
                checkedStatus = "male";
            }
            else if ((bool)!BoyChecked.IsChecked && (bool)GirlChecked.IsChecked)
            {
                checkedStatus = "female";
            }
            else
            {
                checkedStatus = "请选择你的性别";
            }

            return checkedStatus;
        }

        private void NewUserButton_Click(object sender, RoutedEventArgs e)
        {
            hongdou.Send("/newUser");
            hongdou.Receive();
            string userName = "Name=" + Username.Text + ";;";
            string passWord = "Passwd=" + Password.Password + ";;";
            string passWordsure = "Passwd=" + PasswordSure.Password + ";;";
            if (Checked() == "请选择你的性别")
            {
                NewUsermsg.Text = Checked();
            }
            else
            {
                if (passWord == passWordsure)
                {
                    string usermessage = userName + passWord;
                    usermessage = usermessage + "Sex=" + Checked();
                    
                    hongdou.Send(usermessage);
                    hongdou.Receive();
                    App.Loginstatus = true;
                    App.staUsername = Username.Text;
                    Frame.Navigate(typeof(UserPage));
                }
                else
                {
                    NewUsermsg.Text = "两次密码不一致，请检查";
                }
            }
        }
    }
}
