using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lazy;

namespace ProjectEuler
{
    public static class Prob003
    {
        // Haskell:
        // primeNumbers = 2 : [ n | n <- [3, 5..], 
        //                          not $ any (`divisorOf` n) 
        //                                    (takeWhile (`lessThanSqrtOf` n) primeNumbers) ]
        //     where a `divisorOf` b       = b `mod` a == 0
        //           a `lessThanSqrtOf` b  = a * a <= b

        private static IEnumerable<long> getPrimeNumbers0()
        {
            yield return 2L;

            for (long n = 3L; ; n += 2L)
            {
                var divisors = primeNumbers0.TakeWhile(a => a * a <= n)
                                            .Where(a => n % a == 0L);
                if (divisors.Count() == 0)
                    yield return n;
            }
        }
        private static IEnumerable<long> primeNumbers0 = getPrimeNumbers0();


        //private static IEnumerable<long> primeNumbers1 =
        //    2L.Cons(EnumerableEx.RangeFrom(3L, 2L)
        //                        .Where(n => primeNumbers1.TakeWhile(a => a * a <= n)
        //                                                 .Where(a => n % a == 0L)
        //                                                 .Count() == 0));

        //private static Thunk<CachedCollection<long>> primeNumbers2 = new Thunk<CachedCollection<long>>(() =>
        //    2L.Cons(EnumerableEx.RangeFrom(3L, 2L)
        //                        .Where(n => primeNumbers2.Value.TakeWhile(a => a * a <= n)
        //                                                       .Where(a => n % a == 0L)
        //                                                       .Count() == 0)).AsCached());

        private static CachedCollection<long> primeNumbers3 =
            2L.Cons(EnumerableEx.RangeFrom(3L, 2L)
                                .Where(n => primeNumbers3.TakeWhile(a => a * a <= n)
                                                         .Where(a => n % a == 0L)
                                                         .Count() == 0)).AsCached();

        //private static Thunk<IEnumerable<long>> primeNumbers4 = new Thunk<IEnumerable<long>>(() =>
        //    2L.Cons(EnumerableEx.RangeFrom(3L, 2L)
        //                        .Where(n => primeNumbers4.Value.TakeWhile(a => a * a <= n)
        //                                                       .Where(a => n % a == 0L)
        //                                                       .Count() == 0)));

        private static IEnumerable<long> primeNumbers5 = new LazyCollection<long>(() =>
            2L.Cons(EnumerableEx.RangeFrom(3L, 2L)
                                .Where(n => primeNumbers5.TakeWhile(a => a * a <= n)
                                                         .Where(a => n % a == 0L)
                                                         .Count() == 0)));

        // Haskell:
        // primeFactors' 1 _     = []
        // primeFactors' n (p:_)
        //     | p * p > n       = [n]
        // primeFactors' n primes@(p:ps)
        //     | n `mod` p == 0  = p : primeFactors' (n `div` p) primes
        //     | otherwise       = primeFactors' n ps

        private static IEnumerable<long> primeFactorsHelper(long n, IEnumerable<long> primes)
        {
            long p = primes.First();

            if (n == 1)
                return Enumerable.Empty<long>();
            else if (p * p > n)
                return EnumerableEx.Singleton(n);
            else if (n % p == 0L)
                return p.Cons(primeFactorsHelper(n / p, primes));
            else
                return primeFactorsHelper(n, primes.Skip(1));
        }

        private static IEnumerable<long> primeFactors(long n)
        {
            return primeFactorsHelper(n, primeNumbers5);
        }


        public static void PrintResult()
        {
            //Console.Write("Prime numbers: ");

            //foreach (long prime in primeNumbers0.Take(1000))
            //    Console.Write("{0} ", prime);

            //  1000: 00:00:00.5468750
            //  2000: 00:00:02.1250000
            // 10000: 00:00:51.9062500


            //foreach (long prime in primeNumbers1.Take(1000))
            //    Console.Write("{0} ", prime);

            //  1000: 00:00:00.9375000
            //  2000: 00:00:03.5625000
            // 10000: 00:01:27.2500000


            //foreach (long prime in primeNumbers2.Value.Take(10000))
            //    Console.Write("{0} ", prime);

            //  1000: 00:00:01.3125000
            //  2000: 00:00:05.2187500
            // 10000: 00:02:08.9062500


            //foreach (long prime in primeNumbers3.Take(100000))
            //    Console.Write("{0} ", prime);

            //  1000: 00:00:00.0937500
            //  2000: 00:00:00.1406250
            // 10000: 00:00:00.7343750
            //100000: 00:00:14.4843750
            

            //foreach (long prime in primeNumbers5.Take(1000))
            //    Console.Write("{0} ", prime);

            //  1000: 00:00:00.0937500
            //  2000: 00:00:00.1406250
            // 10000: 00:00:00.7500000
            //100000: 00:00:14.4531250


            // 600851475143
            long n = 600851475143;
            Console.Write("Prime factors of {0}:   ", n);

            foreach (long factor in primeFactors(n))
                Console.Write("{0} ", factor);

            // n = 23421311:
            //      00:01:20.4375000    (primeNumbers0)
            //      00:02:14.6718750    (primeNumbers1)
            //      00:00:03.0156250    (primeNumbers2) *
            //      00:00:02.2500000    (primeNumbers3) *
            //      00:02:38.7812500    (primeNumbers4)
            //      00:00:02.2656250    (primeNumbers5) *
        }
    }
}
