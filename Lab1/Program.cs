using Lab1;
using System;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<int, string>();
            dict.Add(new Item<int, string>(1, "One"));
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

            Console.WriteLine(dict.Search(7) ?? "Not Found");
            Console.WriteLine(dict.Search(3) ?? "Not Found");
            Console.WriteLine(dict.Search(101) ?? "Not Found");

            dict.Remove(7);
            dict.Remove(3);
            dict.Remove(1);
            dict.Remove(101);


            foreach (var item in dict)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
