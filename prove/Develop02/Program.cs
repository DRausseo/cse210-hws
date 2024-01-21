using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public JournalEntry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Date: {Date.ToShortDateString()}, Prompt: {Prompt}, Response: {Response}";
    }
}

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();

    public void WriteNewEntry()
    {
        Console.WriteLine("Random prompt: " + GetRandomPrompt());
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        JournalEntry newEntry = new JournalEntry(GetRandomPrompt(), response);
        entries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveJournalToFile()
    {
        Console.Write("Enter a filename to save the journal: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }

        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadJournalFromFile()
    {
        Console.Write("Enter a filename to load the journal: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            entries.Clear();

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    DateTime date = DateTime.Parse(parts[0]);
                    string prompt = parts[1];
                    string response = parts[2];

                    JournalEntry loadedEntry = new JournalEntry(prompt, response) { Date = date };
                    entries.Add(loadedEntry);
                }
            }

            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found. Please make sure the file exists.");
        }
    }

    private string GetRandomPrompt()
    {
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What's a goal you want to achieve tomorrow?"
            // Add your own prompts here
        };

        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    journal.SaveJournalToFile();
                    break;
                case "4":
                    journal.LoadJournalFromFile();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}
