using System;
using System.Collections;
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
using LoveWall;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;

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
            //ViewText.Text= 
            
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
            base.OnNavigatedTo(e);
            msgrec = hongdou.ReceiveMessages();
            string[] msg = msgrec.Split('[');
            msgrec = "";
            for (int i = 0; i < msg.Length; i++)
            {
                if (msg[i] != "")
                {
                    Image img = new Image();
                    //img.Source = new Uri(img.BaseUri, "Assets\anoymous.png");
                    //MasterListView.Items.Add(img + msg[i]);
                    MasterListView.Items.Add( msg[i]);
                }
            }

            //foreach (string str in msg)
            //{
            //msgrec = msgrec + str;

            //}            
            //msg = msgrec.Split(']');

            
            /********
            var items = MasterListView.ItemsSource ;

            if (items == null)
            {
                items = msg;

                //foreach (var item in ItemsDataSource.GetAllItems())
                //{
                for (int i = 1; i <= msg.Length; i++)
                {
                 //   items.Add(msg[i]);
                }
                //}

                MasterListView.ItemsSource = items;
            }

            //if (e.Parameter != null)
            //{
                // Parameter is item ID
             //   var id = (int)e.Parameter;
             //   _lastSelectedItem =
             //       items.Where((item) => item.ItemId == id).FirstOrDefault();
            //}

            //UpdateForVisualState(AdaptiveStates.CurrentState);

            // Don't play a content transition for first item load.
            // Sometimes, this content will be animated as part of the page transition.
            //DisableContentTransitions();
            //string  msgrec = (string)e.Parameter;
            //ViewText.Text = msgrec;
            //base.OnNavigatedFrom(e);
            ***************/
        }
    

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
           
            Frame.Navigate(typeof(SendPage));
        }

        private void MasterListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //int i = MasterListView.SelectedIndex;
            string msg = (string)e.ClickedItem;
            string[] msgindex = msg.Split(',');
            //for(int i = 0; i < 3; i++)
            //{
            App.getUsername = msgindex[1];
            App.DetailtextIndex = msgindex[0];
            //}
            Frame.Navigate(typeof(DetailPage));
        }
    }
}
