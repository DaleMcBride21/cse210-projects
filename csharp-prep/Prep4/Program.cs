using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        // Prompt the user to enter numbers until they enter 0
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number;
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        // Compute the sum of the numbers
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        Console.WriteLine("The sum is: " + sum);

        // Compute the average of the numbers
        double average = (double)sum / numbers.Count;
        Console.WriteLine("The average is: " + average);

        // Find the maximum number in the list
        int max = int.MinValue;
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }
        Console.WriteLine("The largest number is: " + max);
    }
}