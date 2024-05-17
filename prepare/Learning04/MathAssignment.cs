
public class MathAssignment : Assignment
{
    string _textbookSection = "";
    string _problems = ""; 

    public MathAssignment(string textbookSection, string problems, string studentName, string topic) : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
        _studentName = studentName;
        _topic = topic;
    }

    public string GetHomeworkList()
    {
        return $"{_studentName} - {_topic}\nSection {_textbookSection} Problems {_problems}";
    }
}