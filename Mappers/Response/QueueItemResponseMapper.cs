using Ticket_Web_App.Dtos.Response;
using TicketApp;

namespace Ticket_Web_App.Mappers.Response
{
    public class QueueItemResponseMapper
    {
        public static QueueItemResponseDto Map(QueueItem queueitem)
        {
            return new QueueItemResponseDto
            {
                Id = queueitem.Id,
                IncidentId = queueitem.ObjectId.Id
            };
        }
    }
}
