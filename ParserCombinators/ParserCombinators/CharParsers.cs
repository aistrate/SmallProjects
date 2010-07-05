using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserCombinators
{
    // Contains a few parsers that parse characters from an input stream
    public abstract class CharParsers<TInput> : Parsers<TInput>
    {
        public abstract Parser<TInput, char> AnyChar { get; }

        public Parser<TInput, char> Char(char ch)
        {
            return from c in AnyChar where c == ch select c;
        }

        public Parser<TInput, char> Char(Predicate<char> pred)
        {
            return from c in AnyChar where pred(c) select c;
        }
    }
}
