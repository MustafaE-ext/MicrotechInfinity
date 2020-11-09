using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MicrotechInfinity.Helper.Utils
{
    [Serializable]
    public class NameValuePair<TName, TValue>
    {
        public TName Name { get; set; }
        public TValue Value { get; set; }

        public NameValuePair(TName name, TValue value)
        {
            Name = name;
            Value = value;
        }

        public NameValuePair() { }
    }


    static class KVPredicate
    {
        public static Expression<Func<NameValuePair<string, string>, bool>> KeyPredicate(string name)
        {
            var predicate = PredicateBuilder.True<NameValuePair<string, string>>();
            predicate = predicate.And<NameValuePair<string, string>>(nv => nv.Name == name);

            return predicate;
        }

        public static Expression<Func<NameValuePair<string, string>, bool>> ValueIs(string name, string value)
        {
            var predicate = PredicateBuilder.True<NameValuePair<string, string>>();
            predicate = predicate.And<NameValuePair<string, string>>(nv => nv.Value == value);

            return predicate;
        }

        public static string GetNVValue(this List<NameValuePair<string, string>> nvPairs, string name)
        {
            return nvPairs.AsQueryable()
                            .Where(KeyPredicate(name))
                            .SingleOrDefault()
                            .Value;
        }
    }
}
