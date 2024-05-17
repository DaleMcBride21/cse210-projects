

public class WritingAssignment : Assignment
{
    string _title = "";

    public WritingAssignment(string title, string textbookSection, string problems, string studentName, string topic) : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        return $"{_studentName} - {_topic}\n{_title} by {_studentName}";
    }

}
