using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class Program
    {
        static List<int> list = new List<int>();
        static Dictionary<int, string> dictionary = new Dictionary<int, string>();

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("Please enter a number from the given menu:");
            Console.WriteLine("1. Add an element to the List.");
            Console.WriteLine("2. Print all the elements present in the List.");
            Console.WriteLine("3. Delete the last element from the List.");
            Console.WriteLine("4. Delete the first element from the List.");
            Console.WriteLine("5. Delete the middle element from the List.");
            Console.WriteLine("6. Calculate the average of the elements present in the List.");
            Console.WriteLine("7. Exit the application.");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter a number to add to the List: ");
                    int numToAdd = Convert.ToInt32(Console.ReadLine());
                    list.Add(numToAdd);
                    Menu();
                    break;
                case "2":
                    Console.WriteLine("Elements in the List:");
                    foreach (var num in list)
                    {
                        Console.Write(num + " ");
                    }
                    Console.WriteLine();
                    Menu();
                    break;
                case "3":
                    if (list.Count > 0)
                    {
                        list.RemoveAt(list.Count - 1);
                        Console.WriteLine("Last element deleted from the List.");
                    }
                    else
                    {
                        Console.WriteLine("List is empty.");
                    }
                    Menu();
                    break;
                case "4":
                    if (list.Count > 0)
                    {
                        list.RemoveAt(0);
                        Console.WriteLine("First element deleted from the List.");
                    }
                    else
                    {
                        Console.WriteLine("List is empty.");
                    }
                    Menu();
                    break;
                case "5":
                    if (list.Count > 0)
                    {
                        int middleIndex = list.Count / 2;
                        list.RemoveAt(middleIndex);
                        Console.WriteLine("Middle element deleted from the List.");
                    }
                    else
                    {
                        Console.WriteLine("List is empty.");
                    }
                    Menu();
                    break;
                case "6":
                    if (list.Count > 0)
                    {
                        double average = list.Average();
                        Console.WriteLine("Average of elements in the List: " + average);
                    }
                    else
                    {
                        Console.WriteLine("List is empty.");
                    }
                    Menu();
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter a valid number.");
                    Menu();
                    break;
            }
        }
    }
}
