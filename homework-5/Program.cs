using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = Enumerable.Range(1, 10).ToList();

        //lambda function to square each element in the list and store the result in a new list
        List<int> squaredNumbers = numbers.Select(x => x * x).ToList();

        //lambda function to filter the list to contain only even numbers and store the result in a new list
        List<int> evenNumbers = numbers.Where(x => x % 2 == 0).ToList();

        //sum of all elements in the filtered list
        int sumOfEvenNumbers = evenNumbers.Sum();

        Console.WriteLine("Original List:");
        PrintList(numbers);

        Console.WriteLine("Squared List:");
        PrintList(squaredNumbers);

        Console.WriteLine("Even Numbers List:");
        PrintList(evenNumbers);

        Console.WriteLine($"Sum of Even Numbers: {sumOfEvenNumbers}");
    }
    static void PrintList(List<int> list)
    {
        foreach (int num in list)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
