using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MicrotechInfinity.WebApi.XFer
{
    public class GridResponse<T>
    {
        public int sEcho { get; set; }
        public Int64 iTotalRecords { get; set; }
        public Int64 iTotalDisplayRecords { get; set; }
        public List<T> Data { get; set; }

        public string GetJson()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{{ \"recordsTotal\" : \"{1}\", \"recordsFiltered\" : \"{2}\", \"data\": [  ", sEcho, iTotalDisplayRecords, iTotalDisplayRecords);

            if (Data == null)
            {
                sb.Append("]}");
                return sb.ToString();
            }


            int j = 0, countData = Data.Count();

            foreach (var item in Data)
            {
                sb.Append('[');

                var propArray = item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                int i = 0, count = propArray.Count();

                foreach (var prop in propArray)
                {
                    //sb.Append("\"");


                    if (null != prop && prop.CanRead)
                    {
                        object obj = prop.GetValue(item);

                        if (obj != null)
                        {
                            sb.Append(JsonConvert.ToString(prop.GetValue(item).ToString()));
                        }
                        else
                        {
                            sb.Append("\"");
                            sb.Append("\"");
                        }
                    }
                    else
                    {
                         sb.Append("\"");
                         sb.Append("\"");
                    }

                    if ((++i) != count)
                        sb.Append(',');
                }

                sb.Append(']');

                if ((++j) != countData)
                    sb.Append(',');
            }

            sb.Append("]}");

            return sb.ToString();
        }

    }
}
