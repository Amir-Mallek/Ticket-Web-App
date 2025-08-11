using Microsoft.AspNetCore.Mvc;
using Ticket_Web_App.Dtos.Request.Filter;
using Ticket_Web_App.Dtos.Response;
using Ticket_Web_App.IServices;
using Ticket_Web_App.Mappers.Request.Filter;
using Ticket_Web_App.Mappers.Response;
using TicketApp;

namespace Ticket_Web_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemUserController : ControllerBase
    {
        private readonly ICrmRepository<SystemUser> _systemUserRepo;
        public SystemUserController(ICrmRepository<SystemUser> systemUserRepo)
        {
            _systemUserRepo = systemUserRepo;
        }

        [HttpGet()]
        public List<SystemUserResponseDto> GetSystemUsers([FromQuery] SystemUserFilterDto filter)
        {
            var query = SystemUserFilterMapper.Map(filter);
            return _systemUserRepo
                .RetrieveMultiple(query)
                .Select(e => SystemUserResponseMapper.Map(e))
                .ToList();
        }

        [HttpGet("{id}")]
        public SystemUserResponseDto GetSystemUser(Guid id)
        {
            return SystemUserResponseMapper.Map(_systemUserRepo.Retrieve(id));
        }
    }
}
