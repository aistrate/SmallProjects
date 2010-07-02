using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lazy
{
    public class Thunk<T>
    {
        public static Thunk<T> Create(Func<T> expression)
        {
            return new Thunk<T>(expression);
        }

        public Thunk(Func<T> expression)
        {
            Expression = expression;
            IsEvaluated = false;
        }

        public T Value
        {
            get
            {
                if (!IsEvaluated)
                {
                    value = Expression();
                    IsEvaluated = true;
                }
                return value;
            }
        }
        private T value;

        public Func<T> Expression { get; private set; }
        
        public bool IsEvaluated { get; private set; }
    }
}
