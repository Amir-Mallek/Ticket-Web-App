using Ticket_Web_App.Dtos.Response;
using TicketApp;

namespace Ticket_Web_App.Mappers.Response
{
    public static class SystemUserResponseMapper
    {
        public static SystemUserResponseDto Map(SystemUser systemUser)
        {
            return new SystemUserResponseDto
            {
                Id = systemUser.Id,
                FullName = systemUser.FullName,
                Email = systemUser.InternalEMailAddress,
                Phone = systemUser.Address1_Telephone1
            };
        }
    }
}
