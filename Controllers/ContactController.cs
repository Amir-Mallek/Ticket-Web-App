using Microsoft.AspNetCore.Mvc;
using Ticket_Web_App.Dtos.Request;
using Ticket_Web_App.Dtos.Response;
using Ticket_Web_App.IServices;
using Ticket_Web_App.Mappers;
using TicketApp;

namespace Ticket_Web_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ICrmRepository<Contact> _contactRepo;

        public ContactController(ICrmRepository<Contact> contactRepo)
        {
            _contactRepo = contactRepo;
        }

        [HttpGet()]
        public List<ContactResponseDto> GetContacts([FromQuery] ContactFilterDto filter)
        {
            var query = ContactFilterMapper.Map(filter);
            return _contactRepo
                .RetrieveMultiple(query)
                .Select(e => ContactResponseMapper.Map(e))
                .ToList();
        }

        [HttpGet("{id}")]
        public ContactResponseDto GetContact(Guid id)
        {
            return ContactResponseMapper.Map(_contactRepo.Retrieve(id));
        }

        [HttpPost()]
        public Guid CreateContact([FromBody] CreateContactDto createContactDto)
        {
            var contact = CreateContactMapper.Map(createContactDto);
            return _contactRepo.Create(contact);
        }

        [HttpPut("{id}")]
        public void UpdateContact(Guid id, [FromBody] UpdateContactDto updateContactDto)
        {
            var contact = UpdateContactMapper.Map(updateContactDto, id);
            _contactRepo.Update(contact);
        }

        [HttpDelete("{id}")]
        public void DeleteContact(Guid id)
        {
            _contactRepo.Delete(id);
        }
    }
}
