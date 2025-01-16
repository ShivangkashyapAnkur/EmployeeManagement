using EmployeeManagement.Application.Interfaces.Services;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> EmployeeList()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.AddEmployeeAsync(employee);
                return RedirectToAction(nameof(EmployeeList));
            }
            return View(employee);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();
      
            return View(employee);
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.UpdateEmployeeAsync(employee);
                return RedirectToAction(nameof(EmployeeList));
            }
            return View(employee);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();
            return View(employee);
            return null;
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           await _employeeService.DeleteEmployeeAsync(id);
            return RedirectToAction(nameof(EmployeeList));
        }
    }


}
