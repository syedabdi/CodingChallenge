using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    [TestClass]
    public class TestAddNewEmployee : TestBase
    {
        [TestMethod]
        public void TestAddNewEmp()
        {
            var emp = new DTO.Commands.AddEmployee
            {
                Employee = new DTO.Commands.Info
                {
                    FirstName = "Adam",
                    LastName = "John"
                },
                Dependents = new List<DTO.Commands.Info>
                {
                    new DTO.Commands.Info
                    {
                     FirstName = "John",
                     LastName = "Rambbo"
                    }
                }
            };

            var test = 0;
            using (_context)
            {
                var service = new EmployeeRespository(_context, _mockLogging.Object, _mockRules);
                test = service.Add(emp);
                Assert.AreNotEqual(test, 0);
            }

        }
    }
}
