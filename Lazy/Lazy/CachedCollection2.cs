using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lazy
{
    /// <summary>
    /// Unsuccessful attempt at simplifying CachedCollection.
    /// </summary>
    public class CachedCollection2<T> : IEnumerable<T>
    {
        public CachedCollection2(IEnumerable<T> originalCollection)
            : this()
        {
            OriginalCollection = originalCollection;
        }

        protected CachedCollection2()
        {
            thunkCollectionThunk = new Thunk<IEnumerable<Thunk<T>>>(() => OriginalCollection.Select(e => new Thunk<T>(() => e)));
            cachedCollectionThunk = new Thunk<IEnumerable<T>>(() => thunkCollectionThunk.Value.Select(t => t.Value));
        }
        
        public virtual IEnumerable<T> OriginalCollection { get; private set; }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return cachedCollectionThunk.Value.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return cachedCollectionThunk.Value.GetEnumerator();
        }

        private Thunk<IEnumerable<Thunk<T>>> thunkCollectionThunk;
        private Thunk<IEnumerable<T>> cachedCollectionThunk;
    }
}
