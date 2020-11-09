
using Microsoft.AspNetCore.Http;
using MicrotechInfinity.Helper.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MicrotechInfinity.WebApi.XFer
{
    using LISTKV = List<NameValuePair<string, string>>;


    public class GridViewRequest
    {
        private const string INDIVIDUAL_SEARCH_KEY_PREFIX = "sSearch_";
        private const string INDIVIDUAL_SORT_KEY_PREFIX = "order";
        private const string INDIVIDUAL_SORT_DIRECTION_KEY_PREFIX = "sSortDir_";
        private const string DISPLAY_START = "start";
        private const string DISPLAY_LENGTH = "length";
        private const string ECHO = "sEcho";
        private const string ASCENDING_SORT = "asc";
        private const string GENERIC_SEARCH = "search[value]";
        //private const string COLUMNS = "sColumns";
        //private const string BSEARCHABLE = "bSearchable_";
        //private const string BSORTABLE = "bSortable_";
        
        private List<string> sortKeyPrefix;
        private LISTKV ReqList;
        private LISTKV 
            columns;
        public LISTKV ColFilters { set; get; }

        private Int64 displayStart;
        private Int64 displayLength;
        private int echo;
        private string genericSearch;


        public Int64 DispStart { set; get; }
        public Int64 DispLength { set; get; }

        public LISTKV ColSort { set; get; }
        


        public void Parse()
        {
            Enforce.That(Int64.TryParse(ReqList.GetNVValue(DISPLAY_START), out displayStart), "Malformed request string #2");
            Enforce.That(Int64.TryParse(ReqList.GetNVValue(DISPLAY_LENGTH), out displayLength), "Malformed request string #2");

            DispStart = displayStart;
            DispLength = displayLength;

            genericSearch = ReqList.GetNVValue(GENERIC_SEARCH);
            sortKeyPrefix = ReqList.Where(x => x.Name.StartsWith(INDIVIDUAL_SORT_KEY_PREFIX)).Select(x => x.Value).ToList();

            columns = ReqList.Where(x => x.Name.StartsWith("columns") & x.Name.EndsWith("[name]") & !string.IsNullOrEmpty(x.Value)).ToList();

            //sorting column and direction
            string sTmp = ReqList.Where(x => x.Name.StartsWith("order") & x.Name.EndsWith("[column]") & !string.IsNullOrEmpty(x.Value)).Select(v => v.Value).SingleOrDefault();
            if (!string.IsNullOrEmpty(sTmp))
            {
                int sortCol = -1;
                if (int.TryParse(sTmp, out sortCol) && sortCol != 0 && sortCol < columns.Count()) //if sortCol == 0 >> unsorted
                {
                    ColSort = new List<NameValuePair<string, string>>();

                    sTmp = ReqList.Where(x => x.Name.StartsWith("order") & x.Name.EndsWith("[dir]") & !string.IsNullOrEmpty(x.Value)).Select(v => v.Value).SingleOrDefault();
                    if (!string.IsNullOrEmpty(sTmp))
                    {
                        NameValuePair<string, string> nvp = new NameValuePair<string, string>(columns[sortCol].Value, sTmp);
                        ColSort.Add(nvp);
                    }
                }
            }



            int nF = -1;
            ColFilters = ReqList.Where(x => x.Name.StartsWith("columns") & x.Name.EndsWith("[search][value]") & !string.IsNullOrEmpty(x.Value)).ToList();
            foreach (var f in ColFilters)
            {
                nF = f.Name.IndexOf("[search]");
                if (nF != -1) f.Name = f.Name.Remove(nF);
                sTmp = columns.Where(x => x.Name.StartsWith(f.Name) & !string.IsNullOrEmpty(x.Value)).Select(v => v.Value).SingleOrDefault();
                f.Name = sTmp;
            }


            var sp = ReqList.Where(x => x.Name.StartsWith("docid") & !string.IsNullOrEmpty(x.Value)).FirstOrDefault();
            if (sp != null && !string.IsNullOrEmpty(sp.Name) && !string.IsNullOrEmpty(sp.Value))
            {
                if (ColFilters == null)
                    ColFilters = new LISTKV();

                ColFilters.Add(sp);
            }

        }

        public void Parse(string req)
        {
            Enforce.That(!string.IsNullOrEmpty(req), ("Malformed request string #1")); //### custom exception class

            //unescape
            req = Uri.UnescapeDataString(req);

            req = req.Remove(0, 1);
            var listParams = req.Split('&');

            Enforce.That(listParams.Count() > 0, "Malformed request string #2"); //### custom exception class


            ReqList = new LISTKV();
            
            foreach (var p in listParams)
            {
                var p2 = p.Split('=');

                if (p2.Count() > 1)
                    ReqList.Add(new NameValuePair<string, string>(p2[0], p2[1]));
            }

            Parse();
        }

        public void Parse(IFormCollection form)
        {
            Enforce.That(form.Count() > 0, ("Malformed request string #1")); //### custom exception class

            ReqList = new LISTKV();

            foreach (var p in form)
            {
                ReqList.Add(new NameValuePair<string, string>(p.Key, p.Value));
            }

            Parse();
        }
    }
}
