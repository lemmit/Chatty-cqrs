using Chatty.CQRSToolkit.Interfaces;

namespace Chatty.CQRSToolkit.QueryHandlers
{
    public interface IQueryHandler<T, R>
        where T : IQuery
        where R : IQueryResponse
    {
        R Handle(T query);
    }
}