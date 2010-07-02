using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lazy;

namespace ProjectEuler
{
    public static class Prob002
    {
        // Haskell:   fibonacci = 0 : 1 : zipWith (+) fibonacci (drop 1 fibonacci)

        private static IEnumerable<long> getFibonacciNumbers0()
        {
            yield return 0;

            long prev = 1L;
            foreach (long n in fibonacciNumbers0)
            {
                yield return prev + n;
                prev = n;
            }
        }
        private static IEnumerable<long> fibonacciNumbers0 = getFibonacciNumbers0();


        private static IEnumerable<long> fibonacciNumbers1 = new LazyCollection<long>(() =>
            0L.Cons(1L.Cons(EnumerableEx.ZipWith((a, b) => a + b, fibonacciNumbers1, fibonacciNumbers1.Skip(1)))));


        // does NOT work
        private static Thunk<CachedCollection<long>> fibonacciNumbers2 = new Thunk<CachedCollection<long>>(() =>
            0L.Cons(1L.Cons(EnumerableEx.ZipWith((a, b) => a + b, fibonacciNumbers2.Value, fibonacciNumbers2.Value.Skip(1)))).AsCached());


        public static void PrintResult()
        {
            Console.WriteLine("Fibonacci numbers:");

            foreach (long fib in fibonacciNumbers1.TakeWhile(f => f < long.MaxValue / 2))
                Console.WriteLine("    {0}", fib);

            //long result = fibonacciNumbers1.TakeWhile(f => f < 4000000)
            //                               .Where(f => f % 2 == 0)
            //                               .Sum();

            //Console.WriteLine("Result: {0}", result);
            // 4613732
        }
    }
}
