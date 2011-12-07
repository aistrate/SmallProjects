using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonFunctions
{
    public class Counter
    {
        private int counter = 0;

        public int Next()
        {
            return ++counter;
        }
    }
}
