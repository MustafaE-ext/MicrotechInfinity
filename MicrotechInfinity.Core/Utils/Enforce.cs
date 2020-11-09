using System;
using System.Collections.Generic;
using System.Text;

namespace MicrotechInfinity.Helper.Utils
{
    public static class Enforce
    {
        public static T ArgumentNotNull<T>(T argument, string description)
            where T : class
        {
            if (argument == null)
                throw new ArgumentNullException(description);

            return argument;
        }

        public static T ArgumentGreaterThanZero<T>(T argument, string description)
        {
            if (System.Convert.ToInt32(argument) < 1)
                throw new ArgumentOutOfRangeException(description);

            return argument;
        }

        public static void That(bool condition, string message)
        {
            if (condition == false)
            {
                throw new ArgumentException(message); //### custom exception class
            }
        }
    }
}
