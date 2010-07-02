using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lazy;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DateTime startTime = DateTime.Now;
                
                Prob002.PrintResult();
                
                Console.WriteLine("\n\n\nTime: {0}", DateTime.Now - startTime);
                Console.WriteLine("\n\n");
            }
            catch (Exception ex)
            {
                for (Exception newEx = ex; newEx != null; newEx = newEx.InnerException)
                    Console.WriteLine(newEx.Message + "\n");
            }
        }
    }
}
