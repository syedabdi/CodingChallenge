using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public static class EmployeeDBSeed
    {
        public static void EnsureSeedDataForContext(this EmployeeContext context)
        {
            // first, clear the database.  This ensures we can always start 
            // fresh with each demo.  Not advised for production environments, obviously :-)

            context.Employees.RemoveRange(context.Employees);
            context.SaveChanges();

            // init seed data
            var employee = new List<Employee>()
            {
                new Employee()
                {
                     Id = 1,
                     FirstName = "Stehen",
                     LastName = "King",
                     Dependents = new List<Info>()
                     {
                         new Info()
                         {
                           FirstName = "Syed",
                           LastName = "Abdi"
                         }
                     }
                }
            };

            context.Employees.AddRange(employee);
            context.SaveChanges();
        }
    }
}
