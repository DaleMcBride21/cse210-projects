using System;
using System.Collections.Generic;
using System.Linq;

// Word class represents individual words in the scripture text.
public class Word
{
    // Text property holds the actual word.
    public string Text { get; private set; }
    // Hidden property determines if the word is hidden or visible.
    public bool Hidden { get; set; }

    // Constructor initializes the Word object with the given text.
    public Word(string text)
    {
        Text = text;
        Hidden = false; // By default, words are not hidden.
    }

    // ToString method returns the word text if it's not hidden, else returns underscores.
    public override string ToString()
    {
        return Hidden ? "_____" : Text;
    }
}

// ScriptureReference class represents a reference to a specific verse or range of verses in a book of the Bible.
public class ScriptureReference
{
    // Properties to hold book, chapter, start verse, and end verse.
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int EndVerse { get; private set; }

    // Constructor parses the reference string into its components.
    public ScriptureReference(string reference)
    {
        string[] parts = reference.Split(':');
        Book = parts[0];
        string[] verseParts = parts[1].Split('-');
        Chapter = int.Parse(verseParts[0]);
        if (verseParts.Length > 1)
            EndVerse = int.Parse(verseParts[1]);
        else
            EndVerse = Chapter; // If only one verse is given, set end verse same as start.
        StartVerse = Chapter; // By default, start verse is the chapter number.
    }

    // ToString method formats the scripture reference.
    public override string ToString()
    {
        if (StartVerse == EndVerse)
            return $"{Book} {Chapter}:{StartVerse}";
        else
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}

// Scripture class represents a portion of scripture with words that can be hidden.
public class Scripture
{
    private List<Word> words = new List<Word>(); // List to hold words.
    private int hiddenWordCount = 0; // Counter to track hidden words.

    // Constructor takes scripture reference and text and initializes the scripture object.
    public Scripture(string reference, string text)
    {
        Reference = new ScriptureReference(reference);
        foreach (var word in text.Split(' '))
        {
            words.Add(new Word(word)); // Split text into words and add them to the list.
        }
    }

    // Property to get the scripture reference.
    public ScriptureReference Reference { get; private set; }

    // Method to hide a random selection of words. Returns true if there are still words to hide.
    public bool HideWords()
    {
        if (hiddenWordCount == words.Count)
            return false; // All words are already hidden.

        Random random = new Random();
        int wordsToHide = Math.Min(3, words.Count - hiddenWordCount); // Max 3 words to hide.
        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(words.Count);
            if (!words[index].Hidden)
            {
                words[index].Hidden = true; // Hide the word.
                hiddenWordCount++;
            }
        }
        return true; // There are still words left to hide.
    }

    // Method to display the scripture with hidden or visible words.
    public void Display()
    {
        Console.Write("\u001b[2J"); // Clears the console.

        Console.WriteLine(Reference); // Display scripture reference.
        foreach (var word in words)
        {
            Console.Write(word + " "); // Display each word.
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Example usage
        // Create a new scripture object with reference "John 3:16" and text.
        Scripture scripture = new Scripture("Proverbs 3:5", "Trust in the Lord with all thine heart; and lean not unto thine own understanding.");
        scripture.Display(); // Display the scripture.
        Console.WriteLine("Press Enter to hide words, type 'quit' to exit.");
        while (true)
        {
            if (Console.ReadLine() == "quit")
                break;

            if (!scripture.HideWords())
            {
                Console.WriteLine("All words hidden. Exiting...");
                break;
            }

            scripture.Display(); // Display the scripture after hiding words.
        }
    }
}

