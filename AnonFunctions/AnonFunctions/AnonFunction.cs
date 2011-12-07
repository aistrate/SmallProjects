using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonFunctions
{
    public abstract class AnonFunc<Result>
    {
        public abstract Result Run();
    }

    public abstract class AnonFunc<T1, Result>
    {
        public abstract Result Run(T1 arg1);
    }

    public abstract class AnonFunc<T1, T2, Result>
    {
        public abstract Result Run(T1 arg1, T2 arg2);
    }
}
