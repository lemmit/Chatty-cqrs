using System;
using System.Threading.Tasks;
using Chatty.CQRSToolkit.Interfaces;

namespace Chatty.CQRSToolkit.QueryHandlers
{
    public class LambdaQueryHandler<T, R>
        : IQueryHandler<T, R>
        where T : IQuery
        where R : IQueryResponse
    {
        private readonly Func<T, R> _queryHandlerFunc;

        public LambdaQueryHandler(Func<T, R> queryHandlerAction)
        {
            _queryHandlerFunc = queryHandlerAction;
        }

        public R Handle(T query)
        {
            return Task.Run(() => _queryHandlerFunc(query)).Result;
        }
    }
}