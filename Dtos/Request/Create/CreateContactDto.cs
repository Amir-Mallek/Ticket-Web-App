using Ticket_Web_App.Enums;

namespace Ticket_Web_App.Dtos.Request.Create
{
    public class CreateContactDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Guid? ParentClientId { get; set; }
        public ClientType? ParentClientType { get; set; }
    }
}
