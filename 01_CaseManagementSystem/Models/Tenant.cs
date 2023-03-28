namespace _01_CaseManagementSystem.Models
{
    internal class Tenant
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string ErrorTitle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? UpdateComment { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string? Status { get; set; } = null!;
    }
}
