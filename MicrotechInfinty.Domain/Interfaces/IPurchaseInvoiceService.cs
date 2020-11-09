using MicrotechInfinity.Domain.Entities;
using MicrotechInfinity.Helper.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicrotechInfinity.Domain.Interfaces
{
    public partial interface IPurchaseInvoiceService
    {     
        Task<MDPurchaseInvoice> GetByIdAsync(int id);
        Task<IReadOnlyList<MDPurchaseInvoice>> GetAllAsync();
        Task<int> AddAsync(MDPurchaseInvoice entity);
        Task<int> UpdateAsync(MDPurchaseInvoice entity);
        Task<int> DeleteAsync(int id);

    }

    public partial interface IPurchaseInvoiceService
    {
        Task<IEnumerable<MDPurchaseInvoice>> GetPage(long startRow, long countRows, IEnumerable<NameValuePair<string, string>> colSort, IEnumerable<NameValuePair<string, string>> colFilter, out long totalRows);
    }
}
