using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicrotechInfinity.Domain.Interfaces.Actions
{
    public interface IReadRepository<T, Y> where T : class
    {
        Task<T> GetByIdAsync(Y id);
        Task<IReadOnlyList<T>> GetAllAsync();
    }
}
