using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealmDigital.BusinessLogic.Interfaces
{
    interface IEmployeeSendMessage
    {
        Task SendBirthdayMessagesAsync();
        Task SendWorkAnniversayMessagesAsync();
    }
}
