using Microsoft.AspNetCore.Mvc;
using Ticket_Web_App.Dtos.Response;
using Ticket_Web_App.IServices;
using Ticket_Web_App.Mappers.Response;

namespace Ticket_Web_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QueueController : ControllerBase
    {
        private readonly IQueueService _queueService;

        public QueueController(IQueueService queueService)
        {
            _queueService = queueService;
        }

        [HttpGet("{agentId}")]
        public List<QueueItemResponseDto> GetQueuItems(Guid agentId)
        {
            return _queueService
                .GetQueueItems(agentId)
                .Select(e => QueueItemResponseMapper.Map(e))
                .ToList();
        }

        [HttpPost("transfer/{incidentId}")]
        public void TransferQueueItem(Guid incidentId, [FromBody] Guid targetAgentId)
        {
            _queueService.TransferQueueItem(incidentId, targetAgentId);
        }

        [HttpPost("accept/{queueItemId}")]
        public void AcceptQueueItem(Guid queueItemId, [FromBody] Guid agentId)
        {
            _queueService.AcceptQueueItem(queueItemId, agentId);
        }

        [HttpPost("reject/{queueItemId}")]
        public void RejectQueueItem(Guid queueItemId, [FromBody] Guid agentId)
        {
            _queueService.RejectQueueItem(queueItemId, agentId);
        }
    }
}
