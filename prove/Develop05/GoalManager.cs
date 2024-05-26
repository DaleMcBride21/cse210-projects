using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;

    public void Start()
    {
        Console.WriteLine($"You have {score} points.");
        Console.WriteLine("");
    }

    public void ListGoalNames()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.ShortName);
        }
    }

    public void ListGoalDetails()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.Write("Enter goal type (Simple, Eternal, Checklist): ");
        string goalType = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points for the goal: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;

        if (goalType.Equals("Simple", StringComparison.OrdinalIgnoreCase))
        {
            goal = new SimpleGoal(name, description, points);
        }
        else if (goalType.Equals("Eternal", StringComparison.OrdinalIgnoreCase))
        {
            goal = new EternalGoal(name, description, points);
        }
        else if (goalType.Equals("Checklist", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write("Enter target number of completions: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points for completion: ");
            int bonus = int.Parse(Console.ReadLine());
            goal = new ChecklistGoal(name, description, points, target, bonus);
        }
        else
        {
            Console.WriteLine("Invalid goal type");
            return;
        }

        goals.Add(goal);
        Console.WriteLine($"Goal '{name}' created successfully!");
        Console.WriteLine("");
    }

    public void RecordEvent()
    {
        Console.Write("Enter the name of the goal you accomplished: ");
        string name = Console.ReadLine();
        foreach (var goal in goals)
        {
            if (goal.ShortName.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                int pointsAwarded = goal.RecordEvent();
                score += pointsAwarded;
                Console.WriteLine($"Event recorded for goal '{name}'. {pointsAwarded} points awarded!");
                return;
            }
        }
        Console.WriteLine("Goal not found");
    }

    public void SaveGoals()
    {
        try
        {
            Console.Write("Enter the file name to save goals: ");
            string fileName = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                // Write total points to the first line
                outputFile.WriteLine(score);

                // Write each goal's data
                foreach (var goal in goals)
                {
                    string goalData = goal.GetStringRepresentation();
                    outputFile.WriteLine(goalData);
                }
            }
            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }


    public void LoadGoals()
    {
        try
        {
            Console.Write("Enter the file name to load goals from: ");
            string fileName = Console.ReadLine();

            if (File.Exists(fileName))
            {
                // Read total points from the first line
                string firstLine = File.ReadLines(fileName).FirstOrDefault();
                if (int.TryParse(firstLine, out int loadedScore))
                {
                    score = loadedScore;
                }
                else
                {
                    Console.WriteLine("Error: Invalid total points format in the file.");
                    return;
                }
      
                foreach (string line in File.ReadLines(fileName).Skip(1))
                {
                    string[] parts = line.Split('|');
                    if (parts.Length > 0)
                    {
                        string goalType = parts[0];
                        switch (goalType)
                        {
                            case nameof(SimpleGoal):
                                goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])) { IsComplete = bool.Parse(parts[4]) });
                                break;
                            case nameof(EternalGoal):
                                goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                                break;
                            case nameof(ChecklistGoal):
                                goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[6]))
                                {
                                    AmountCompleted = int.Parse(parts[4]),
                                    Completed = bool.Parse(parts[7])
                                });
                                break;
                            default:
                                Console.WriteLine($"Unknown goal type: {goalType}");
                                break;
                        }
                    }
                }
                Console.WriteLine("Goals and score loaded successfully!");
            }
            else
            {
                Console.WriteLine("No saved goals found");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }

}