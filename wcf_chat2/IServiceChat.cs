﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcf_chat2
{
    
    [ServiceContract(CallbackContract =typeof(IServerChatCallback))]
    public interface IServiceChat
    {
        [OperationContract]
        int Connect();

        [OperationContract]
        void Disconnect(int id);

        [OperationContract(IsOneWay = true)]
        void SendMsg(string msg);
    }
    public interface IServerChatCallback
    {
        [OperationContract]
        void MsgCallback(string msg);
    }

}
