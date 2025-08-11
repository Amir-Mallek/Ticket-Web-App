using System.ComponentModel.DataAnnotations;
using TicketApp;

namespace Ticket_Web_App.Dtos.Request.Filter
{
    public class IncidentsFilterDto
    {
        public string? Title { get; set; }
        public string? TicketNumber { get; set; }
        public Guid? ClientId { get; set; }
        public Guid? AgentId { get; set; }
        public incident_prioritycode? Priority { get; set; }
        public incident_caseorigincode? Origin { get; set; }
        public incident_statuscode? Status { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedBefore { get; set; }
        public DateTime? CreatedAfter { get; set; }
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;
        [Range(1, 100)]
        public int PageSize { get; set; } = 10;
        public string? OrderBy { get; set; }
        public bool Descending { get; set; } = false;
    }
}
