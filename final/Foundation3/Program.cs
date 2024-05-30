using System;

class Program
    {
        static void Main(string[] args)
        {
            Address lectureAddress = new Address("123 University Ave", "Cityville", "State", "12345");
            Lecture lecture = new Lecture("Tech Talk", "A talk on the latest in tech", "2024-06-15", "14:00", lectureAddress, "John Doe", 100);

            Address receptionAddress = new Address("789 Gala Street", "Celebration Town", "FestiveState", "98765");
            Reception reception = new Reception("Charity Ball", "Annual charity ball for local causes", "2024-09-15", "18:00", receptionAddress, "charityrsvp@events.com");

            Address outdoorAddress = new Address("123 Festival Grounds", "Funville", "JoyRegion", "32145");
            OutdoorGathering outdoorGathering = new OutdoorGathering("Carnival", "A lively outdoor carnival with games and food", "2024-10-05", "10:00", outdoorAddress, "Clear skies expected");

            Console.WriteLine(lecture.GetStandardDetails());
            Console.WriteLine(lecture.GetFullDetails());
            Console.WriteLine(lecture.GetShortDescription());

            Console.WriteLine();

            Console.WriteLine(reception.GetStandardDetails());
            Console.WriteLine(reception.GetFullDetails());
            Console.WriteLine(reception.GetShortDescription());

            Console.WriteLine();

            Console.WriteLine(outdoorGathering.GetStandardDetails());
            Console.WriteLine(outdoorGathering.GetFullDetails());
            Console.WriteLine(outdoorGathering.GetShortDescription());
        }
    }