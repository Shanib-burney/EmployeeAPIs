using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeeAdminPortal.Models.Entities;

public class User
{
    // Primary key and foreign key to Employee
    [Key]
    public Guid EmployeeId { get; set; }
    public required string Email { get; set; }


    public required string Password { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    public Employee? Employee { get; set; }

}
