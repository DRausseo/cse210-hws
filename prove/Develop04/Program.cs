using System;
using System.Collections.Generic;
using System.Threading;

// Base class for all activities
class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity() { }

    public virtual void Run()
    {
        DisplayStartingMessage();
        // Common starting steps for all activities
        Thread.Sleep(3000); // Pause for a few seconds
        // Perform activity-specific steps
        DisplayEndingMessage();
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name} Activity");
        Console.WriteLine(_description);
        Console.Write($"Enter the duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Great job! You've completed the activity.");
        Console.WriteLine($"You spent {_duration} seconds on {_name} activity.");
        Thread.Sleep(3000); // Pause for a few seconds
    }

    public void ShowSpinner(int seconds)
    {
        // Display a spinner animation for 'seconds' duration
        // ...
    }

    public void ShowCountDown(int seconds)
    {
        // Display a countdown timer for 'seconds' duration
        // ...
    }
}

// BreathingActivity class
class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void Run()
    {
        base.Run();
        // Breathing activity-specific steps
        for (int i = 0; i < _duration; i++)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(3); // Display countdown for 3 seconds
            Console.WriteLine("Breathe out...");
            ShowCountDown(3); // Display countdown for 3 seconds
        }
    }
}

// ListingActivity class
class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _count = 0;
        _prompts = new List<string> { "Who are people that you appreciate?", "What are personal strengths of yours?", /* ... */ };
    }

    public override void Run()
    {
        base.Run();
        // Listing activity-specific steps
        GetRandomPrompt();
        GetListFromUser();
    }

    private void GetRandomPrompt()
    {
        // Select a random prompt from the list
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        Console.WriteLine($"Prompt: {_prompts[index]}");
    }

    private List<string> GetListFromUser()
    {
        Console.WriteLine("Start listing items. Press Enter after each item. Press 'q' to finish.");
        List<string> items = new List<string>();
        string input;
        do
        {
            input = Console.ReadLine();
            if (input.ToLower() != "q")
            {
                items.Add(input);
                _count++;
            }
        } while (input.ToLower() != "q");

        Console.WriteLine($"You listed {_count} items.");
        return items;
    }
}

// ReflectingActivity class
class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
    {
        _name = "Reflection";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
        _prompts = new List<string> { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", /* ... */ };
        _questions = new List<string> { "Why was this experience meaningful to you?", "Have you ever done anything like this before?", /* ... */ };
    }

    public override void Run()
    {
        base.Run();
        // Reflection activity-specific steps
        GetRandomPrompt();
        DisplayQuestions();
    }

    private void GetRandomPrompt()
    {
        // Select a random prompt from the list
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        Console.WriteLine($"Prompt: {_prompts[index]}");
    }

    private string GetRandomQuestion()
    {
        // Select a random question from the list
        Random rand = new Random();
        int index = rand.Next(_questions.Count);
        return _questions[index];
    }

    private void DisplayQuestions()
    {
        // Display random questions and pause for user reflection
        foreach (string question in _questions)
        {
            Console.WriteLine(question);
            ShowSpinner(3); // Display spinner for 3 seconds
        }
    }
}

class Program
{
    static void Main()
    {
        // Menu system to allow the user to choose an activity
        Console.WriteLine("Mindfulness App - Choose an Activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");

        Console.Write("Enter your choice (1, 2, or 3): ");
        int choice = int.Parse(Console.ReadLine());

        // Run the selected activity
        switch (choice)
        {
            case 1:
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.Run();
                break;
            case 2:
                ReflectingActivity reflectingActivity = new ReflectingActivity();
                reflectingActivity.Run();
                break;
            case 3:
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.Run();
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting program.");
                break;
        }
    }
}
