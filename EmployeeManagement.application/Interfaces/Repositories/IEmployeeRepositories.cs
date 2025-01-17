using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.DTO;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces.Repositories
{
    public interface IEmployeeRepositories
    {
      
        public Task <IEnumerable<Employee>> GetAllEmployee();
        Task AddAsync(Employee employee);
        Task<Employee> GetByIdAsync(int id);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
    }
}
