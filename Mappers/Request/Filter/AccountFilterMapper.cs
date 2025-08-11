using Microsoft.Xrm.Sdk.Query;
using Ticket_Web_App.Dtos.Request.Filter;

namespace Ticket_Web_App.Mappers.Request.Filter
{
    public static class AccountFilterMapper
    {
        public static QueryExpression Map(AccountFilterDto filter)
        {
            var query = new QueryExpression("account");

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
