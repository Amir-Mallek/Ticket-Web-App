using Microsoft.AspNetCore.Mvc;
using Ticket_Web_App.Dtos.Response;
using Ticket_Web_App.IServices;
using TicketApp;
using Ticket_Web_App.Mappers.Response;
using Ticket_Web_App.Mappers.Request.Filter;
using Ticket_Web_App.Mappers.Request.Create;
using Ticket_Web_App.Mappers.Request.Update;
using Ticket_Web_App.Dtos.Request.Filter;
using Ticket_Web_App.Dtos.Request.Create;
using Ticket_Web_App.Dtos.Request.Update;

namespace Ticket_Web_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncidentsController : ControllerBase
    {
        private readonly ICrmRepository<Incident> _incidentRepo;

        public IncidentsController(ICrmRepository<Incident> incidentRepo)
        {
            _incidentRepo = incidentRepo;
        }

        [HttpGet()]
        public List<IncidentResponseDto> GetIncidents([FromQuery] IncidentsFilterDto filter)
        {
            var query = IncidentsQueryMapper.Map(filter);
            return _incidentRepo
                .RetrieveMultiple(query)
                .Select(e => IncidentResponseMapper.Map(e))
                .ToList();
        }

        [HttpGet("{id}")]
        public IncidentResponseDto GetIncident(Guid id) {
            return IncidentResponseMapper.Map(_incidentRepo.Retrieve(id));
        }

        [HttpPost()]
        public Guid CreateIncident([FromBody] CreateIncidentDto createIncidentDto)
        {
            var incident = CreateIncidentMapper.Map(createIncidentDto);
            return _incidentRepo.Create(incident);
        }

        [HttpPut("{id}")]
        public void UpdateIncident(Guid id, [FromBody] UpdateIncidentDto updateIncidentDto)
        {
            var incident = UpdateIncidentMapper.Map(updateIncidentDto, id);
            _incidentRepo.Update(incident);
        }

        [HttpDelete("{id}")]
        public void DeleteIncident(Guid id)
        {
            _incidentRepo.Delete(id);
        }
    }
}
