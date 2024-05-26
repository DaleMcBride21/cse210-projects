using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class SimpleGoal : Goal
{
    public bool IsComplete { get; set; }

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        IsComplete = false;
    }

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            IsComplete = true;
            return Points;
        }
        return 0;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete ? "[X]" : "[ ]";
        return $"{status} {ShortName} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        return $"{GetType().Name}|{ShortName}|{Description}|{Points}|{IsComplete}";
    }
}