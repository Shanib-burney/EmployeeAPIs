using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeeAdminPortal.Models.Entities;

public class Role
{
    [Key]
    public int RoleId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

}
