using Data.Model;
using RealmDigital.BusinessLogic.Interfaces;
using RealmDigital.Messenger.Interfaces;
using RealmDigital.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmDigital.BusinessLogic.InterfacesImpl
{
    class EmployeeSendMessage : IEmployeeSendMessage
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMessagingSender _messaging;
        private readonly string _emailAddress;

        public EmployeeSendMessage(IEmployeeRepository repository, IMessagingSender messaging)
        {
            _repository = repository;
            _messaging = messaging;
            _emailAddress = "youremail@gmail.com";
        }
        public async Task SendBirthdayMessagesAsync()
        {
            var eligibleEmployees = await FilterEmployeeToReceiveNotifications();

            //loop through eligible people and send the email.
            foreach(Employee employee in eligibleEmployees)
            {
                var message = $"Happy Birthday {employee.GetFullName()}";
                await _messaging.SendHappyBirthdayEmail(_emailAddress, message);
            }

        }

        /// <summary>
        /// Send Work anniversary message
        /// </summary>
        /// <returns></returns>
        public Task SendWorkAnniversayMessagesAsync()
        {
            throw new NotImplementedException();
        }

        //send
        public async Task <IEnumerable<Employee>> FilterEmployeeToReceiveNotifications()
        {
            var employees = await _repository.GetAllEmployeesAsync();

            var excludedEmployeeeIds = await _repository.GetExcludedEmployeeIdsAsync();

            var eligibleEmployees = employees.Where(employee => !excludedEmployeeeIds.Contains(employee.id) && employee.employmentStartDate > DateTimeOffset.Now);

            return eligibleEmployees;
        }
    }
}
