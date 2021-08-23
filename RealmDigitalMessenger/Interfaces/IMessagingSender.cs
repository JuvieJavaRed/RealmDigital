using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealmDigital.Messenger.Interfaces
{
    public interface IMessagingSender
    {
        Task SendHappyBirthdayEmail(string email, string message);
    }
}
