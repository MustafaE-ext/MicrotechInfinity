using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicrotechInfinity.Domain.Interfaces
{
    public interface IRepository<T>
    {
      

        //List<T> GetPage(Int64 startRow, Int64 countRows,
        //    List<NameValuePair<string, string>> colSort, List<NameValuePair<string, string>> colFilter, out Int64 totalRows);


        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(int id);
    }
}
