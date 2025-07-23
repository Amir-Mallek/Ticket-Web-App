using Ticket_Web_App.Dtos.Response;
using Ticket_Web_App.Enums;
using TicketApp;

namespace Ticket_Web_App.Mappers
{
    public static class IncidentResponseMapper
    {
        public static IncidentResponseDto Map(Incident incident)
        {
            return new IncidentResponseDto
            {
                Id = incident.Id,
                Title = incident.Title,
                TicketNumber = incident.TicketNumber,
                ClientId = incident.CustomerId.Id,
                ClientType = incident.CustomerId.LogicalName switch
                {
                    "account" => ClientType.Account,
                    "contact" => ClientType.Contact,
                    _ => ClientType.Contact
                },
                AgentId = incident.OwnerId.Id,
                Priority = incident.PriorityCode,
                Origin = incident.CaseOriginCode,
                Status = incident.StatusCode,
                Description = incident.Description,
                CreatedBy = incident.CreatedBy.Id,
                CreatedOn = incident.CreatedOn
            };
        }
    }
}
