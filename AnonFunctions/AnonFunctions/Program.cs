using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new ConstVal().Run());
            Console.WriteLine(new Increment().Run(10));

            Console.WriteLine(applyFunc(new Increment(), 42));

            Console.WriteLine(applyTwoTimes(new Decrement(), 42));

            Console.WriteLine(applyTimes(12, new Decrement(), 42));

            Console.WriteLine(Counter);
            Console.WriteLine(Counter);
            Console.WriteLine(Counter);

            Console.WriteLine();

            Counter cnt1 = new Counter(),
                    cnt2 = new Counter();
            Console.WriteLine(cnt1.Next());
            Console.WriteLine(cnt1.Next());
            Console.WriteLine(cnt1.Next());
            Console.WriteLine(cnt2.Next());
            Console.WriteLine(cnt2.Next());
            Console.WriteLine(cnt1.Next());

            Console.WriteLine();

            Func<int> fcnt1 = GetCounter(),
                      fcnt2 = GetCounter();
            Console.WriteLine(fcnt1());
            Console.WriteLine(fcnt1());
            Console.WriteLine(fcnt1());
            Console.WriteLine(fcnt2());
            Console.WriteLine(fcnt2());
            Console.WriteLine(fcnt1());

            Console.WriteLine();

            Func<Func<int>> getCounter = () =>
                {
                    int i = 0;
                    return () => ++i;
                };
            Func<int> ffcnt1 = getCounter(),
                      ffcnt2 = getCounter();
            Console.WriteLine(ffcnt1());
            Console.WriteLine(ffcnt1());
            Console.WriteLine(ffcnt1());
            Console.WriteLine(ffcnt2());
            Console.WriteLine(ffcnt2());
            Console.WriteLine(ffcnt1());

            Console.WriteLine();

            int ii = 0;
            Func<Func<int>> getCounter2 = () =>
            {
                int i = ii;
                return () => ++i;
            };
            ii = 10;
            Func<int> fffcnt1 = getCounter2();
            ii = 20;
            Func<int> fffcnt2 = getCounter2();
            Console.WriteLine(fffcnt1());
            Console.WriteLine(fffcnt1());
            Console.WriteLine(fffcnt1());
            Console.WriteLine(fffcnt2());
            Console.WriteLine(fffcnt2());
            Console.WriteLine(fffcnt1());
        }

        private static R applyFunc<A, R>(AnonFunc<A, R> f, A arg)
        {
            return f.Run(arg);
        }

        private static A applyTwoTimes<A>(AnonFunc<A, A> f, A arg)
        {
            return f.Run(f.Run(arg));
        }

        private static A applyTimes<A>(int n, AnonFunc<A, A> f, A arg)
        {
            A result = arg;
            for (int i = 0; i < n; i++)
                result = f.Run(result);

            return result;
        }

        private class ConstVal : AnonFunc<int>
        {
            public override int Run()
            {
                return 17;
            }
        }

        private class Increment : AnonFunc<int, int>
        {
            public override int Run(int n)
            {
                return n + 1;
            }
        }

        private class Decrement : AnonFunc<int, int>
        {
            public override int Run(int n)
            {
                return n - 1;
            }
        }

        private static int counter = 0;
        public static int Counter
        {
            get
            {
                return ++counter;
            }
        }

        public static Func<int> GetCounter()
        {
            int i = 0;
            return () => ++i;
        }
    }
}
