using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserCombinators
{
    public static class ParserCombinatorExtensions
    {
        public static Parser<TInput, TValue> OR<TInput, TValue>(
            this Parser<TInput, TValue> parser1,
            Parser<TInput, TValue> parser2)
        {
            return input => parser1(input) ?? parser2(input);
        }

        public static Parser<TInput, TValue2> AND<TInput, TValue1, TValue2>(
            this Parser<TInput, TValue1> parser1,
            Parser<TInput, TValue2> parser2)
        {
            return input => parser2(parser1(input).Rest);
        }
    }
}
