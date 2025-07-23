using Microsoft.Xrm.Sdk;
using Ticket_Web_App.Dtos.Request;
using TicketApp;

namespace Ticket_Web_App.Mappers
{
    public static class CreateContactMapper
    {
        public static Contact Map(CreateContactDto dto)
        {
            var newContact = new Contact
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                EMailAddress1 = dto.Email,
                Telephone1 = dto.Phone
            };

            if (dto.ParentClientType.HasValue && dto.ParentClientId.HasValue)
            {
                var entityName = dto.ParentClientType.Value switch
                {
                    Enums.ClientType.Account => "account",
                    Enums.ClientType.Contact => "contact",
                    _ => throw new ArgumentException("Invalid parent client type", nameof(dto.ParentClientType))
                };
                newContact.ParentCustomerId = new EntityReference(entityName, dto.ParentClientId.Value);
            }
            
            return newContact;
        }
    }
}
