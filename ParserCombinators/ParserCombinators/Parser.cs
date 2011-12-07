using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserCombinators
{
    // The result of a parse consists of a value and the unconsumed input.
    public class Result<TInput, TValue>
    {
        public Result(TValue value, TInput rest)
        {
            Value = value;
            Rest = rest;
        }

        public readonly TValue Value;
        public readonly TInput Rest;
    }

    // A Parser is a delegate which takes an input and returns a result.
    public delegate Result<TInput, TValue> Parser<TInput, TValue>(TInput input);
}
