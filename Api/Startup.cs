using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using DTO.Results;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Api
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration config, IHostingEnvironment env)
        {
            _config = config;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {



            services.AddMvc();
            services.AddOptions();

            services.Configure<CompanyRules>(_config.GetSection("CompanyRules"));

            ////var connectionString = Configuration["EmployeeDBConnectionString"];
            services.AddDbContext<EmployeeContext>(cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("EmployeeDBConnectionString"));

            });

            // register the repository
            services.AddScoped<IEmployeeRepository, EmployeeRespository>();
            services.AddTransient<EmployeeDBSeeder>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .AllowCredentials());
            app.UseMvc();

            // Seed the database
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<EmployeeDBSeeder>();
                seeder.Seed();
            }
        }
    }
}
