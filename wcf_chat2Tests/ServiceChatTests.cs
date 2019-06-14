using Microsoft.VisualStudio.TestTools.UnitTesting;
using wcf_chat2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wcf_chat2.Tests
{
    [TestClass()]
    public class ServiceChatTests
    {
        [TestMethod()]
        public void ConnectTest()
        {
            string test = "vlad";
            int testtrue = 1;
            ServiceChat obj = new ServiceChat();
            int result = obj.Connect(test);
            Assert.AreEqual(testtrue, result);
        }

        [TestMethod()]
        public void DisconnectTest()
        {
            int testid = 1;
            ServiceChat obj = new ServiceChat();
            obj.Disconnect(testid);
            var user =ServiceChat.users.FirstOrDefault(i => i.ID == testid);
            Assert.AreEqual(user, null);
        }

        [TestMethod()]
        public void SendMsgTest()
        {
            string testanswer = "Abratam";
            int idtest2 = 1;
            ServiceChat obj = new ServiceChat();
            obj.SendMsg(testanswer, idtest2);
        }

      
    }
}