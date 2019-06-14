/*!
 * \version 1.0
 * \date 17-05-2019
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcf_chat2
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
       public static List<ServerUser> users = new List<ServerUser>();
        int nextId = 1;

        /*!
         * \brief metoda stwarza nowego usera, dodaje go listy użytkowników, informuje innych użytkowników o podłączeniu
         *  aktualnego klienta i zwraca nowoutworzone ID podłączonego użytkownika.
         * \param name imię użytkownika
         */
        public int Connect(string name)
        {
            ServerUser user = new ServerUser() {
            ID = nextId,
            Name = name,
            operationContext = OperationContext.Current
            };
            nextId++;
            SendMsg(": "+ user.Name +" " + "connect to the chat",0);
            users.Add(user);
            return user.ID;
        }

        /*!
         * \brief  metoda za pomocy przesłanego jako parametr ID wyszukuje z listu odpowiedniego użytkownika i usuwa go z listy
         * podłączonych klientów, po czym informuje pozostałych podłączonych użytkowników 
         * o pozostawieniu chatu wyłączonym użytkownikiem. 
         * \param id unikatowa liczba
         */
        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(i => i.ID == id);
            if(user!=null)
            {
                users.Remove(user);
                SendMsg(": " + user.Name + " " + "left chat",0);
            }
        }
        /*!
         * \brief metoda generuje wiadomość, która składa się z imienia użytkownika , 
         *  bieżącej daty oraz bezpośredniej tekstowej wiadomości.
         *  Jeszcze ta metoda wywołuje metodę “MsgCallback” która będzie zrealizowana na stronie użytkownika.  
         * \param msg wiadomość do wysłania
         */
        public void SendMsg(string msg,int id)
        {
            foreach (var items in users)
            {
                string answer = DateTime.Now.ToShortTimeString();
                var user = users.FirstOrDefault(i => i.ID == id);
                if (user != null)
                {
                    answer += ":" + user.Name + " ";
                }
                answer += msg;
                items.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(answer);
            }

        }
    }
}
