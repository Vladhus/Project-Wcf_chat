using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChatClient.ServiceChat;

namespace ChatClient
{

    public partial class MainWindow : Window,IServiceChatCallback
    {
        bool isConnected = false;
        ServiceChatClient client;
        int ID;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
        }
        void ConnectUser()
        {
            if (!isConnected)
            {
                ID = client.Connect(tbUserName.Text);
                tbUserName.IsEnabled = false;
                bConDiscon.Content = "Disconnect";
                isConnected = true;
            }
        }
            void DisconnectUser()
        {
            if(isConnected)
            {
                client.Disconnect(ID);
                tbUserName.IsEnabled = true;
                bConDiscon.Content = "Connect";
                isConnected = false;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                DisconnectUser();
            }
            else
            {
                ConnectUser();
            }
        }

        public void MsgCallback(string msg)
        {
            lbChat.Items.Add(msg);
        }

        private void Windows_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconnectUser();
        }

       

        private void Message_keyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
