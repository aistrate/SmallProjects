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
            
            Console.WriteLine("Rest: \"{0}\"", result.Rest);
            Console.WriteLine("Value:\n\n{0}\n\n", result.Value);


            MiniMLParserFromCharBuffer parser2 = new MiniMLParserFromCharBuffer();
            Result<CharBuffer, Term> result2 = parser2.All(new CharBuffer(sourceCode));

            Console.WriteLine();
            Console.WriteLine("With CharBuffer:\n");
            Console.WriteLine("Rest: \"{0}\"", result2.Rest);
            Console.WriteLine("Value:\n\n{0}\n", result2.Value);


            //DateTime start = DateTime.Now;

            //for (int i = 0; i < 1000; i++)
            //    result = parser.All(sourceCode);

            //Console.WriteLine(DateTime.Now - start);
            //// 38.3 sec.


            //start = DateTime.Now;
            //CharBuffer sourceCodeBuffer = new CharBuffer(sourceCode);

            //for (int i = 0; i < 1000; i++)
            //    result2 = parser2.All(sourceCodeBuffer);

            //Console.WriteLine("With CharBuffer:\n{0}", DateTime.Now - start);
            //// 21.7 sec.
        }

        //let true = \x. \y. (x ) in
        //let false = \x. \y. (y ) in
        //let if = \b. \l. \r. ((b l) r) in
        //(if true false true)
    }
}
