class Program
{
    static void Main()
    {
        string filePath = "C:\\Users\\danny\\OneDrive\\Área de Trabalho\\cse 210\\book-of-mormon-59012-spa.pdf";
        var nephi3_7 = PdfLoader.LoadScriptureFromFile(filePath, "1 Nephi 3:7");

        while (true)
        {
            Console.Clear();
            nephi3_7.Display();

            Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;

            nephi3_7.HideRandomWords();
        }
    }
}
class Scripture
{
    private readonly string reference;
    private string text;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
    }

    public void Display()
    {
        Console.WriteLine($"{reference}: {text}");
    }

    public void HideRandomWords()
    {
        var words = text.Split(' ');
        var random = new Random();
        int wordsToHide = random.Next(1, words.Length / 2);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(words.Length);
            words[index] = "*****";
        }

        text = string.Join(' ', words);
    }
}
using System;
using System.IO;
using System.Text;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Text;

class PdfLoader
{
    public static Scripture LoadScriptureFromFile(string filePath, string reference)
    {
        try
        {
            using (PdfReader pdfReader = new PdfReader(filePath))
            {
                var text = new StringBuilder();

                for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                {
                    var strategy = new SimpleTextExtractionStrategy();
                    string currentPageText = PdfTextExtractor.GetTextFromPage(pdfReader.GetPage(page), strategy);
                    text.Append(currentPageText);
                }

                return new Scripture(reference, text.ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading scripture from file: {ex.Message}");
            return new Scripture("Error", "Unable to load scripture from file.");
        }
    }
}
