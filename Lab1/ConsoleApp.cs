using Lab1;
using System;
using System.Collections.Generic;

namespace Lab1
{
    public class ConsoleApp
    {
        private MyDictionary<int, string> _dict;

        public ConsoleApp()
        {
            _dict = new MyDictionary<int, string>();
        }

        public void Run()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("MyDictionary Console App");
                Console.WriteLine("========================");
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add Key-Value Pair");
                Console.WriteLine("2. Search for a Key");
                Console.WriteLine("3. Remove a Key");
                Console.WriteLine("4. Display All Key-Value Pairs");
                Console.WriteLine("5. Clear Dictionary");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice (1-6): ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Add Key-Value Pair");
                            Console.WriteLine("===================");
                            Console.Write("Enter Key (int): ");
                            if (int.TryParse(Console.ReadLine(), out int key))
                            {
                                Console.Write("Enter Value (string): ");
                                string value = Console.ReadLine();
                                _dict.Add(key, value);
                                Console.WriteLine("\nKey-Value pair added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid input. Key must be an integer.");
                            }
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("Search for a Key");
                            Console.WriteLine("=================");
                            Console.Write("Enter Key to search for: ");
                            if (int.TryParse(Console.ReadLine(), out int searchKey))
                            {
                                string result = _dict.Search(searchKey);
                                Console.WriteLine($"\nSearch result: {result}");
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid input. Key must be an integer.");
                            }
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("Remove a Key");
                            Console.WriteLine("============");
                            Console.Write("Enter Key to remove: ");
                            if (int.TryParse(Console.ReadLine(), out int removeKey))
                            {
                                bool removed = _dict.Remove(removeKey);
                                if (removed)
                                {
                                    Console.WriteLine("\nKey-Value pair removed successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("\nKey not found in the dictionary.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid input. Key must be an integer.");
                            }
                            break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine("All Key-Value Pairs");
                            Console.WriteLine("===================");
                            foreach (var item in _dict)
                            {
                                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
                            }
                            break;

                        case 5:
                            Console.Clear();
                            Console.WriteLine("Clear Dictionary");
                            Console.WriteLine("================");
                            _dict.Clear();
                            Console.WriteLine("\nDictionary cleared.");
                            break;

                        case 6:
                            Console.Clear();
                            Console.WriteLine("Exiting the application.");
                            return;

                        default:
                            Console.Clear();
                            Console.WriteLine("\nInvalid choice. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nInvalid input. Please enter a number.");
                }

                Console.Write("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}


