namespace EmployeeAdminPortal.Models.DTO
{
    public class EmployeeResponseDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Phone { get; set; }
        public decimal Salary { get; set; }
        public UserDto? User { get; set; }
    }
}
