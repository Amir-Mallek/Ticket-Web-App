using Microsoft.Xrm.Sdk;
using Ticket_Web_App.Dtos.Request.Update;
using TicketApp;

namespace Ticket_Web_App.Mappers.Request.Update
{
    public class UpdateIncidentMapper
    {
        public static Incident Map(UpdateIncidentDto dto, Guid incidentId)
        {
            var incident = new Incident { Id = incidentId };

            if (dto.AgentId.HasValue)
                incident.OwnerId = new EntityReference("systemuser", dto.AgentId.Value);

            if (dto.Priority.HasValue)
                incident.PriorityCode = dto.Priority.Value;

            if (dto.Status.HasValue)
                incident.StatusCode = dto.Status.Value;

            if (!string.IsNullOrWhiteSpace(dto.Description))
                incident.Description = dto.Description;

            return incident;
        }
    }
}
