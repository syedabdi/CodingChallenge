using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EmployeeDBSeeder
    {
        private readonly EmployeeContext _ctx;
        private readonly IHostingEnvironment _hosting;

        public EmployeeDBSeeder(EmployeeContext ctx,
          IHostingEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            //var user = await _userManager.FindByEmailAsync("abdisyed20@gmail.com");

            //if (user == null)
            //{
            //    user = new AuthorizedUser()
            //    {
            //        FirstName = "Syed",
            //        LastName = "Abdi",
            //        UserName = "syed20",
            //        Email = "abdisyed20@gmail.com"
            //    };

            //    var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
            //    if (result != IdentityResult.Success)
            //    {
            //        throw new InvalidOperationException("Failed to create default user");
            //    }
            //}

            if (!_ctx.Employees.Any())
            {
                var employee =
                new Employee()
                {
                    FirstName = "Syed",
                    LastName = "Abdi",
                    Dependents = new List<Info>()
                     {
                         new Info()
                         {
                         FirstName = "Stephen",
                         LastName = "King",
                         },
                     }
                };


                _ctx.Employees.Add(employee);

                _ctx.SaveChanges();

            }
         }
        }
    }

