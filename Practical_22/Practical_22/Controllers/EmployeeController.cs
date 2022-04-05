using BAL;
using BAL.BAL_AbstractFactory;
using BAL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practical_22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly DepartmentFactory departmentFactory;
        private readonly FactoryType factoryType;

        public EmployeeController(ApplicationDBContext context, DepartmentFactory departmentFactory, FactoryType factoryType)
        {
            this.context = context;
            this.departmentFactory = departmentFactory;
            this.factoryType = factoryType;
        }
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] DALEmployee emp)
        {
            if (emp.Id == 0)
            {
                await context.Employees.AddAsync(emp);
                await context.SaveChangesAsync();
                return Ok(emp);
            }
            return BadRequest("Error in Adding Employee");
        }
        [HttpGet()]
        public async Task<ActionResult> GetEmployees(int? id)
        {
            if (id == null)
            {
                var result = await context.Employees.Include(x => x.Department).ToListAsync();
                await context.SaveChangesAsync();
                return Ok(result);
            }
            else if (id != null)
            {
                var result = await context.Employees.Include(x => x.Department).Where(x => x.Id == id).ToListAsync();
                return Ok(result);
            }
            return NotFound("Data Not found");
        }
        [HttpPut("EditEmployee/{id}")]
        public async Task<IActionResult> EditEmployee(int id, [FromBody] DALEmployee emp)
        {
            if (id == emp.Id)
            {
                context.Employees.Update(emp);
                await context.SaveChangesAsync();
                return Ok(emp);
            }
            return BadRequest("Error in Updation of Employee");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee != null)
            {
                employee.Status = true;
                context.Employees.Update(employee);
                await context.SaveChangesAsync();
                return Ok("Employee Delete Successfully");
            }
            return NotFound("Employee Can not Deleted");
        }
        [HttpGet("OvertimePayFactory")]
        public async Task<ActionResult> OvertimePay(int id, int hour)
        {
            if (id != 0)
            {
                var deptname = await context.Employees.Include(x => x.Department).Where(x => x.Id == id).Select(x => x.Department.Dept_Name).FirstOrDefaultAsync();
                var result = departmentFactory.Getobj(deptname);
                var overtimepay = result.MyOverTimePay(hour);
                return Ok(overtimepay);
            }
            return NotFound("Data Not found");
        }
        [HttpGet("OvertimePayAbstractFactory")]
        public async Task<ActionResult> OvertimePayAbstractFactory(int id, int hour, string factorytype)
        {
            if (id != 0)
            {
                var obj = factoryType.getfactorytype(factorytype);
                var deptname = await context.Employees.Include(x => x.Department).Where(x => x.Id == id).Select(x => x.Department.Dept_Name).FirstOrDefaultAsync();
                var result = obj.GetFactory(deptname);
                var overtimepay = result.MyOverTimePay(hour);
                return Ok(overtimepay);
            }
            return NotFound("Data Not found");
        }
    }
}
