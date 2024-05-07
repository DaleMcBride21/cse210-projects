using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

// Represents a single journal entry
class Entry
{
    public string Prompt { get; set; } // Prompt for the entry
    public string Response { get; set; } // Response to the prompt
    public string Date { get; set; } // Date and time of the entry

    // Constructor to initialize entry properties
    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    // Format the entry for display
    public override string ToString()
    {
        // Format date to MM/dd/yyyy
        string formattedDate = DateTime.ParseExact(Date, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                                        .ToString("MM/dd/yyyy");
        return $"Date: {formattedDate} - Prompt: {Prompt}\n\t{Response}\n";
    }
}

// Manages a collection of journal entries
class Journal
{
    private List<Entry> entries; // List to store journal entries

    // Constructor to initialize the journal
    public Journal()
    {
        entries = new List<Entry>();
    }

    // Add a new entry to the journal
    public void AddEntry(string prompt, string response, string date)
    {
        Entry newEntry = new Entry(prompt, response, date);
        entries.Add(newEntry);
    }

    // Display all entries in the journal
    public void DisplayEntries()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    // Save the journal to a file
    public void SaveToFile(string filename)
    {
        // Write entries to the file in the format: Date|Prompt|Response
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    // Load entries from a file
    public void LoadFromFile(string filename)
    {
        entries.Clear(); // Clear existing entries before loading from file

        // Read entries from the file and add them to the journal
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

// Main program
class Program
{
    // Entry point of the program
    static void Main(string[] args)
    {
        Journal journal = new Journal(); // Create a new journal object
        string choice;

        // Main menu loop
        do
        {
            // Display menu options
            Console.WriteLine("\n1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine(); // Read user choice

            // Perform action based on user choice
            switch (choice)
            {
                case "1": // Write a new entry
                    WriteNewEntry(journal);
                    break;
                case "2": // Display all entries
                    journal.DisplayEntries();
                    break;
                case "3": // Save entries to a file
                    SaveJournalToFile(journal);
                    break;
                case "4": // Load entries from a file
                    LoadJournalFromFile(journal);
                    break;
                case "5": // Exit the program
                    Console.WriteLine("Exiting program.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (choice != "5"); // Continue until the user chooses to exit
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

        // Prompt user for response
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        // Get current date and time
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        // Add entry to the journal
        journal.AddEntry(prompt, response, date);
        Console.WriteLine("Entry added to journal.");
    }

    // Save the journal to a file
    static void SaveJournalToFile(Journal journal)
    {
        Console.Write("Enter filename to save the journal: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
        Console.WriteLine("Journal saved to file successfully.");
    }

    // Load the journal from a file
    static void LoadJournalFromFile(Journal journal)
    {
        Console.Write("Enter filename to load the journal: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
        Console.WriteLine("Journal loaded from file successfully.");
    }
}
