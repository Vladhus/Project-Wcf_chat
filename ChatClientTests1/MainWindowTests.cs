using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChatClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatClient.ServiceChat;

namespace ChatClient.Tests
{
    [TestClass()]
    public class MainWindowTests
    {
        [TestMethod()]
        public void ConnectUserTest()
        {





        }

        [TestMethod()]
        public void DisconnectUserTest()
        {
            ServiceChatClient client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
            int ID = 2;
            client.Disconnect(ID);
            ChatClient.MainWindow testss = new ChatClient.MainWindow();
            testss.DisconnectUser();


        }

        [TestMethod()]
        public void Windows_ClosingTest()
        {
            ChatClient.MainWindow testss = new ChatClient.MainWindow();
            testss.Windows_Closing();
        }
    }
}