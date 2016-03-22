using Chatty.CQRSToolkit.Interfaces;

namespace Chatty.CQRSToolkit.Validators
{
    public interface IQueryValidator<T> where T : IQuery
    {
        void Validate(T query);
    }
}