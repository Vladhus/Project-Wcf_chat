/*!
 * \file ServerUser.cs
 * \version 1.0
 * \date 17-05-2019
 */ 
using System.ServiceModel;

namespace wcf_chat2
{
    public class ServerUser
    {
        public int ID { get; set; } //!< unikatowa liczba
        public string Name { get; set; } //!< imię użytkownika

        public OperationContext operationContext { get; set; } //!<informacja jaka jest wykorzystywana na stronie klienta

    }
}
