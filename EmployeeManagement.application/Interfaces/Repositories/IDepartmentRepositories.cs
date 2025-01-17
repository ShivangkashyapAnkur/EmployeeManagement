using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces.Repositories
{
    public interface IDepartmentRepositories
    {
       // Task<IEnumerable<object>> Department { get; }

        public Task<IEnumerable<Department>> GetAllDepartment();
        Task AddAsync(Department department);
        //Task<Department> GetByIdAsync(int id);
        Task UpdateAsync(Department department);
        Task DeleteAsync(int id);

        Task<IEnumerable<Department>> AllDepartment();
        Task<Department> GetByIdAsync(int id);
    }
}
