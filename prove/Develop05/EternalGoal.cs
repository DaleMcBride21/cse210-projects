using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return Points;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {ShortName} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        return $"{GetType().Name}|{ShortName}|{Description}|{Points}";
    }
}