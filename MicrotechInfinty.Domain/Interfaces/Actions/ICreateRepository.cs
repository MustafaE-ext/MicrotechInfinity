using System.Threading.Tasks;

namespace MicrotechInfinity.Domain.Interfaces.Actions
{
    public interface ICreateRepository<T> where T : class
    {
        Task<int> AddAsync(T entity);
    }
}
