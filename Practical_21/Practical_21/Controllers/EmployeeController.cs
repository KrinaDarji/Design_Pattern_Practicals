using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practical_21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Service service;

        public EmployeeController(Service service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee) {
            var result = await service.AddEmployee(employee);
            if (result)
            {
                return Ok(employee);
            }
            return BadRequest("Error occuring while adding employee!!!");
        }
        [HttpGet]
        public async Task<List<Employee>> GetAllEmployee()
        {
            var employees = await service.GetAllEmployees();
            return employees;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            try
            {
                if (id == employee.Id)
                {
                    await service.UpdateEmployee(employee);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await service.IsEmployeeExist(id))
                {
                    return NotFound();
                }
                throw;
            }
            return Ok("Updated Successfull");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await service.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            await service.DeleteEmployee(id);
            return Ok("Deleted Successfull");
        }
    }
}
