using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    // initialize entry objects
    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    // format the entry for display
    public override string ToString()
    {
        string formattedDate = DateTime.ParseExact(Date, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy");
        return $"Date: {formattedDate} - Prompt: {Prompt}\n\t{Response}\n";
    }
}

// class to manage the journal
class Journal
{
    private List<Entry> entries;

    
    public Journal()
    {
        entries = new List<Entry>();
    }

    // add a new entry to the journal
    public void AddEntry(string prompt, string response, string date)
    {
        Entry newEntry = new Entry(prompt, response, date);
        entries.Add(newEntry);
    }

    // display all entries in the journal
    public void DisplayEntries()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    // save the journal to a file
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    // load entries from a file
    public void LoadFromFile(string filename)
    {
        entries.Clear(); // clear existing entries before loading from file

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    AddEntry(parts[1], parts[2], parts[0]);
                }
            }
        }
    }
}

// Main
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string choice;

        // Main menu loop
        do
        {
            Console.WriteLine("\n1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    SaveJournalToFile(journal);
                    break;
                case "4":
                    LoadJournalFromFile(journal);
                    break;
                case "5":
                    Console.WriteLine("Exiting program.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (choice != "5");
    }

    // Method to write a new entry
    static void WriteNewEntry(Journal journal)
    {
        Random random = new Random();
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        // Select a random prompt
        int index = random.Next(prompts.Count);
        string prompt = prompts[index];

        // get response from user
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        // get the date and time
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        // add entry to journal
        journal.AddEntry(prompt, response, date);
        Console.WriteLine("Entry added to journal.");
    }

    // save the journal to a file
    static void SaveJournalToFile(Journal journal)
    {
        Console.Write("Enter filename to save the journal: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
        Console.WriteLine("Journal saved to file successfully.");
    }

    // load the journal from a file
    static void LoadJournalFromFile(Journal journal)
    {
        Console.Write("Enter filename to load the journal: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
        Console.WriteLine("Journal loaded from file successfully.");
    }
}
