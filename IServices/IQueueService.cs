using TicketApp;

namespace Ticket_Web_App.IServices
{
    public interface IQueueService
    {
        List<QueueItem> GetQueueItems(Guid agentId);
        void TransferQueueItem(Guid incidentId, Guid targetAgentId);
        void AcceptQueueItem(Guid queueItemId, Guid agentId);
        void RejectQueueItem(Guid queueItemId, Guid agentId);
    }
}
