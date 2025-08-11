using Ticket_Web_App.Enums;
using TicketApp;

namespace Ticket_Web_App.Dtos.Request.Create
{
    public class CreateIncidentDto
    {
        public required string Title { get; set; }
        public Guid ClientId { get; set; }
        public ClientType ClientType { get; set; }
        public Guid AgentId { get; set; }
        public incident_prioritycode Priority { get; set; } = incident_prioritycode.Normal;
        public incident_caseorigincode Origin { get; set; } = incident_caseorigincode.Phone;
        public incident_statuscode Status { get; set; } = incident_statuscode.InProgress;
        public string? Description { get; set; }
    }
}
