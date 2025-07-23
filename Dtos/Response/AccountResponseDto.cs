namespace Ticket_Web_App.Dtos.Response
{
    public class AccountResponseDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public Guid? PrimaryContactId { get; set; }
    }
}
