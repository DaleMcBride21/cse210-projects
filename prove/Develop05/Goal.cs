abstract class Goal
{
    public string ShortName { get; private set; }
    public string Description { get; private set; }
    public int Points { get; private set; }

    protected Goal(string name, string description, int points)
    {
        ShortName = name;
        Description = description;
        Points = points;
    }

    public abstract int RecordEvent();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}