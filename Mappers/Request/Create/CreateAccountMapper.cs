using Microsoft.Xrm.Sdk;
using Ticket_Web_App.Dtos.Request.Create;
using TicketApp;

namespace Ticket_Web_App.Mappers.Request.Create
{
    public static class CreateAccountMapper
    {
        public static Account Map(CreateAccountDto dto)
        {
            var newAccount = new Account
            {
                Name = dto.Name,
                EMailAddress1 = dto.Email,
                Telephone1 = dto.Phone,
                Address1_Country = dto.Country,
                Address1_City = dto.City,
                Address1_Line1 = dto.Street,
                Address1_PostalCode = dto.PostalCode,
            };

            if (dto.PrimaryContactId.HasValue)
            {
                newAccount.PrimaryContactId = new EntityReference("contact", dto.PrimaryContactId.Value);
            }

            return newAccount;
        }
    }
}
