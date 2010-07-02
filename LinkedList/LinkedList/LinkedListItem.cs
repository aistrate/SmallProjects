using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedList
{
    public class LinkedListItem<T> : IEnumerable<T>
    {
        public LinkedListItem()
        {
        }

        public LinkedListItem(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public LinkedListItem<T> Next { get; set; }

        public override string ToString()
        {
            return "[" + string.Join(", ", this.Select(i => i.ToString()).ToArray()) + "]";
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        public int Length
        {
            get
            {
                int length = 0;
                for (var current = this; current != null; current = current.Next, length++) ;
                return length;
            }
        }

        public class Enumerator<T> : IEnumerator<T>
        {
            public Enumerator(LinkedListItem<T> head)
            {
                Head = head;
            }

            public LinkedListItem<T> Head { get; private set; }
            public LinkedListItem<T> CurrentItem { get; private set; }

            object IEnumerator.Current { get { return CurrentItem.Value; } }
            public T Current { get { return CurrentItem.Value; } }

            public bool MoveNext()
            {
                if (CurrentItem == null)
                    CurrentItem = Head;
                else
                    CurrentItem = CurrentItem.Next;

                return CurrentItem != null;
            }

            public void Reset()
            {
                CurrentItem = null;
            }

            public void Dispose()
            {
            }
        }
    }
}
