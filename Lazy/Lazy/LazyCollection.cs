using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lazy
{
    public class LazyCollection<T> : CachedCollection<T>
    {
        public LazyCollection(Func<IEnumerable<T>> collectionExpression)
            : this(new Thunk<IEnumerable<T>>(collectionExpression))
        {
        }

        public LazyCollection(Thunk<IEnumerable<T>> thunk)
        {
            originalCollectionThunk = thunk;
        }

        public override IEnumerable<T> OriginalCollection { get { return originalCollectionThunk.Value; } }
        private Thunk<IEnumerable<T>> originalCollectionThunk;
    }
}
