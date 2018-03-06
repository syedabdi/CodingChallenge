using DTO.Commands;
using DTO.Queries;
using DTO.Results;
using Entities;
using Fns;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EmployeeRespository : IEmployeeRepository
    {
        private readonly EmployeeContext _ctx;
        private readonly ILogger<EmployeeRespository> _logger;
        private readonly IOptions<CompanyRules> _rules;

        public EmployeeRespository(EmployeeContext ctx, ILogger<EmployeeRespository> logger, IOptions<CompanyRules> rules)
        {
            _ctx = ctx;
            _rules = rules;
            _logger = logger;
        }


       // used async call
        public EmployeeDetails Search(SearchCriteria query)
        {
            try
            {
                _logger.LogInformation("Search was called");

                var result =  _ctx.Employees
                         .Include(emp => emp.Dependents)
                         .FirstOrDefault(emp => emp.Id == query.Id);            
                return result == null ? null : EmployeeHelper.ConverttoEmployeeDetail(result, _rules.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get particular Employee: {ex}");
                return null;
            }

        }

        public IEnumerable<EmployeeDetails> GetAllEmployees()
        {
            try
            {
               _logger.LogInformation("GetAllEmployees was called");
             return _ctx.Employees
                            .Include(e => e.Dependents)
                            .Select(e => EmployeeHelper.ConverttoEmployeeDetail(e, _rules.Value))
                            .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all Employee: {ex}");
                return null;
            }
        }

        //public void  Delete(AddEmployee criteria)
        //{
        //    var deleted =  _ctx.Employees
        //                        .Include(e => e.Dependents)
        //                        .First(e => e.Id == criteria.Id);
        //    _ctx.Remove(deleted);
        //    _ctx.SaveChangesAsync();
        //}

        public int Add(AddEmployee emp)
        {
          try
            {
                _logger.LogInformation("Add new Employee");
                var result = new Entities.Employee
                {
                    FirstName = emp.Employee.FirstName,
                    LastName = emp.Employee.LastName,
                    Dependents = emp.Dependents.Select(ed => new Entities.Info
                    {
                        FirstName = ed.FirstName,
                        LastName = ed.LastName
                    }).ToList()
                };
                _ctx.Add(result);
                _ctx.SaveChanges();
                return result.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to add employee: {ex}");
                return 0;
            }
        }

    }
}
