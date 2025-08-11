using Ticket_Web_App.Enums;
using TicketApp;

namespace Ticket_Web_App.Dtos.Request.Update
{
    public class UpdateIncidentDto
    {
        public Guid? AgentId { get; set; }
        public incident_prioritycode? Priority { get; set; }
        public incident_statuscode? Status { get; set; }
        public string? Description { get; set; }
    }
}
