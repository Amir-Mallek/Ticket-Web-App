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
    public class AccountController : ControllerBase
    {
        private readonly ICrmRepository<Account> _accountRepo;

        public AccountController(ICrmRepository<Account> accountRepo)
        {
            _accountRepo = accountRepo;
        }

        [HttpGet()]
        public List<AccountResponseDto> GetAccounts([FromQuery] AccountFilterDto filter)
        {
            var query = AccountFilterMapper.Map(filter);
            return _accountRepo
                .RetrieveMultiple(query)
                .Select(e => AccountResponseMapper.Map(e))
                .ToList();
        }

        [HttpGet("{id}")]
        public AccountResponseDto GetAccount(Guid id) 
        {
            return AccountResponseMapper.Map(_accountRepo.Retrieve(id));
        }

        [HttpPost()]
        public Guid CreateAccount([FromBody] CreateAccountDto createAccountDto)
        {
            var account = CreateAccountMapper.Map(createAccountDto);
            return _accountRepo.Create(account);
        }

        [HttpPut("{id}")]
        public void UpdateAccount(Guid id, [FromBody] UpdateAccountDto updateAccountDto)
        {
            var account = UpdateAccountMapper.Map(updateAccountDto, id);
            _accountRepo.Update(account);
        }

        [HttpDelete("{id}")]
        public void DeleteAccount(Guid id)
        {
            _accountRepo.Delete(id);
        }
    }
}
