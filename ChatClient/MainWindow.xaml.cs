/*!
 * \file MainWindow.xaml
 * \version 1.0
 * \date 17-05-2019
 * \brief realizacja WPF i strony użytkownika
*/
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
        bool isConnected = false; //u użytkownika
        ServiceChatClient client; //!<obiekt Service w kliencie “MainWindow” dlatego żebyśmy mogli wykorzystywać metody ServiceChat
        int ID; //!<id użytkownika!< odpowiadające za przechowywanie informacji o podłączeni
        public MainWindow()
        {
            InitializeComponent();
        }

       


        /*!
         * \brief w metodzie “ConnectUser” u nowostworzonego obiektu typu “ISerwisChatClient” wywołujemy metodę “Connect”
         * określoną w interfejsie “IserwisChat”, do tej metody przesyłamy nazwę naszego klienta z textboxu.
         * Dalej stwarzamy dodatkowe pole danych ID, gdzie będzie przechowywane ID zwrócone z metody “Connect”. 
         */
        public void ConnectUser()
        {
            if (!isConnected)
            {
                client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
                ID = client.Connect(tbUserName.Text);
                tbUserName.IsEnabled = false;
                bConDiscon.Content = "Disconnect";
                isConnected = true;
            }
        }

        /*!
         * \brief w metodzie “Disconnect” u nowostworzonego obiektu typu “ISerwisChatClient” 
         * wywołujemy metodę “Disconnect” określoną w interfejsie “IserwisChat” do której przesyłamy ID z pola ID
         * klasy “MainWindow”. 
         */
       public void DisconnectUser()
        {
            if(isConnected)
            {
                client.Disconnect(ID);
                client = null;
                tbUserName.IsEnabled = true;
                bConDiscon.Content = "Connect";
                isConnected = false;
            }
        }


        /*!
         * \brief obsluguje wciśnięcie przyciska
         * \param sender
         * \param e
         */
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


        /*!
         * \brief realizacja msgCallback na stronie użytkownika 
         * \param msg
         */

        public void MsgCallback(string msg)
        {
            lbChat.Items.Add(msg);
            lbChat.ScrollIntoView(lbChat.Items[lbChat.Items.Count-1]);
        }


        /*!
         * \brief wydarzenie gdzie wywołujemy metodę “DisconectUser”, gdy nasz użytkownik naciska krzyżyk
         * \param sender
         * \param e
         */
        public void Windows_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconnectUser();
        }


        /*!
         * \brief  wydarzenie “Message_KeyDown” w którym, jeżeli jest naciśnięty przycisk “Enter”
         * zostaje wywołana metoda “SendMsg” do której my przesyłamy widomość z textboxu oraz ID
         * \param sender 
         * \param e
         */
        private void Message_keyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                if (client!=null)
                {
                    client.SendMsg(tbMessage.Text, ID);
                    tbMessage.Text = string.Empty;
                }
                
            }
        }
    }
}
