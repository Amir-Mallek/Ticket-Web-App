using Microsoft.Xrm.Sdk.Query;
using Ticket_Web_App.Dtos.Request.Filter;

namespace Ticket_Web_App.Mappers.Request.Filter
{
    public static class IncidentsQueryMapper
    {
        public static QueryExpression Map(this IncidentsFilterDto filter)
        {
            var query = new QueryExpression("incident");

            var filterExpression = new FilterExpression(LogicalOperator.And);

            if (!string.IsNullOrWhiteSpace(filter.Title))
            {
                filterExpression.AddCondition("title", ConditionOperator.Like, $"%{filter.Title}%");
            }

            if (!string.IsNullOrWhiteSpace(filter.TicketNumber))
            {
                filterExpression.AddCondition("ticketnumber", ConditionOperator.Like, $"%{filter.TicketNumber}%");
            }

            if (filter.ClientId.HasValue)
            {
                filterExpression.AddCondition("customerid", ConditionOperator.Equal, filter.ClientId.Value);
            }

            if (filter.AgentId.HasValue)
            {
                filterExpression.AddCondition("ownerid", ConditionOperator.Equal, filter.AgentId.Value);
            }

            if (filter.CreatedBy.HasValue)
            {
                filterExpression.AddCondition("createdby", ConditionOperator.Equal, filter.CreatedBy.Value);
            }

            if (filter.Priority.HasValue)
            {
                filterExpression.AddCondition("prioritycode", ConditionOperator.Equal, (int)filter.Priority.Value);
            }

            if (filter.Origin.HasValue)
            {
                filterExpression.AddCondition("caseorigincode", ConditionOperator.Equal, (int)filter.Origin.Value);
            }

            if (filter.Status.HasValue)
            {
                filterExpression.AddCondition("statuscode", ConditionOperator.Equal, (int)filter.Status.Value);
            }

            if (filter.CreatedAfter.HasValue)
            {
                filterExpression.AddCondition("createdon", ConditionOperator.GreaterEqual, filter.CreatedAfter.Value);
            }

            if (filter.CreatedBefore.HasValue)
            {
                filterExpression.AddCondition("createdon", ConditionOperator.LessEqual, filter.CreatedBefore.Value);
            }

            if (filterExpression.Conditions.Count > 0)
            {
                query.Criteria = filterExpression;
            }

            if (!string.IsNullOrWhiteSpace(filter.OrderBy))
            {
                // todo: check if orderby field is valid
                var orderType = filter.Descending ? OrderType.Descending : OrderType.Ascending;
                var attributeName = filter.OrderBy.ToLower();
                query.AddOrder(attributeName, orderType);
            }
            
            query.PageInfo = new PagingInfo
            {
                Count = filter.PageSize,
                PageNumber = filter.Page,
                PagingCookie = null
            };

            return query;
        }
    }
}
