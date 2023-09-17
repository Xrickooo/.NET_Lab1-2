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
        }
    }
}
