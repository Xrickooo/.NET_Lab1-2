using Lab1;
using System;
using System.Collections.Generic;

namespace Lab1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dict = new MyDictionary<int, string>();
            dict.Add(1, "One");
            dict.Add(2, "Two");
            dict.Add(3, "Three");
            dict.Add(4, "Four");
            dict.Add(5, "Five");
            dict.TryAdd(new Item<int, string>(101, "One hundred and one"));

            foreach (var item in dict)
            {
                Console.WriteLine(item);
            }

            //Console.WriteLine(dict.Search(7));
            Console.WriteLine(dict.Search(3));
            Console.WriteLine(dict.Search(101));

            //dict.Remove(7);
            dict.Remove(3);
            dict.Remove(1);
            dict.Remove(101);

            foreach (var item in dict)
            {
                Console.WriteLine(item);
            }

            KeyValuePair<int, string>[] array = new KeyValuePair<int, string>[3];

            dict.CopyTo(array, 0);

            foreach (var kvp in array)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            dict.Clear();

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
