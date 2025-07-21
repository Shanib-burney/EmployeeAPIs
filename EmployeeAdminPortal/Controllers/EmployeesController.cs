using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models.DTO;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;    


namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(ApplicationDbContext _dbContext) : ControllerBase
    {
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

            var existingEmployee = _dbContext.Users.FirstOrDefault(e => e.Email == request.Email);
            if (existingEmployee != null)
            {
                return BadRequest("An employee with this email already exists.");
            }
            Guid employeeId = Guid.NewGuid();

            // Hash the password before storing
            string password = "Admin@123";
            using var sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            string hashedPassword = Convert.ToBase64String(hashedBytes);

            var employee = new Employee
            {
                Id = employeeId,
                Name = request.Name,
                Phone = request.Phone,
                Salary = request.Salary,

            };

            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            var user = new User
            {
                EmployeeId = employeeId,
                Email = request.Email,
                Password = hashedPassword,
                IsActive = true
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();


            return Created($"/api/employees/{employee.Id}", request);

        }
        [HttpGet("{id}")]
        //[Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = _dbContext.Users.Include(e => e.Employee).FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }
    }
}
