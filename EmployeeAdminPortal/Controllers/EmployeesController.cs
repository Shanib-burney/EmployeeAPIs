using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models.DTO;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
         var allEmployees = _dbContext.Employees.ToList();

            return Ok(allEmployees);

        }
        [HttpPost]
        public IActionResult InsertEmployee(CreateEmployeeRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Salary = request.Salary
            };

            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);

        }
        [HttpGet("{id}")]
        //[Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }
    }
}
