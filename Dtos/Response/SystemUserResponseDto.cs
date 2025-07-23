namespace Ticket_Web_App.Dtos.Response
{
    public class SystemUserResponseDto
    {
        public Guid Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
    }
}
