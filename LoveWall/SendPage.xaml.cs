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
    public sealed partial class SendPage : Page
    {
        HongDouClass hongdou = new HongDouClass();

        public SendPage()
        {
            this.InitializeComponent();
            hongdou.Connect();
            
        }

        public string Checked()
        {
            string checkedStatus;
            if ((bool) AnoymousCheck.IsChecked)
            {
                checkedStatus = ";;Anoymous=1;;";
            }
            else
            {
                checkedStatus = ";;Anoymous=0;;";
            }

            return checkedStatus; 
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (App.Loginstatus)
            {
                hongdou.Send("/newMessage");
                hongdou.Receive();
                string msg = "";
                string username = "User=" + App.staUsername;
                string anoymous = Checked();
                string title = "Title=" + TitleText.Text.Trim();
                msg = username + anoymous + title;
                hongdou.Send(msg);
                hongdou.Receive();
                msg = MessageText.Text.Trim();
                hongdou.Send(msg);
            }
            else
            {
                MessegaText.Text = "你还没有登录，请登录后再进行操作";
            }

        }
    }
}
