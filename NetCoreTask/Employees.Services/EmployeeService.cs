using AutoMapper;
using Employees.Core.Dtos;
using Employees.Core.Entities;
using Employees.Core.Enums;
using Employees.Core.Interfaces.Repositories;
using Employees.Core.Interfaces.Services;
using Employees.Core.Models;
using Employees.Infrastructure.Entities;
using Employees.ServiceInterface.Validators.Others;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.ServiceInterface
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private IMapper _mapper;


    public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<ReturnResult<List<EmployeeDto>>> GetAllAsync()
        {
            try
            {
                var entities = await _employeeRepository.GetAllAsync();

                //var result = _mapper.Map<List<Employee>,List<EmployeeDto>>(entities);

                return new ReturnResult<List<EmployeeDto>>(true, HttpStatuses.Status200OK, entities);
            }
            catch (Exception ex)
            {
                return new ReturnResult<List<EmployeeDto>>
                {
                    IsSuccess = false,
                    StatusCode = HttpStatuses.Status500InternalServerError,
                    ErrorList = new List<string> { "Failed to add data" }

                };
            }
        }

    public async Task<ReturnResult<EmployeeDto>> GetAsync(int id)
    {
        try
        {
            var entitiy = await _employeeRepository.GetAsync(id);

            return new ReturnResult<EmployeeDto>
            {
                IsSuccess = true,
                StatusCode = HttpStatuses.Status200OK,
                Data = entitiy
            };
        }
        catch (Exception ex)
        {
            return new ReturnResult<EmployeeDto>
            {
                IsSuccess = false,
                StatusCode = HttpStatuses.Status500InternalServerError,
                ErrorList = new List<string> { "Failed to add data" }

            };
        }
    }

    public async Task<ReturnResult<EmployeeDto>> AddAsync(EmployeeDto model)
    {
        try
        {
            var errors = new List<string>();
            var EmployeeDto = new EmployeeDto();
            var validationResult = ValidationResult.CheckModelValidation(new EmployeeValidator(), model);
            if (!validationResult.IsValid)
            {
                errors.AddRange(validationResult.Errors);
                if (errors.Any())
                {
                    return new ReturnResult<EmployeeDto>
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatuses.Status400BadRequest,
                        ErrorList = errors,
                        Data = null
                    };
                }
            }

            EmployeeDto = await _employeeRepository.AddAsync(model);

            return new ReturnResult<EmployeeDto>
            {
                IsSuccess = true,
                StatusCode = HttpStatuses.Status201Created,
                Data = EmployeeDto
            };
        }
        catch (Exception ex)
        {
            return new ReturnResult<EmployeeDto>
            {
                IsSuccess = false,
                StatusCode = HttpStatuses.Status500InternalServerError,
                ErrorList = new List<string> { "Failed to add data" + ex.Message }
            };
        }
    }

    public async Task<ReturnResult<EmployeeDto>> UpdateAsync(EmployeeDto model)
    {
        try
        {
            var errors = new List<string>();

            var entity = await _employeeRepository.GetAsync(model.Id.Value);
            if (entity == null)
                return new ReturnResult<EmployeeDto>(false, HttpStatuses.Status404NotFound, model);

            var validationResult = ValidationResult.CheckModelValidation(new EmployeeValidator(), model);
            if (!validationResult.IsValid)
            {
                errors.AddRange(validationResult.Errors);
                if (errors.Any())
                {
                    return new ReturnResult<EmployeeDto>
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatuses.Status400BadRequest,
                        ErrorList = errors,
                        Data = null
                    };
                }
            }


            var EmployeeDto = await _employeeRepository.UpdateAsync(model);

            return new ReturnResult<EmployeeDto>
            {
                IsSuccess = true,
                StatusCode = HttpStatuses.Status201Created,
                Data = EmployeeDto
            };
        }
        catch (Exception ex)
        {
            return new ReturnResult<EmployeeDto>
            {
                IsSuccess = false,
                StatusCode = HttpStatuses.Status500InternalServerError,
                ErrorList = new List<string> { "Failed to add data" + ex.Message }
            };
        }
    }

    public async Task<ReturnResult<bool>> DeleteAsync(int id)
    {
        try
        {
            var entity = await _employeeRepository.GetAsync(id);
            if (entity == null)
                return new ReturnResult<bool>(false, HttpStatuses.Status404NotFound, false);

            await _employeeRepository.DeleteAsync(id);

            return new ReturnResult<bool>(true, HttpStatuses.Status200OK, true);
        }

        catch (Exception ex)
        {
            return new ReturnResult<bool>
            {
                IsSuccess = false,
                StatusCode = HttpStatuses.Status500InternalServerError,
                ErrorList = new List<string> { "حدث خطأ أثناء تنفيذ العملية، يرجى المحاولة لاحقاً." }
            };
        }
    }

    }
}
