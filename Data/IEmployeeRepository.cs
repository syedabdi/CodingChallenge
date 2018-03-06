using DTO.Commands;
using DTO.Queries;
using DTO.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeDetails> GetAllEmployees();
        EmployeeDetails Search(SearchCriteria query);
        int Add(AddEmployee command);
    }
}
