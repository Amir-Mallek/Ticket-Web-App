using Microsoft.AspNetCore.Mvc;
using Microsoft.Xrm.Sdk.Query;
using Ticket_Web_App.Dtos.Response;
using Ticket_Web_App.Mappers;
using Ticket_Web_App.Services.Interfaces;
using TicketApp;

namespace Ticket_Web_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncidentsController : ControllerBase
    {
        private readonly ICrmRepository<Incident> _incidentRepo;
        private readonly IIncidentService _incidentService;

        public IncidentsController(
            ICrmRepository<Incident> incidentRepo, 
            IIncidentService incidentService)
        {
            _incidentRepo = incidentRepo;
            _incidentService = incidentService;
        }

        [HttpGet()]
        public List<IncidentResponseDto> GetIncidents()
        {
            var query = new QueryExpression("incident");
            return _incidentRepo.RetrieveMultiple(query).Select(e => IncidentResponseMapper.Map(e)).ToList();
        }

        [HttpGet("{id}")]
        public IncidentResponseDto GetIncident(Guid id) {
            return IncidentResponseMapper.Map(_incidentRepo.Retrieve(id));
        }
    }
}
