using System.Threading.Tasks;

namespace MicrotechInfinity.Domain.Interfaces.Actions
{
    public interface IRemoveRepository<T>
    {
        Task<int> DeleteAsync(T id);
    }
}
