using Ticket_Web_App.Dtos.Response;
using Ticket_Web_App.Enums;
using TicketApp;

namespace Ticket_Web_App.Mappers.Response
{
    public static class ContactResponseMapper
    {
        public static ContactResponseDto Map(Contact contact)
        {
            return new ContactResponseDto
            {
                Id = contact.Id,
                FullName = contact.FullName,
                Email = contact.EMailAddress1,
                Phone = contact.Telephone1,
                ParentClientId = contact.ParentCustomerId?.Id,
                ParentClientType = contact.ParentCustomerId?.LogicalName switch
                {
                    "account" => ClientType.Account,
                    "contact" => ClientType.Contact,
                    _ => ClientType.Contact
                }
            };
        }
    }
}
