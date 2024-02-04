using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Crear una referencia para un solo versículo (ejemplo: "John 3:16")
        var john316 = new Reference("John 3:16");

        // Crear un pasaje de escritura basado en la referencia y el texto
        var john316Scripture = new Scripture(john316, "For God so loved the world...");

        while (true)
        {
            Console.Clear();
            john316Scripture.Display();

            Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;

            john316Scripture.HideRandomWords();
        }
    }
}

class Reference
{
    private readonly string book;
    private readonly int chapter;
    private readonly int? startVerse;
    private readonly int? endVerse;

    public Reference(string reference)
    {
        // Implementa la lógica para parsear la referencia
        string[] parts = reference.Split(' ');

        // Asegúrate de manejar casos de referencia no válidos
        if (parts.Length >= 2)
        {
            book = parts[0];

            // Lógica para parsear el capítulo y versículos...
            // Ejemplo: "John 3:16" se divide en ["John", "3:16"]
            // Debes asegurarte de que el formato sea correcto antes de realizar los análisis

            // Parsea el capítulo
            if (int.TryParse(parts[1].Split(':')[0], out int parsedChapter))
            {
                chapter = parsedChapter;
            }
            else
            {
                Console.WriteLine($"Error parsing chapter in reference: {reference}");
                return;
            }

            // Parsea los versículos
            string[] verses = parts[1].Split(':')[1].Split('-');
            if (int.TryParse(verses[0], out int parsedStartVerse))
            {
                startVerse = parsedStartVerse;
            }
            else
            {
                Console.WriteLine($"Error parsing start verse in reference: {reference}");
                return;
            }

            // Verifica si hay un versículo final
            if (verses.Length > 1 && int.TryParse(verses[1], out int parsedEndVerse))
            {
                endVerse = parsedEndVerse;
            }
            else
            {
                endVerse = null;
            }
        }
    }

    public string GetDisplayText()
    {
        // Implementa la lógica para obtener el texto de visualización
        if (startVerse.HasValue && endVerse.HasValue)
        {
            return $"{book} {chapter}:{startVerse}-{endVerse}";
        }
        else
        {
            return $"{book} {chapter}:{startVerse}";
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
        // Crea una lista de palabras a partir del texto
        string[] wordArray = text.Split(' ');
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

    public void HideRandomWords()
    {
        // Implementa la lógica para ocultar palabras aleatorias
        Random random = new Random();

        foreach (var word in words)
        {
            if (random.Next(2) == 0) // 50% de probabilidad de ocultar cada palabra
            {
                word.Hide();
            }
        }
    }

    private string GetVisibleText()
    {
        // Obtiene el texto visible (sin las palabras ocultas)
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

    public void Show()
    {
        isHidden = false;
    }

    public bool IsHidden()
    {
        return isHidden;
    }

    public string GetDisplayText()
    {
        return isHidden
            ? "*****"
            : text;
    }
}
