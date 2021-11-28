using Microsoft.Extensions.DependencyInjection;
using Employees.Core.Interfaces.Repositories;
using Employees.Core.Interfaces.Services;
using Employees.Infrastructure.Repositories;
using Employees.ServiceInterface;

namespace Employees.WebApi
{
    public static class ServiceCollectionSetup
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

    }
}

