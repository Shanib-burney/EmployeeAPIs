using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminPortal.Models.DTO
{
    public class CreateEmployeeRequestDto
    {
        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required, StringLength(100)]
        public required string Name { get; set; }

        [Required, StringLength(15, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{8,15}$", ErrorMessage = "Password must be 8-15 characters, include letters and numbers.")]
        public required string Password { get; set; }
    
        public string? Phone { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }
    }
}
