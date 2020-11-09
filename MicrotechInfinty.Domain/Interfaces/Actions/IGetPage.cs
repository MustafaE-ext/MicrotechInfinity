using MicrotechInfinity.Helper.Utils;
using System;
using System.Collections.Generic;

namespace MicrotechInfinity.Domain.Interfaces.Actions
{
    public interface IGetPage<T> where T : class
    {
        IEnumerable<T> GetPage(Int64 startRow, Int64 countRows, IEnumerable<NameValuePair<string, string>> colSort, IEnumerable<NameValuePair<string, string>> colFilter, out Int64 totalRows);
    }
}
