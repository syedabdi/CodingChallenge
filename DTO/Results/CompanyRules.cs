using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Results
{
    public class CompanyRules
    {
        public double EmployeeCost { get; set; }
        public double DependentCost { get; set; }
        public string NameDiscount { get; set; }
        public double NameDiscountPercentage { get; set; }
        public double PayCheck { get; set; }
        public int TotalPayCheck { get; set; }
    }
}
