using AutoMapper;
using Employees.Core.Mapping;
using Employees.Infrastructure.DbContexts;
using Employees.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Employees.Port
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EmployeeMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<CommandDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:Default"],
                    sqlOption =>
                    {
                        sqlOption.MigrationsAssembly("Employees.Infrastructure");
                    });
            });
            //  Add AutoMapper ==> 
            //  Install - Package AutoMapper - Version 10.0.0
            //  Install - Package AutoMapper.Extensions.Microsoft.DependencyInjection - Version 8.0.1
            services.AddAutoMapper();


            services.AddLocalization();

            // Get the configrations from appsettings.json

            // Configure application services.
            services.AddServices();

            // Configure repositories.
            services.AddRepositories();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Employees}/{action=Index}/{id?}");
            });
        }
    }
}
