using AutoMapper;
using Employees.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Http;

namespace RDO.Infrastructure.Repositories
{
    public abstract class RepositoryBase
    {
        protected IMapper mapper;
        protected CommandDbContext commandDb;

        public RepositoryBase(CommandDbContext context, IMapper mapperConfig, IHttpContextAccessor httpContextAccessor)
        {
            commandDb = context;
            mapper = mapperConfig;
        }
    }

}
