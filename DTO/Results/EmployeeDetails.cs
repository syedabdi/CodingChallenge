using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Results
{
    public class EmployeeDetails:Info
    {
        public int Id { get; set; }
        public bool NameDiscountFlag { get; set; }
        public double PayCheckAfterDeductions { get; set; }
        public double EmployeePremium { get; set; }
        public double DependentsPremium { get; set; }
        public IEnumerable<Info> Dependents { get; set; }
    }
}
