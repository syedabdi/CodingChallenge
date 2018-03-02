using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    [TestClass]
    public class TestGetEmployee :TestBase
    {
        [TestMethod]
        public void TestGet()
        {

            using (_context)
            {
                var service = new EmployeeRespository(_context, _mockLogging.Object, _mockRules);
                var test = service.GetAllEmployees();
                Assert.IsNotNull(test);
            }

        }
    }
}
