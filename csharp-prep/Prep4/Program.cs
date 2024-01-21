using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Core Requirement: Ask the user for a series of numbers and append each one to a list
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int input;
        do
        {
            Console.Write("Enter number: ");
            input = Convert.ToInt32(Console.ReadLine());
            
            if (input != 0)
            {
                numbers.Add(input);
            }

        } while (input != 0);

        // Core Requirement 1: Compute the sum of the numbers in the list
        int sum = numbers.Sum();
        Console.WriteLine($"The sum is: {sum}");

        // Core Requirement 2: Compute the average of the numbers in the list
        double average = numbers.Average();
        Console.WriteLine($"The average is: {average}");

        // Core Requirement 3: Find the maximum number in the list
        int maxNumber = numbers.Max();
        Console.WriteLine($"The largest number is: {maxNumber}");

        // Stretch Challenge 1: Find the smallest positive number
        int smallestPositive = numbers.Where(x => x > 0).Min();
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        // Stretch Challenge 2: Sort the numbers in the list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
