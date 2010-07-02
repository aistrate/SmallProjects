using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullGetter
{
    public class Account
    {
        public int Key { get; set; }
        public Position CashPosition { get; set; }
        //public List<Position> Positions { get; private set; }
    }
}
