using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YCombinator
{
    class Program
    {
        static void Main(string[] args)
        {
            testFactorial();
            Console.WriteLine();
            testListLength();
        }

        // Haskell:
        //      fix :: (a -> a) -> a
        //      fix f = let x = f x in x     OR
        //      fix f = f (fix f)
        // OCaml:
        //      let rec fix f x = f (fix f) x
        //      val fix : (('a -> 'b) -> 'a -> 'b) -> 'a -> 'b = <fun>
        public static Func<A, B> Fix<A, B>(Func<Func<A, B>, Func<A, B>> f)
        {
            return x => f(Fix(f))(x);
        }


        // Haskell:
        //      newtype Rec a = In { out :: Rec a -> a }
        //      fix' :: (a -> a) -> a
        //      fix' = \f -> (\x -> f (out x x)) (In (\x -> f (out x x)))
        // OCaml:
        //      type 'a recc = In of ('a recc -> 'a)
        //      let out (In x) = x 
        //      let y f = (fun x a -> f (out x x) a) (In (fun x a -> f (out x x) a))
        public static Func<A, B> YCombFix<A, B>(Func<Func<A, B>, Func<A, B>> f)
        {
            return (new Rec<Func<A, B>>(x => a => f(x.RecOut(x))(a))).RecOut(
                    (new Rec<Func<A, B>>(x => a => f(x.RecOut(x))(a))));
            
            //return (  (Func<Rec<Func<A, B>>, Func<A, B>>)
            //                  (x => a => f(x.RecOut(x))(a))
            //       )
            //            (new Rec<Func<A, B>>(x => a => f(x.RecOut(x))(a)));

            //Func<Rec<Func<A, B>>, Func<A, B>> ff = x => a => f(x.RecOut(x))(a);
            //return ff(new Rec<Func<A, B>>(ff));
        }


        delegate T SelfApplicable<T>(SelfApplicable<T> self);

        public static Func<A, B> YCombFix2<A, B>(Func<Func<A, B>, Func<A, B>> f)
        {
            return ((Func<SelfApplicable<Func<A, B>>, Func<A, B>>)
                        (x => a => f(x(x))(a))
                   )
                            (x => a => f(x(x))(a));
        }


        // Factorial
        private static void testFactorial()
        {
            int k = 7;

            
            Console.WriteLine("factorial({0}) = {1}", k, factorial(k));

            
            Func<int, int> fact = null;
            fact = (n => n == 0 ? 1 : n * fact(n - 1));
            Console.WriteLine("lambda factorial({0}) = {1}", k, fact(k));

            
            Console.WriteLine("Fix factorial({0}) = {1}", k,
                              Fix<int, int>(g => n => n == 0 ? 1 : n * g(n - 1))(k));


            Console.WriteLine("Y-Combinator factorial({0}) = {1}", k,
                              YCombFix<int, int>(g => n => n == 0 ? 1 : n * g(n - 1))(k));


            Console.WriteLine("SelfApplicable Y-Combinator factorial({0}) = {1}", k,
                              YCombFix2<int, int>(g => n => n == 0 ? 1 : n * g(n - 1))(k));


            Func<Func<Func<int, int>, Func<int, int>>, Func<int, int>> ycomb =
                f => (new Rec<Func<int, int>>(x => a => f(x.RecOut(x))(a))).RecOut(
                        (new Rec<Func<int, int>>(x => a => f(x.RecOut(x))(a))));
            Console.WriteLine("Inline Y-Combinator factorial({0}) = {1}", k,
                              ycomb(g => n => n == 0 ? 1 : n * g(n - 1))(k));
            
            
            // All in one expression
            Func<int, int> oneExpFact =
                ((Func<Func<Func<int, int>, Func<int, int>>, Func<int, int>>)
                            (f => (new Rec<Func<int, int>>(x => a => f(x.RecOut(x))(a))).RecOut(
                                (new Rec<Func<int, int>>(x => a => f(x.RecOut(x))(a)))))
                )
                            (g => n => n == 0 ? 1 : n * g(n - 1));
            Console.WriteLine("All-in-one-expression factorial({0}) = {1}", k, oneExpFact(k));


            Func<int, int> selfAppOneExpFact =
                ((Func<Func<Func<int, int>, Func<int, int>>, Func<int, int>>)
                    (f => ((Func<SelfApplicable<Func<int, int>>, Func<int, int>>)
                                (x => a => f(x(x))(a)))
                                    (x => a => f(x(x))(a))))
                        (g => n => n == 0 ? 1 : n * g(n - 1));
            Console.WriteLine("SelfApplicable All-in-one-expression factorial({0}) = {1}", k, selfAppOneExpFact(k));
        }

        private static int factorial(int n)
        {
            return n == 0 ? 1 : n * factorial(n - 1);
        }


        // List length
        private static void testListLength()
        {
            IEnumerable<double> squareRoots = Enumerable.Range(1, 100)
                                                        .Select(i => Math.Sqrt((double)i));
            //foreach (double elem in squareRoots)
            //    Console.WriteLine("{0} ", elem);

            
            Console.WriteLine("list length = {0}", listLength(squareRoots));

            
            Console.WriteLine("Fix list length = {0}",
                              Fix<IEnumerable<double>, int>(g => list => isEmpty(list) ? 0 : 1 + g(list.Skip(1)))(squareRoots));


            Console.WriteLine("Y-Combinator list length = {0}",
                              YCombFix<IEnumerable<double>, int>(g => list => isEmpty(list) ? 0 : 1 + g(list.Skip(1)))(squareRoots));
        }

        private static bool isEmpty<T>(IEnumerable<T> list)
        {
            return list.SequenceEqual(Enumerable.Empty<T>());
        }

        private static int listLength<T>(IEnumerable<T> list)
        {
            return isEmpty(list) ? 0 : 1 + listLength(list.Skip(1));
        }
    }
}
