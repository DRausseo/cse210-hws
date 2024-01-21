using System;

class Program
{
    static void Main()
    {
        // Core Requirement 1: Ask for the user's grade percentage
        Console.Write("Enter your grade percentage: ");
        double gradePercentage = Convert.ToDouble(Console.ReadLine());

        // Core Requirement 2: Determine the letter grade
        char letterGrade;

        if (gradePercentage >= 90)
        {
            letterGrade = 'A';
        }
        else if (gradePercentage >= 80)
        {
            letterGrade = 'B';
        }
        else if (gradePercentage >= 70)
        {
            letterGrade = 'C';
        }
        else if (gradePercentage >= 60)
        {
            letterGrade = 'D';
        }
        else
        {
            letterGrade = 'F';
        }

        // Core Requirement 3: Display the letter grade and check if the user passed
        Console.WriteLine($"Your letter grade is: {letterGrade}");

        if (letterGrade != 'F')
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Better luck next time. You didn't pass this course.");
        }
    }
}
