using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lazy
{
    public static class EnumerableEx
    {
        public static CachedCollection<T> AsCached<T>(this IEnumerable<T> collection)
        {
            return new CachedCollection<T>(collection);
        }

        public static IEnumerable<int> RangeFrom(int start)
        {
            return RangeFrom(start, 1);
        }

        public static IEnumerable<int> RangeFrom(int start, int increment)
        {
            for (int i = start; ; i += increment)
                yield return i;
        }

        public static IEnumerable<long> RangeFrom(long start)
        {
            return RangeFrom(start, 1);
        }

        public static IEnumerable<long> RangeFrom(long start, long increment)
        {
            for (long i = start; ; i += increment)
                yield return i;
        }

        public static IEnumerable<T> Singleton<T>(T elem)
        {
            yield return elem;
        }

        public static IEnumerable<T> Cons<T>(this T car, IEnumerable<T> cdr)
        {
            yield return car;
            foreach (T t in cdr)
                yield return t;
        }

        public static IEnumerable<C> ZipWith<A, B, C>(Func<A, B, C> func, IEnumerable<A> aColl, IEnumerable<B> bColl)
        {
            IEnumerator<A> aEnum = aColl.GetEnumerator();
            IEnumerator<B> bEnum = bColl.GetEnumerator();

            while (aEnum.MoveNext() && bEnum.MoveNext())
                yield return func(aEnum.Current, bEnum.Current);
        }
    }
}
