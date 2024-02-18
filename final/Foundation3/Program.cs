using System;
using System.Collections.Generic;

namespace FinalProject
{
    // Class for representing a YouTube video comment
    class Comment
    {
        private string commenterName;
        private string commentText;

        // Constructor
        public Comment(string commenterName, string commentText)
        {
            this.commenterName = commenterName;
            this.commentText = commentText;
        }

        // Getter for commenter name
        public string GetCommenterName()
        {
            return commenterName;
        }

        // Getter for comment text
        public string GetCommentText()
        {
            return commentText;
        }
    }

    // Class for representing a YouTube video
    class Video
    {
        private string title;
        private string author;
        private int lengthInSeconds;
        private List<Comment> comments;

        // Constructor
        public Video(string title, string author, int lengthInSeconds)
        {
            this.title = title;
            this.author = author;
            this.lengthInSeconds = lengthInSeconds;
            this.comments = new List<Comment>();
        }

        // Method to add a comment to the video
        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        // Method to get the number of comments
        public int GetNumberOfComments()
        {
            return comments.Count;
        }

        // Method to display video details and comments
        public void DisplayVideoDetailsAndComments()
        {
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Author: " + author);
            Console.WriteLine("Length (seconds): " + lengthInSeconds);
            Console.WriteLine("Number of comments: " + GetNumberOfComments());
            Console.WriteLine("Comments:");
            foreach (var comment in comments)
            {
                Console.WriteLine("Comment by " + comment.GetCommenterName() + ": " + comment.GetCommentText());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create some video objects
            Video video1 = new Video("Title 1", "Author 1", 120);
            Video video2 = new Video("Title 2", "Author 2", 180);

            // Add comments to the videos
            video1.AddComment(new Comment("User1", "Great video!"));
            video1.AddComment(new Comment("User2", "I learned a lot from this."));

            video2.AddComment(new Comment("User3", "Awesome content!"));
            video2.AddComment(new Comment("User4", "Keep up the good work."));

            // Create a list of videos
            List<Video> videos = new List<Video>();
            videos.Add(video1);
            videos.Add(video2);

            // Display details of each video
            foreach (var video in videos)
            {
                video.DisplayVideoDetailsAndComments();
                Console.WriteLine();
            }
        }
    }
}
