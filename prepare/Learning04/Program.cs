using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");

        string summary = assignment.GetSummary();
        Console.WriteLine(summary);

        MathAssignment mathAssignment = new MathAssignment("7.3", "8-19", "Roberto Rodriguez", "Fractions");
        string math = mathAssignment.GetHomeworkList();
        Console.WriteLine(math);

        WritingAssignment writingAssignment = new WritingAssignment("The causes of World War 2", " ", " ", "Mary Waters", "European History");
        string writing = writingAssignment.GetWritingInformation();
        Console.WriteLine(writing);
    }
}