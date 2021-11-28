using Employees.Core.Dtos;
using Employees.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Employees.WebApi.Controllers
{
    [Route("api/Employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _EmployeeService;

        public EmployeesController(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _EmployeeService.GetAsync(id);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]EmployeeDto EmployeeDto)
        {
            var result = await _EmployeeService.AddAsync(EmployeeDto);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}