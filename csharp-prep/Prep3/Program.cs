using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int magicNumber = random.Next(1, 101);

        Console.WriteLine("Welcome to Guess My Number!");
        Console.WriteLine("I've picked a number between 1 and 100. Try to guess it!");

        int guess;
        do
        {
            Console.Write("Enter your guess: ");
            guess = int.Parse(Console.ReadLine());

            
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        } while (guess != magicNumber);
    }
}