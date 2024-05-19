class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("\u001b[2J");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            activity.StartActivity();
        }
    }

    
}

abstract class Activity
{
    protected string name;
    protected string description;
    protected int duration;

    public void StartActivity()
    {
        Console.Write("\u001b[2J");
        Console.WriteLine($"Welcome to the {name} Activity...");
        Console.WriteLine(description);
        Console.Write("How long, in seconds, would you like for your session? ");
        duration = int.Parse(Console.ReadLine());
        Console.Write("\u001b[2J");


        Console.WriteLine("Get Ready...");
        ShowSpinner(3);

        RunActivity();

        Console.WriteLine("Well Done!");
        Console.WriteLine($"You have completed the {name} activity for {duration} seconds.");
        ShowSpinner(3);
    }

    protected abstract void RunActivity();

    protected static void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        int iterations = seconds * 1000 / 500;

        for (int i = 0; i < iterations; i++)
        {
            foreach (string s in animationStrings)
            {
                Console.Write(s);
                Thread.Sleep(100);
                Console.Write("\b \b");
            }
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}