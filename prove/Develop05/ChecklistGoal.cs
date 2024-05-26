using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class ChecklistGoal : Goal
{
    public int AmountCompleted { get; set; }
    public int Target { get; set; }
    public int Bonus { get; set; }

    public bool Completed { get; set; }

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        AmountCompleted = 0;
        Target = target;
        Bonus = bonus;
        Completed = false;
        
    }

    public override int RecordEvent()
    {
        AmountCompleted++;
        if (AmountCompleted >= Target)
        {
            Completed = true;
            return Points + Bonus;
        }
        return Points;
    }

    public override string GetDetailsString()
    {
        string status = Completed ? "[X]" : "[ ]";
        return $"{status} {ShortName} ({Description}) -- Currently completed: {AmountCompleted}/{Target}";
    }

    public override string GetStringRepresentation()
    {
        return $"{GetType().Name}|{ShortName}|{Description}|{Points}|{AmountCompleted}|{Target}|{Bonus}|{Completed}";
    }
}