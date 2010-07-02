using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullGetter
{
    public static class NullGetter
    {
        public static B Get<A, B>(this A a, Func<A, B> func)
            where B : class
        {
            return a != null ? func(a) : null;
        }

        public static B? GetV<A, B>(this A a, Func<A, B> func)
            where B : struct
        {
            return a != null ? func(a) : (B?)null;
        }

        public static string GetS<A>(this A a, Func<A, string> func)
        {
            return a != null ? (func(a) ?? "") : "";
        }
    }
}
