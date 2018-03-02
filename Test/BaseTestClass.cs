using Data;
using DTO.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Test
{
    [TestClass]
    public class TestBase
    {

        protected EmployeeContext _context;
        protected Mock<IEmployeeRepository> _mockRepository = new Mock<IEmployeeRepository>();
        protected Mock<ILogger<EmployeeRespository>> _mockLogging = new Mock<ILogger<EmployeeRespository>>();
        protected IOptions<CompanyRules> _mockRules;

        [TestInitialize]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmployeeContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());

            _context = new EmployeeContext(optionsBuilder.Options);
            _context.Employees.AddRange(
                new Entities.Employee { FirstName = "Syed", LastName = "Test", Dependents = new List<Entities.Info> { new Entities.Info { FirstName = "Steve", LastName = "Test" } } },
                new Entities.Employee { FirstName = "Apple", LastName = "Test", Dependents = new List<Entities.Info> { new Entities.Info { FirstName = "Steve", LastName = "Test" } } }
                );

            _context.SaveChanges();
            var rules = new CompanyRules()
            {
                EmployeeCost = 1000,
                DependentCost = 500,
                NameDiscount = "a",
                NameDiscountPercentage = 10,
                PayCheck = 2000,
                TotalPayCheck = 26
            };
            _mockRules = Options.Create(rules);
        }
    }
}
