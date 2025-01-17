using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.Interfaces.Repositories;
using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class DepartmentRepositories : IDepartmentRepositories
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

    

        public async Task AddAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Department>> AllDepartment()
        {
                var departments= await _context.Departments.ToListAsync();


            var departmentDTOs = departments.Select(emp => new Department
            {
                Id = emp.Id,
                Name = emp.Name
           

            }).ToList();


            return departmentDTOs;
        }

        public async Task DeleteAsync(int id)
        {
            var department = await GetByIdAsync(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<Department>> GetAllDepartment()
        {
            throw new NotImplementedException();
        }

      

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

      

        public async Task UpdateAsync(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
        }
    }
}
