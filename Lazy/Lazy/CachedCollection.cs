using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Lazy
{
    public class CachedCollection<T> : IEnumerable<T>
    {
        public CachedCollection(IEnumerable<T> originalCollection)
            : this()
        {
            OriginalCollection = originalCollection;
        }

        protected CachedCollection()
        {
            LastEvaluatedIndex = -1;
            EvaluatedAll = false;
            
            originalEnumeratorThunk = new Thunk<IEnumerator<T>>(() => OriginalCollection.GetEnumerator());
        }
        
        public virtual IEnumerable<T> OriginalCollection { get; private set; }

        public IEnumerator<T> OriginalEnumerator { get { return originalEnumeratorThunk.Value; } }
        private Thunk<IEnumerator<T>> originalEnumeratorThunk;


        public int LastEvaluatedIndex { get; private set; }
        public bool EvaluatedAll { get; private set; }

        
        private List<T> cache = new List<T>();

        private object getItem(int index)
        {
            if (index < 0)
                throw new IndexOutOfRangeException();

            while (LastEvaluatedIndex < index)
            {
                EvaluatedAll = EvaluatedAll || !OriginalEnumerator.MoveNext();
                if (EvaluatedAll)
                    return null;

                cache.Add(OriginalEnumerator.Current);
                LastEvaluatedIndex++;
            }

            return cache[index];
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return new LazyEnumerator<T>(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new LazyEnumerator<T>(this);
        }


        public struct LazyEnumerator<T> : IEnumerator<T>, IDisposable, IEnumerator
        {
            public LazyEnumerator(CachedCollection<T> parent)
            {
                this.currentIndex = -1;
                this.current = null;
                this.parent = parent;
            }

            private int currentIndex;
            private object current;
            private CachedCollection<T> parent;

            object IEnumerator.Current { get { return current; } }

            T IEnumerator<T>.Current
            {
                get
                {
                    if (current != null)
                        return (T)current;
                    else
                        throw new NullReferenceException("Trying to access object beyond end of collection.");
                }
            }

            public void Dispose() { }
            
            public bool MoveNext()
            {
                current = parent.getItem(currentIndex + 1);
                
                if (current != null)
                    currentIndex++;
                
                return current != null;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }
    }
}
