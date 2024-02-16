//Project Option: Open-ended project
//For the open-ended project option, I plan to develop a program that facilitates personal finance management. The program will allow users to track their income, expenses, savings, and inusing System;
using System.Collections.Generic;

// Class to manage incomes
public class Income
{
    public string Source { get; set; }  // Income source
    public decimal Amount { get; set; } // Income amount
    public DateTime Date { get; set; }  // Date of income

    public Income(string source, decimal amount, DateTime date)
    {
        Source = source;
        Amount = amount;
        Date = date;
    }
}

// Class to manage expenses
public class Expense
{
    public string Category { get; set; } // Expense category
    public decimal Amount { get; set; }  // Expense amount
    public DateTime Date { get; set; }   // Date of expense

    public Expense(string category, decimal amount, DateTime date)
    {
        Category = category;
        Amount = amount;
        Date = date;
    }
}

// Class to manage savings
public class Savings
{
    public string Purpose { get; set; }  // Saving purpose
    public decimal Amount { get; set; }  // Saving amount
    public DateTime Date { get; set; }   // Date of saving

    public Savings(string purpose, decimal amount, DateTime date)
    {
        Purpose = purpose;
        Amount = amount;
        Date = date;
    }
}

// Class to manage investments
public class Investment
{
    public string Type { get; set; }     // Investment type
    public decimal Amount { get; set; }  // Investment amount
    public DateTime Date { get; set; }   // Date of investment

    public Investment(string type, decimal amount, DateTime date)
    {
        Type = type;
        Amount = amount;
        Date = date;
    }
}

// Class to represent a user
public class User
{
    public string Name { get; set; }  // User's name
    public List<Income> Incomes { get; set; }        // List of user's incomes
    public List<Expense> Expenses { get; set; }      // List of user's expenses
    public List<Savings> Savings { get; set; }       // List of user's savings
    public List<Investment> Investments { get; set; } // List of user's investments

    public User(string name)
    {
        Name = name;
        Incomes = new List<Income>();
        Expenses = new List<Expense>();
        Savings = new List<Savings>();
        Investments = new List<Investment>();
    }

    // Method to add an income
    public void AddIncome(string source, decimal amount, DateTime date)
    {
        Incomes.Add(new Income(source, amount, date));
    }

    // Method to add an expense
    public void AddExpense(string category, decimal amount, DateTime date)
    {
        Expenses.Add(new Expense(category, amount, date));
    }

    // Method to add a saving
    public void AddSaving(string purpose, decimal amount, DateTime date)
    {
        Savings.Add(new Savings(purpose, amount, date));
    }

    // Method to add an investment
    public void AddInvestment(string type, decimal amount, DateTime date)
    {
        Investments.Add(new Investment(type, amount, date));
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Example usage
        User user = new User("John");

        // Add some incomes
        user.AddIncome("Salary", 3000, DateTime.Now);
        user.AddIncome("Freelance", 500, DateTime.Now.AddDays(-5));

        // Add some expenses
        user.AddExpense("Food", 200, DateTime.Now);
        user.AddExpense("Rent", 1000, DateTime.Now.AddDays(-10));

        // Add some savings
        user.AddSaving("Vacation", 500, DateTime.Now);
        user.AddSaving("Emergency Fund", 1000, DateTime.Now.AddDays(-15));

        // Add some investments
        user.AddInvestment("Stocks", 2000, DateTime.Now);
        user.AddInvestment("Bonds", 1500, DateTime.Now.AddDays(-20));

        // Display user's data
        Console.WriteLine($"User: {user.Name}");

        Console.WriteLine("Incomes:");
        foreach (var income in user.Incomes)
        {
            Console.WriteLine($"{income.Source}: {income.Amount}, Date: {income.Date}");
        }

        Console.WriteLine("Expenses:");
        foreach (var expense in user.Expenses)
        {
            Console.WriteLine($"{expense.Category}: {expense.Amount}, Date: {expense.Date}");
        }

        Console.WriteLine("Savings:");
        foreach (var saving in user.Savings)
        {
            Console.WriteLine($"{saving.Purpose}: {saving.Amount}, Date: {saving.Date}");
        }

        Console.WriteLine("Investments:");
        foreach (var investment in user.Investments)
        {
            Console.WriteLine($"{investment.Type}: {investment.Amount}, Date: {investment.Date}");
        }
    }
}

    public int Length { get; set; }
    private List<string> Comments { get; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<string>();
    }

    public void AddComment(string comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");

        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine(comment);
        }
    }
}

public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    public override string ToString()
    {
        return $"{CommenterName}: {Text}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("C# Tutorial", "John", 600);
        video1.AddComment("Great tutorial!");
        video1.AddComment("Thanks for sharing");
        video1.AddComment("Can you make one about ASP.NET?");

        Video video2 = new Video("Introduction to Object-Oriented Programming", "Mary", 720);
        video2.AddComment("Very clear, thanks");
        video2.AddComment("Helped me understand the concepts better");
        video2.AddComment("Will there be a continuation of this video?");

        List<Video> videos = new List<Video> { video1, video2 };

        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
            Console.WriteLine();
        }
    }
}
