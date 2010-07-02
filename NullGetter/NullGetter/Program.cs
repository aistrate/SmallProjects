using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullGetter
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = null;
            print(1, account);

            account = new Account();
            print(2, account);

            account.CashPosition = new Position();
            print(3, account);

            account.CashPosition.Instrument = new Instrument();
            print(4, account);

            account.CashPosition.Instrument.Key = 123;
            account.CashPosition.Instrument.Name = "Euro";
            print(5, account);

            Console.WriteLine(typeof(int?));
            Console.WriteLine(typeof(Nullable<int>));
            Console.WriteLine(typeof(int?) == typeof(Nullable<int>));
        }

        private static void print(int n, Account account)
        {
            Console.WriteLine("({0}):\n    {1}\n    {2}\n    {3}", n, 
                              account.Get(a => a.CashPosition).Get(p => p.Instrument).GetV(i => i.Key),
                              formatStr(account.Get(a => a.CashPosition).Get(p => p.Instrument).Get(i => i.Name)),
                              formatStr(account.Get(a => a.CashPosition).Get(p => p.Instrument).GetS(i => i.Name)));
        }

        private static string formatStr(string s)
        {
            return s != null ? "'" + s + "'" : "(null)";
        }
    }
}
