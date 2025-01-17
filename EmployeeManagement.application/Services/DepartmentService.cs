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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepositories _repository;

        public DepartmentService(IDepartmentRepositories repository)
        {
            _repository = repository;
        }

        public async Task AddDepartmentAsync(Department department)
        {
            await _repository.AddAsync(department);
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            var departments = await _repository.AllDepartment();


            var departmentDTOs = departments.Select(emp => new Department
            {
                Id = emp.Id,
                Name = emp.Name,

            }).ToList();
            return departmentDTOs;
        }

   

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            await _repository.UpdateAsync(department);
        }


        //public async Task<Department> GetDepartmentByIdAsync(int id)
        //{
        //    return await _repository.GetByIdAsync(id);
        //}

        //public async Task AddDepartmentAsync(Department department)
        //{
        //    await _repository.AddAsync(department);
        //}



        //public async Task DeleteDepartmentAsync(int id)
        //{
        //    await _repository.DeleteAsync(id);
        //}

        //public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        //{
        //    var departments = await _repository.AllDepartment;


        //    var departmentDTOs = departments.Select(emp => new Department
        //    {
        //        Id = emp.Id,
        //        Name = emp.Name,

        //    }).ToList();



        //    return DepartmentDTOs;

        //}

        //public async Task UpdateDepartmentAsync(Department department)
        //{
        //    await _repository.UpdateAsync(department);
        //}

        //public Task DeleteDepartmentAsync(Department department)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
