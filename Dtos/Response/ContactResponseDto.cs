using Ticket_Web_App.Enums;

namespace Ticket_Web_App.Dtos.Response
{
    public class ContactResponseDto
    {
        public Guid Id { get; set; }
        public required string FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Guid? ParentClientId { get; set; }
        public ClientType? ParentClientType { get; set; }
    }
}
