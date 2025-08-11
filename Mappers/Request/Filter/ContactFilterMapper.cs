using Microsoft.Xrm.Sdk.Query;
using Ticket_Web_App.Dtos.Request.Filter;

namespace Ticket_Web_App.Mappers.Request.Filter
{
    public static class ContactFilterMapper
    {
        public static QueryExpression Map(ContactFilterDto filter)
        {
            var query = new QueryExpression("contact");

            var filterExpression = new FilterExpression(LogicalOperator.And);

            if (!string.IsNullOrWhiteSpace(filter.FullName))
            {
                filterExpression.AddCondition("fullname", ConditionOperator.Like, $"%{filter.FullName}%");
            }

            if (filter.ParentClientId.HasValue)
            {
                filterExpression.AddCondition("parentcustomerid", ConditionOperator.Equal, filter.ParentClientId.Value);
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
