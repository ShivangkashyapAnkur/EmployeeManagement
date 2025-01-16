using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.DTO;
using EmployeeManagement.Application.Interfaces.Repositories;
using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class EmployeeRepositories : IEmployeeRepositories
    {
           private readonly ApplicationDbContext _context;

          public EmployeeRepositories(ApplicationDbContext context)
           {
              _context = context;
           }

        public Task<IEnumerable<object>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        //    public async Task<IEnumerable<Employee>> GetAllAsync()
        //    {
        //        return await _context.Employees.ToListAsync();
        //    }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await GetByIdAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            
            var employees = await _context.Employees.ToListAsync();

            
            var employeeDTOs =  employees.Select(emp => new Employee
            {
                Id = emp.Id,
                Name = emp.Name,
                Email = emp.Email,
                Gender = emp.Gender,
                Phone = emp.Phone,

            }).ToList();

            
            return employeeDTOs;
        }

        
    }

}
