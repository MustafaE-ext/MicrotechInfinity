using System;
using System.Collections.Generic;
using System.Text;

namespace MicrotechInfinity.DataAccess.Queries
{
    public interface ILoadEntities
    {
        List<MDPurchaseInvoice> LoadEntities(Int64 startRow, Int64 countRows,
                       List<NameValuePair<string, string>> colSort, List<NameValuePair<string, string>> colFilter, out Int64 totalRows)
    }
}
