using TicketApp;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Ticket_Web_App.Services.Interfaces;

namespace WebTest1.Services.Implementation
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
