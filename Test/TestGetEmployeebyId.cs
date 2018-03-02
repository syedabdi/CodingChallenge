using Data;
using DTO.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class TestGetEmployeebyId: TestBase
    {

        [TestMethod]
        public async void TestGetbyId()
        {
            var criteria = new SearchCriteria
            {
                Id = 1
            };

            using (_context)
            {
                var service = new EmployeeRespository(_context, _mockLogging.Object, _mockRules);
                var test = await Task.Run(()=>service.Search(criteria));          
                Assert.IsNotNull(test);
            }

        }

        //[TestMethod]
        //public void TestGetEmployeebyIdNull()
        //{

        //    var criteria = new SearchCriteria
        //    {
        //        Id = -1
        //    };

        //    using (_context)
        //    {
        //        var service = new EmployeeRespository(_context, _mockLogging.Object, _mockRules);
        //        var test = service.Search(criteria);
        //        Assert.IsNull(test.Result);
        //    }

        //}
    }
}
