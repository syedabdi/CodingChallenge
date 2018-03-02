using DTO.Results;
using System;
using System.Collections.Generic;

namespace Services
{
    public interface IEmployee
    {
        IEnumerable<EmployeeDetails> GetEmployeeDetails();
    }
}
