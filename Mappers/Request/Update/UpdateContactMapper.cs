using Microsoft.Xrm.Sdk;
using Ticket_Web_App.Dtos.Request.Update;
using TicketApp;

namespace Ticket_Web_App.Mappers.Request.Update
{
    public static class UpdateContactMapper
    {
        public static Contact Map(UpdateContactDto dto, Guid contactId)
        {
            var contact = new Contact { Id = contactId };
            if (!string.IsNullOrEmpty(dto.FirstName))
            {
                contact.FirstName = dto.FirstName;
            }
            if (!string.IsNullOrEmpty(dto.LastName))
            {
                contact.LastName = dto.LastName;
            }
            if (!string.IsNullOrEmpty(dto.Email))
            {
                contact.EMailAddress1 = dto.Email;
            }
            if (!string.IsNullOrEmpty(dto.Phone))
            {
                contact.Telephone1 = dto.Phone;
            }
            if (dto.ParentClientType.HasValue && dto.ParentClientId.HasValue)
            {
                var entityName = dto.ParentClientType.Value switch
                {
                    Enums.ClientType.Account => "account",
                    Enums.ClientType.Contact => "contact",
                    _ => throw new ArgumentException("Invalid parent client type", nameof(dto.ParentClientType))
                };
                contact.ParentCustomerId = new EntityReference(entityName, dto.ParentClientId.Value);
            }
            return contact;
        }
    }
}
