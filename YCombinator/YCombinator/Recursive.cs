using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YCombinator
{
    public class Rec<A>
    {
        public Rec(Func<Rec<A>, A> recOut)
        {
            RecOut = recOut;
        }

        public Func<Rec<A>, A> RecOut { get; set; }
    }
}
