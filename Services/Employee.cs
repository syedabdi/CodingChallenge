using System;
using System.Collections.Generic;
using System.Text;
using DTO.Results;

namespace Services
{
    public class Employee : IEmployee
    {
        public IEnumerable<EmployeeDetails> GetEmployeeDetails()
        {
            throw new NotImplementedException();
        }
    }
}
