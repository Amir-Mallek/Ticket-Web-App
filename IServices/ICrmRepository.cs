using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Ticket_Web_App.IServices
{
    public interface ICrmRepository<T> where T : Entity
    {
        Guid Create(T entity);
        T Retrieve(Guid id);
        List<T> RetrieveMultiple(QueryExpression query);
        void Update(T entity);
        void Delete(Guid id);
    }
}
