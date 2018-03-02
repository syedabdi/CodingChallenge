using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using DTO.Commands;
using DTO.Queries;
using DTO.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeDetailsController : Controller
    {
        private readonly IEmployeeRepository _repository;
        private readonly ILogger<EmployeeDetailsController> _logger;

        public EmployeeDetailsController(IEmployeeRepository repository, ILogger<EmployeeDetailsController> logger)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetEmployeeDetails()
        {
            try
            {
                return Ok(_repository.GetAllEmployees());
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Failed to get products");
            }
        }

        [HttpGet]
        [Route("GetEmployeebyId")]
        public IActionResult GetEmployeebyId(SearchCriteria srch)
        {
            try
            {
                return Ok(_repository.Search(srch));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get orders: {ex}");
                return BadRequest("Failed to get orders");
            }
        }

        [HttpPost]
        [Route("AddNewEmployee")]
        public IActionResult AddNewEmployee([FromBody]SearchCriteria srch)
        {

            var emp = new DTO.Commands.AddEmployee
            {
                Employee = new DTO.Commands.Info
                {
                    FirstName ="Adam",
                    LastName ="John"
                },
                Dependents =  new List<DTO.Commands.Info>
                {
                    new DTO.Commands.Info
                    {
                     FirstName = "John",
                     LastName = "Rambdo"
                    }
                }
            };

            try
            {
                return  Ok(_repository.Add(emp));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get orders: {ex}");
                return BadRequest("Failed to get orders");
            }
        }


    }
}
