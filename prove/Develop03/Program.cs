using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var john316 = new Reference("John 3:16");
        var john316Scripture = new Scripture(john316, "For God so loved the world...");

        while (true)
        {
            Console.Clear();
            john316Scripture.Display();

            Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit" || john316Scripture.AllWordsHidden())
                break;

            john316Scripture.HideRandomWord();
        }
    }
}

class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int? StartVerse { get; }
    public int? EndVerse { get; }

    public Reference(string reference)
    {
        string[] parts = reference.Split(' ');

        if (parts.Length >= 2)
        {
            Book = parts[0];

            if (int.TryParse(parts[1].Split(':')[0], out int parsedChapter))
            {
                Chapter = parsedChapter;
            }
            else
            {
                Console.WriteLine($"Error parsing chapter in reference: {reference}");
                return;
            }

            string[] verses = parts[1].Split(':')[1].Split('-');
            if (int.TryParse(verses[0], out int parsedStartVerse))
            {
                StartVerse = parsedStartVerse;
            }
            else
            {
                Console.WriteLine($"Error parsing start verse in reference: {reference}");
                return;
            }

            if (verses.Length > 1 && int.TryParse(verses[1], out int parsedEndVerse))
            {
                EndVerse = parsedEndVerse;
            }
            else
            {
                EndVerse = null;
            }
        }
    }

    public string GetDisplayText()
    {
        if (StartVerse.HasValue && EndVerse.HasValue)
        {
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
        else
        {
            return $"{Book} {Chapter}:{StartVerse}";
        }
    }
}

class Scripture
{
    private readonly Reference reference;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        InitializeWords(text);
    }

    private void InitializeWords(string text)
    {
        string[] wordArray = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        words = new List<Word>();

        foreach (var wordText in wordArray)
        {
            words.Add(new Word(wordText));
        }
    }

    public void Display()
    {
        Console.WriteLine($"{reference.GetDisplayText()}: {GetVisibleText()}");
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        int visibleWordCount = words.Count(word => !word.IsHidden());

        if (visibleWordCount == 0)
            return;

        int indexToHide = random.Next(visibleWordCount);
        for (int i = 0, hiddenCount = 0; i < words.Count; i++)
        {
            if (!words[i].IsHidden())
            {
                if (hiddenCount == indexToHide)
                {
                    words[i].Hide();
                    break;
                }
                hiddenCount++;
            }
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden());
    }

    private string GetVisibleText()
    {
        List<string> visibleWords = new List<string>();

        foreach (var word in words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word.GetDisplayText());
            }
        }

        return string.Join(' ', visibleWords);
    }
}

class Word
{
    private string text;
    private bool isHidden;

    public Word(string text)
    {
        this.text = text;
        this.isHidden = false;
    }

    public void Hide()
    {
        isHidden = true;
    }

    public bool IsHidden()
    {
        return isHidden;
    }

    public string GetDisplayText()
    {
        return isHidden ? "*****" : text;
    }
}
