using Data.Model;
using RealmDigital.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Text.Json;

namespace RealmDigital.Repository.InterfaceImpl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HttpClient _httpClient;

        public EmployeeRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress =
             new Uri("https://interview-assessment-1.realmdigital.co.za/");
        }

        //retrieve all employees
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("employees");
            Stream responseBody = await response.Content.ReadAsStreamAsync();

            var employeeApiDto = await JsonSerializer.DeserializeAsync<List<Employee>>(responseBody);

            return employeeApiDto;

        }

        //retrieve only the IDs of employees to not send birthdays to....
        public async Task<IEnumerable<int>> GetExcludedEmployeeIdsAsync()
        {
            var response = await _httpClient.GetStringAsync("do-not-send-birthday-wishes");

            var excludedEmployeeIds = JsonSerializer.Deserialize<IEnumerable<int>>(response);

            if (excludedEmployeeIds == null)
            {
                throw new Exception("List of Employees is null");
            }

            return excludedEmployeeIds;
        }
    }
}
