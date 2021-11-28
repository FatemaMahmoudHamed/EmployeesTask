using Employees.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Core.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto> GetAsync(int EmpId);
        Task<EmployeeDto> AddAsync(EmployeeDto EmployeeDto);
        Task<EmployeeDto> UpdateAsync(EmployeeDto EmployeeDto);
        Task DeleteAsync(int EmpId);
    }
}