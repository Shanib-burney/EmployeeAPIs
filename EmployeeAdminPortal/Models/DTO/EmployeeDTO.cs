using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminPortal.Models.DTO
{
    public class CreateEmployeeRequestDto
    {
        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required, StringLength(100)]
        public required string Name { get; set; }
        public string? Phone { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }
    }
}
