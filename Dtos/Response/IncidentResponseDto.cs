using Ticket_Web_App.Enums;
using TicketApp;

namespace Ticket_Web_App.Dtos.Response
{
    public class IncidentResponseDto
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string TicketNumber { get; set; }
        public Guid ClientId { get; set; }
        public ClientType ClientType { get; set; }
        public Guid AgentId { get; set; }
        public incident_prioritycode? Priority { get; set; }
        public incident_caseorigincode? Origin { get; set; }
        public incident_statuscode? Status { get; set; }
        public string? Description { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
