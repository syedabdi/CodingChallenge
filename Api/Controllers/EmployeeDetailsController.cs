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
                _logger.LogError($"Failed to get Employee: {ex}");
                return BadRequest("Failed to get Employee");
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
                _logger.LogError($"Failed to get Employee: {ex}");
                return BadRequest("Failed to get Employee");
            }
        }

        [HttpPost]
        [Route("AddNewEmployee")]
        public IActionResult AddNewEmployee([FromBody]AddEmployee add)
        {
           try
            {
                return  Ok(_repository.Add(add));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save Employee: {ex}");
                return BadRequest("Failed to save Employee");
            }
        }


    }
}
