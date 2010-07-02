using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedList
{
    public static class LinkedList
    {
        public static LinkedListItem<T> CreateLinkedList<T>(this IEnumerable<T> coll)
        {
            LinkedListItem<T> head = null, prev = null;

            foreach (T value in coll)
            {
                LinkedListItem<T> current = new LinkedListItem<T>(value);
                if (head == null)
                    head = current;
                else
                    prev.Next = current;
                prev = current;
            }

            return head;
        }

        public static LinkedListItem<T> Reverse<T>(this LinkedListItem<T> head)
        {
            LinkedListItem<T> currentNew = null, nextNew = null;

            for (var currentOld = head; currentOld != null; currentOld = currentOld.Next)
            {
                currentNew = new LinkedListItem<T>(currentOld.Value);
                currentNew.Next = nextNew;
                nextNew = currentNew;
            }

            return currentNew;
        }
    }
}
