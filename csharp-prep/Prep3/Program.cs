using System;

class Program
{
    static void Main()
    {
        // Core Requirement 1: Ask the user for the magic number
        Console.Write("What is the magic number? ");
        int magicNumber = Convert.ToInt32(Console.ReadLine());

        // Core Requirement 2: Initialize variables for the guess and the number of guesses
        int guess;
        int numberOfGuesses = 0;

        // Core Requirement 3: Loop until the user guesses the magic number
        do
        {
            // Ask the user for a guess
            Console.Write("What is your guess? ");
            guess = Convert.ToInt32(Console.ReadLine());

            // Check if the guess is higher, lower, or correct
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

            // Increment the number of guesses
            numberOfGuesses++;

        } while (guess != magicNumber);

        // Stretch Challenge: Display the number of guesses
        Console.WriteLine($"It took you {numberOfGuesses} guesses.");

        // Stretch Challenge: Ask the user if they want to play again
        Console.Write("Do you want to play again? (yes/no): ");
        string playAgain = Console.ReadLine();

        // Stretch Challenge: Loop back and play the game again if the user says "yes"
        while (playAgain.ToLower() == "yes")
        {
            // Reset the number of guesses
            numberOfGuesses = 0;

            // Generate a new random magic number
            magicNumber = new Random().Next(1, 101);

            do
            {
                Console.Write("What is your guess? ");
                guess = Convert.ToInt32(Console.ReadLine());

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }

                numberOfGuesses++;

            } while (guess != magicNumber);

            Console.WriteLine($"It took you {numberOfGuesses} guesses.");
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }
    }
}
