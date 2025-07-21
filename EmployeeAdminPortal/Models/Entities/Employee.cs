using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
         [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public string? Phone { get; set; }

        public decimal Salary { get; set; }

        // Navigation property for one-to-one relation
        public User? User { get; set; }


    }
}
