using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.DTO;
using EmployeeManagement.Application.Interfaces.Repositories;
using EmployeeManagement.Application.Interfaces.Services;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepositories _repository;

        public EmployeeService(IEmployeeRepositories repository)
        {
            _repository = repository;
        }

        //public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        //{
        //    return await _repository.GetAllAsync();
        //}

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _repository.AddAsync(employee);
        }



        public async Task DeleteEmployeeAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            var employees = await _repository.GetAllEmployee();


            var employeeDTOs = employees.Select(emp => new Employee
            {
                Id = emp.Id,
                Name = emp.Name,
                Email = emp.Email,
                Phone = emp.Phone,
                Gender = emp.Gender
            }).ToList();

            //var employeeDto = new EmployeeDTO()
            //{
            //    Id = employees.Id
            //}


            return employeeDTOs;

        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await _repository.UpdateAsync(employee);
        }

        public Task DeleteEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
    }

}
