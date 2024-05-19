class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        name = "Breathing";
        description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void RunActivity()
    {
        int elapsed = 0;
        while (elapsed < duration)
        {
            Console.Write("\nBreathe in...");
            ShowCountdown(4);
            elapsed += 4;

            if (elapsed >= duration) break;

            Console.Write("\nBreathe out...");
            ShowCountdown(4);
            elapsed += 4;
            Console.WriteLine();
        }
    }
}