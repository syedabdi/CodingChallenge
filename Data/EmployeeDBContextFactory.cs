using AppSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Data
{
    public class EmployeeDBContextFactory : IDesignTimeDbContextFactory<EmployeeContext>
    {
        public EmployeeContext CreateDbContext(string[] args)
    {
       //DI is not aailable at the time of design thereofore we are not abke to inject parameters here like we did for CompanyRules
        var config = ConfigurationSettings.GetConfiguration(Directory.GetCurrentDirectory() + "\\..\\Api");
        var builder = new DbContextOptionsBuilder<EmployeeContext>();
        builder.UseSqlServer(ConfigurationSettings.GetDbConnectionString(config));

        return new EmployeeContext(builder.Options);
    }
  }
}
