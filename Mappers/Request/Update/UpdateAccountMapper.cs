using Microsoft.Xrm.Sdk;
using Ticket_Web_App.Dtos.Request.Update;
using TicketApp;

namespace Ticket_Web_App.Mappers.Request.Update
{
    public static class UpdateAccountMapper
    {
        public static Account Map(UpdateAccountDto dto, Guid accountId)
        {
            var updatedAccount = new Account
            {
                Id = accountId,
            };
            if (!string.IsNullOrEmpty(dto.Name))
            {
                updatedAccount.Name = dto.Name;
            }
            if (!string.IsNullOrEmpty(dto.Email))
            {
                updatedAccount.EMailAddress1 = dto.Email;
            }
            if (!string.IsNullOrEmpty(dto.Phone))
            {
                updatedAccount.Telephone1 = dto.Phone;
            }
            if (!string.IsNullOrEmpty(dto.Country))
            {
                updatedAccount.Address1_Country = dto.Country;
            }
            if (!string.IsNullOrEmpty(dto.City))
            {
                updatedAccount.Address1_City = dto.City;
            }
            if (!string.IsNullOrEmpty(dto.Street))
            {
                updatedAccount.Address1_Line1 = dto.Street;
            }
            if (!string.IsNullOrEmpty(dto.PostalCode))
            {
                updatedAccount.Address1_PostalCode = dto.PostalCode;
            }
            if (dto.PrimaryContactId.HasValue)
            {
                updatedAccount.PrimaryContactId = new EntityReference("contact", dto.PrimaryContactId.Value);
            }
            return updatedAccount;
        }
    }
}
