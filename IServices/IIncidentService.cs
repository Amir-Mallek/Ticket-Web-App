using TicketApp;

namespace Ticket_Web_App.IServices
{
    public interface IIncidentService
    {
        void AssignToAgent(Guid incidentId, Guid agentId);
    }
}
