using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserCombinators
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceCode = @"let true = \x.\y.x in 
                                  let false = \x.\y.y in 
                                  let if = \b.\l.\r.(b l) r in
                                  if true false true;";

            MiniMLParserFromString parser = new MiniMLParserFromString();
            
            Result<string, Term> result = parser.All(sourceCode);

            Console.WriteLine("Rest: \"{0}\"\n", result.Rest);

            Console.WriteLine("Value:\n\n{0}\n", result.Value);
        }

        //Rest: ""

        //Value:

        //let true = \x. \y. (x ) in
        //let false = \x. \y. (y ) in
        //let if = \b. \l. \r. ((b l) r) in
        //(if true false true)
    }
}
