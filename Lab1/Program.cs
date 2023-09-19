using Lab1;
using System;

namespace Lab1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dict = new MyDictionary<int, string>();
            dict.TryAdd(new Item<int, string>(1, "One"));
            dict.Add(new Item<int, string>(1, "One"));
            dict.Add(new Item<int, string>(2, "Two"));
            dict.Add(new Item<int, string>(3, "Three"));
            dict.Add(new Item<int, string>(4, "Four"));
            dict.Add(new Item<int, string>(5, "Five"));
            dict.Add(new Item<int, string>(101, "One hundred and one"));

            foreach (var item in dict)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(dict.Search(7));
            Console.WriteLine(dict.Search(3));
            Console.WriteLine(dict.Search(101));

            dict.Remove(7);
            dict.Remove(3);
            dict.Remove(1);
            dict.Remove(101);

            foreach (var item in dict)
            {
                Console.WriteLine(item);
            }

            dict.Clear();

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
