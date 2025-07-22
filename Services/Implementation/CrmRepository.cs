using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System.Reflection;
using Ticket_Web_App.Attributes;
using Ticket_Web_App.Services.Interfaces;

namespace Ticket_Web_App.Services.Implementation
{
    public class CrmRepository<T> : ICrmRepository<T> where T : Entity
    {
        protected readonly IOrganizationService _svc;
        private readonly ColumnSet _columnSet;
        private readonly string _logicalName;

        public CrmRepository(IOrganizationService svc)
        {
            _svc = svc;
            _logicalName = typeof(T).GetCustomAttribute<EntityLogicalNameAttribute>().LogicalName;
            var colums = typeof(T).GetCustomAttribute<AppColumnsAttribute>().Columns;
            _columnSet = new ColumnSet(colums);
        }

        public Guid Create(T entity) => _svc.Create(entity);
        public T Retrieve(Guid id) => _svc.Retrieve(_logicalName, id, _columnSet).ToEntity<T>();
        public List<T> RetrieveMultiple(QueryExpression query)
        {
            query.ColumnSet = _columnSet;
            var results = _svc.RetrieveMultiple(query);
            return results.Entities.Select(e => e.ToEntity<T>()).ToList();
        }
        public void Update(T entity) => _svc.Update(entity);
        public void Delete(Guid id) => _svc.Delete(_logicalName, id);
    }

}
