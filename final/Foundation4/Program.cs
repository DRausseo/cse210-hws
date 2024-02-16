using System;
using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
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
