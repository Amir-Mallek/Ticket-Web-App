using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Ticket_Web_App.IServices;
using TicketApp;

namespace Ticket_Web_App.Services
{
    public class QueueService : IQueueService
    {
        private readonly ICrmRepository<Queue> _queueRepo;
        private readonly ICrmRepository<QueueItem> _queueItemRepo;
        private readonly ICrmRepository<Incident> _incidentRepo;

        public QueueService(
            ICrmRepository<Queue> queueRepo,
            ICrmRepository<QueueItem> queueItemRepo,
            ICrmRepository<Incident> incidentRepo)
        {
            _queueRepo = queueRepo;
            _queueItemRepo = queueItemRepo;
            _incidentRepo = incidentRepo;
        }

        private Guid FindAgentQueueId(Guid agentId)
        {
            var query = new QueryExpression("queue")
            {
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("ownerid", ConditionOperator.Equal, agentId)
                    }
                }
            };
            var queues = _queueRepo.RetrieveMultiple(query);
            return queues[0].Id;
        }
        private void CreateQueueItem(Guid incidentId, Guid queueId)
        {
            var queueItem = new QueueItem
            {
                ObjectId = new EntityReference("incident", incidentId),
                QueueId = new EntityReference("queue", queueId),
            };
            _queueItemRepo.Create(queueItem);
        }
        public List<QueueItem> GetQueueItems(Guid agentId)
        {
            var agentQueueId = FindAgentQueueId(agentId);
            var query = new QueryExpression("queueitem")
            {
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("queueid", ConditionOperator.Equal, agentQueueId)
                    }
                }
            };
            return _queueItemRepo.RetrieveMultiple(query);
        }
        public void TransferQueueItem(Guid incidentId, Guid targetAgentId)
        {
            var targetQueueId = FindAgentQueueId(targetAgentId);
            CreateQueueItem(incidentId, targetQueueId);
        }
        public void AcceptQueueItem(Guid queueItemId, Guid agentId)
        {
            var queueItem = _queueItemRepo.Retrieve(queueItemId);
            var incident = _incidentRepo.Retrieve(queueItem.ObjectId.Id);
            incident.OwnerId = new EntityReference("systemuser", agentId);
            _incidentRepo.Update(incident);
            _queueItemRepo.Delete(queueItemId);
        }
        public void RejectQueueItem(Guid queueItemId, Guid agentId)
        {
            _queueItemRepo.Delete(queueItemId);
        }
    }
}
