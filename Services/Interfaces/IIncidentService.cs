using TicketApp;

namespace Ticket_Web_App.Services.Interfaces
{
    public interface IIncidentService
    {
        void AssignToAgent(Guid incidentId, Guid agentId);
    }
}
