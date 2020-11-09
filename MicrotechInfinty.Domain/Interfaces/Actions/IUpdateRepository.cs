using System.Threading.Tasks;

namespace MicrotechInfinity.Domain.Interfaces
{
    public interface IUpdateRepository<T> where T : class
    {
         Task<int> UpdateAsync(T entity);
    }
}
