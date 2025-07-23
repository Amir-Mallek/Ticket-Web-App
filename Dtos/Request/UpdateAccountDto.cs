namespace Ticket_Web_App.Dtos.Request
{
    public class UpdateAccountDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public Guid? PrimaryContactId { get; set; }
    }
}
