using System;
using System.Collections.Generic;
using System.Text;

namespace MicrotechInfinity.DataAccess.Queries
{
    public interface ILoadEntityItems
    {
        List<MDPurchaseInvoiceDetail> LoadEntityItems(Int64 startRow, Int64 countRows,
                               List<NameValuePair<string, string>> colSort, List<NameValuePair<string, string>> colFilter, out Int64 totalRows)
    }
}
