using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int number))
        {
            char letterGrade;
            if (number >= 90)
            {
                letterGrade = 'A';
            }
            else if (number >= 80)
            {
                letterGrade = 'B';
            }
            else if (number >= 70)
            {
                letterGrade = 'C';
            }
            else if (number >= 60)
            {
                letterGrade = 'D';
            }
            else
            {
                letterGrade = 'F';
            }

            Console.WriteLine($"Your letter grade is: {letterGrade}");


            if (number >= 70)
            {
                Console.WriteLine("You passed!");
            }
            else
            {
                Console.WriteLine("Keep Trying!");
            }
            
        }
    }
}
