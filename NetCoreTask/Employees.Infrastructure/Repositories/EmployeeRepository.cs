using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Employees.Core.Interfaces.Repositories;
using Employees.Infrastructure.DbContexts;
using Employees.Core.Dtos;
using Employees.Infrastructure.Entities;
using Employees.Core.Entities;
using Employees.Infrastructure.Extensions;
using RDO.Infrastructure.Repositories;

namespace Employees.Infrastructure.Repositories
{
    public class EmployeeRepository : RepositoryBase, IEmployeeRepository
    {
        public EmployeeRepository(CommandDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(context, mapper, httpContextAccessor)
        {
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var Employees = await commandDb.Employees.Where(e=>!e.IsDeleted).ToListAsync();
            return mapper.Map<List<EmployeeDto>>(Employees);
        }
        public async Task<EmployeeDto> GetAsync(int EmployeeId)
        {
            var Employee = await commandDb.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == EmployeeId);

            return mapper.Map<EmployeeDto>(Employee);

        }
        public async Task<EmployeeDto> AddAsync(EmployeeDto EmployeeDto)
        {
            var entityToAdd = mapper.Map<Employee>(EmployeeDto);
            entityToAdd.CreatedOn = DateTime.Now;
            //entityToAdd.Id = //Guid.NewGuid();
            await commandDb.Employees.AddAsync(entityToAdd);
            await commandDb.SaveChangesAsync();
            EmployeeDto.Id = entityToAdd.Id;
            return EmployeeDto;
        }

        public async Task<EmployeeDto> UpdateAsync(EmployeeDto EmployeeDto)
        {
            var entityToUpdate = await commandDb.Employees
                .FirstOrDefaultAsync(s => s.Id == EmployeeDto.Id);
            mapper.Map(EmployeeDto, entityToUpdate);
            entityToUpdate.Id = EmployeeDto.Id.Value;
            await commandDb.SaveChangesAsync();
            return mapper.Map(entityToUpdate, EmployeeDto);
        }

        public async Task DeleteAsync(int empId)
        {
            var entityToDelete = await commandDb.Employees.FindAsync(empId);
            entityToDelete.IsDeleted = true;
            await commandDb.SaveChangesAsync();
        }
    }
}