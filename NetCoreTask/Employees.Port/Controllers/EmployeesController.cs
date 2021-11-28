using Employees.Core.Dtos;
using Employees.Core.Interfaces.Services;
using Employees.Port.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Port.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = (await _employeeService.GetAllAsync()).Data;
            return View(employees);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,Phone,Address")] EmployeeDto empDto)
        {

            if (ModelState.IsValid)
            {
                await _employeeService.AddAsync(empDto);
                return RedirectToAction(nameof(Index));
            }
            return View(empDto);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var employee = (await _employeeService.GetAsync(id)).Data;
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Name,Email,Phone,Address")] EmployeeDto empDto)
        {

            if (ModelState.IsValid)
            {
                await _employeeService.UpdateAsync(empDto);
                return RedirectToAction(nameof(Index));
            }
            return View(empDto);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _employeeService.GetAsync(id.Value);
            if (emp.IsSuccess)
            {
                return View(emp.Data);
            }
            else
                return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
