using TicketApp;
using Microsoft.Xrm.Sdk;
using Ticket_Web_App.IServices;

namespace Ticket_Web_App.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly ICrmRepository<Incident> _incidentRepo;
        public IncidentService(ICrmRepository<Incident> incidentRepo) 
        {
            _incidentRepo = incidentRepo;
        }

        public void AssignToAgent(Guid incidentId, Guid agentId)
        {
            var incident = _incidentRepo.Retrieve(incidentId);
            incident.OwnerId = new EntityReference("systemuser", agentId);
            _incidentRepo.Update(incident);
        }
    }
}
