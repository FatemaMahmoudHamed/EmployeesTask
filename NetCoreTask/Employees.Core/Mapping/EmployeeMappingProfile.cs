using AutoMapper;
using Employees.Core.Dtos;
using Employees.Core.Entities;

namespace Employees.Core.Mapping
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            #region Employee
            CreateMap<EmployeeDto, Employee>()
                    .ForMember(s => s.Id, opt => opt.Ignore());

            CreateMap<Employee, EmployeeDto>();
            #endregion

        }
    }
}
