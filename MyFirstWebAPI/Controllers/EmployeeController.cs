using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPI.Models;
namespace MyFirstWebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase

    {
        // In memory list of employees instead of db for now

        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Jayesh", Department = "DEV" },
            new Employee { Id = 2, Name = "Pawan", Department = "PRODUCTION" }
        };

        // GET METHOD : api/employee
        [HttpGet]
         public ActionResult<List<Employee>> GetEmployees()
        {
            return Ok(employees);
        }


        // POST: api/employees
        [HttpPost]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee employee)
        {
            employee.Id = employees.Max(e => e.Id) + 1; // auto increment Id
            employees.Add(employee);
            return CreatedAtAction(nameof(GetEmployees), new { id = employee.Id }, employee);
        }

        // Put METHOD : api/employee'

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if(employee == null ) 
                return NotFound();

            employee.Name = updatedEmployee.Name; 
            employee.Department = updatedEmployee.Department;

            return NoContent(); // done
        }

        // Delete METHOD : api/employee/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();
            employees.Remove(employee);
            return NoContent(); // done
        }


    }
}
