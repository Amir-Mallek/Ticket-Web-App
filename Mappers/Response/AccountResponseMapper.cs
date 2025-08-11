using Ticket_Web_App.Dtos.Response;
using TicketApp;

namespace Ticket_Web_App.Mappers.Response
{
    public static class AccountResponseMapper
    {
        public static AccountResponseDto Map(Account account)
        {
            return new AccountResponseDto
            {
                Id = account.Id,
                Name = account.Name,
                Email = account.EMailAddress1,
                Phone = account.Telephone1,
                Address = account.Address1_Composite,
                PrimaryContactId = account.PrimaryContactId?.Id
            };
        }
    }
}
