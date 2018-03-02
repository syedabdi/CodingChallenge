using AppSettings;
using DTO.Results;
using System;
using System.IO;
using System.Linq;
using Entities;
using System.Collections.Generic;
using System.Reflection;

namespace Fns
{
    //Buisness Logic come here. It seperate our DAL layer from other layer so we can easily make any modification.
    //We can also create an Interface here and inject it inside our controllers

    public class EmployeeHelper
    {
        public EmployeeHelper()
        {
        }

        public EmployeeDetails ConverttoEmployeeDetail(Employee rec, CompanyRules rules)
        {
            var result = new EmployeeDetails();
                result = new EmployeeDetails
            {
                Id = rec.Id,
                FirstName = rec.FirstName,
                LastName = rec.LastName,
                Dependents = rec.Dependents !=null ? rec.Dependents.Select(x => new DTO.Results.Info
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName

                }) : new List<DTO.Results.Info>()              
            };

            result.NameDiscountFlag = GetNameDiscountFlag(result, rules.NameDiscount);
            result.PayCheckAfterDeductions = GetTotalPayCheckAfterDeductions(result.NameDiscountFlag, rules, result.Dependents.Count());

            return result;
        }

        public static bool GetNameDiscountFlag(EmployeeDetails rec, string name)
        {
            return (rec.FirstName.ToLower().StartsWith(name) || rec.Dependents.Any(x => x.FirstName.ToLower().StartsWith(name))) == true ? true : false;
        }

        public static double GetTotalPayCheckAfterDeductions(bool discountFlag, CompanyRules rules, int totalDependents = 0)
        {
            //if it take more then two steps make a seperate function for that

            var employeePreimium = rules.EmployeeCost / rules.TotalPayCheck;

            var dependentsPremium = totalDependents > 0 ? (GetDependendentPremium(rules.DependentCost,rules.TotalPayCheck,totalDependents)) : 0;

            var totalPreimium = employeePreimium + dependentsPremium;
            totalPreimium = discountFlag ? GetDiscount(rules.NameDiscountPercentage, totalPreimium) : totalPreimium;

            return rules.PayCheck - totalPreimium;  
        }

        public static double GetDependendentPremium(double depdendentCost, int totalPayCheck, int depdendents)
        {
           return (depdendentCost / totalPayCheck) * depdendents;
        }

        public static double GetDiscount(double discountPercentage, double Preimium)
        {
            return (Preimium * discountPercentage) * .01;
        }
    }
}
