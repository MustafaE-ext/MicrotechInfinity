using System;
using System.Collections.Generic;
using System.Text;

namespace MicrotechInfinity.DataAccess.Helper
{
    public class DBQ
    {
        public static string FormatFilters(List<NameValuePair<string, string>> colFilter)
        {
            string Where = "";
            if (colFilter == null || colFilter.Count() == 0)
                return Where;

            Where = " WHERE ";
            bool bFirst = true;

            foreach (var i in colFilter)
            {

                if (!bFirst) Where += " AND ";
                bFirst = false;

                if (i.Value.Contains("|")) //range
                {
                    var sp = i.Value.Split('|');
                    if (sp.Count() > 1) Where += string.Format("{0} BETWEEN '{1}' AND '{2}'", i.Name, sp[0], sp[1]);
                }
                else if (i.Name.StartsWith("docid")) //literal docid
                {
                    //i.Name = i.Name.Remove(0, 1);
                    Where += string.Format("{0} = '{1}'", i.Name, i.Value);
                }
                else
                {
                    Where += string.Format("{0} LIKE '%{1}%'", i.Name, i.Value);
                }
            }

            return Where;
        }

        public static string FormatSort(List<NameValuePair<string, string>> colSort)
        {
            string Order = "";
            if (colSort == null || colSort.Count() == 0)
                return Order;

            Order = " ORDER BY ";
            bool bFirst = true;

            foreach (var i in colSort)
            {
                if (!bFirst) Order += " AND ";
                bFirst = false;

                Order += i.Name + " " + i.Value;
            }


            return Order;
        }
    }
}
