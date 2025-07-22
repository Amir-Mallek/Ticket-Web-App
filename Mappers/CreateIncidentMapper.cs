using Microsoft.Xrm.Sdk;
using Ticket_Web_App.Dtos.Request;
using Ticket_Web_App.Enums;
using TicketApp;

namespace Ticket_Web_App.Mappers
{
    public static class CreateIncidentMapper
    {
        public static Incident Map(CreateIncidentDto dto)
        {
            string clientEntityName = dto.ClientType switch
            {
                ClientType.Account => "account",
                ClientType.Contact => "contact",
                _ => throw new ArgumentException("Invalid client type", nameof(dto.ClientType))
            };
            return new Incident
            {
                Title = dto.Title,
                CustomerId = new EntityReference(clientEntityName, dto.ClientId),
                OwnerId = new EntityReference("systemuser", dto.AgentId),
                PriorityCode = dto.Priority,
                CaseOriginCode = dto.Origin,
                StatusCode = dto.Status,
                Description = dto.Description
            };
        }
    }
}
