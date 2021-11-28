using Employees.Core.Dtos;
using Employees.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Core.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<ReturnResult<List<EmployeeDto>>> GetAllAsync();
        Task<ReturnResult<EmployeeDto>> GetAsync(int EmpId);
        Task<ReturnResult<EmployeeDto>> AddAsync(EmployeeDto EmployeeDto);
        Task<ReturnResult<EmployeeDto>> UpdateAsync(EmployeeDto EmployeeDto);
        Task<ReturnResult<bool>> DeleteAsync(int EmpId);
    }
}
