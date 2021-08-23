using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealmDigital.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<IEnumerable<int>> GetExcludedEmployeeIdsAsync();
    }
}
