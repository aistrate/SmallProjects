using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var greekLetters = LinkedList.CreateLinkedList(new string[] { "Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Fi" });
            var integers = LinkedList.CreateLinkedList(new int[] { 1, 3, 12, 44, 138, 5, 88, 19 });
            var empty = LinkedList.CreateLinkedList(new decimal[] { });
            var oneElement = LinkedList.CreateLinkedList(new double[] { Math.PI });
            var characters = LinkedList.CreateLinkedList("abcdefghijklmnopqrstuvwxyz");

            Console.WriteLine("Greek letters: {0}", greekLetters);
            Console.WriteLine("Integers: {0}", integers);
            Console.WriteLine("Empty: {0}", empty);
            Console.WriteLine("One element: {0}", oneElement);
            Console.WriteLine("Characters: {0}", characters);
            
            Console.WriteLine();
            Console.WriteLine("Reversed greek letters: {0}", greekLetters.Reverse());
            Console.WriteLine("Reversed integers: {0}", integers.Reverse());
            Console.WriteLine("Reversed empty: {0}", empty.Reverse());
            Console.WriteLine("Reversed one element: {0}", oneElement.Reverse());
            Console.WriteLine("Reversed characters: {0}", characters.Reverse());

            Console.WriteLine();
            Console.WriteLine("Greek letters, length: {0}", greekLetters.Length);
            Console.WriteLine("Integers, length: {0}", integers.Length);
            Console.WriteLine("One element, length: {0}", oneElement.Length);
            Console.WriteLine("Characters, length: {0}", characters.Length);
        }
    }
}
