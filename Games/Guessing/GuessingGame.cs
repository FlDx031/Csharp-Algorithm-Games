using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;

// Solution with O(n) time complexity
class Program
{ 
    public static void GuessingGame()
    {
        Random random = new Random();
        int maxTry = 5;
        int attempts = 0;
        int correctAnswer = random.Next(1, 101); // Correct answer between 1 and 100

        Console.WriteLine("Welcome to the Guessing Game!");
        Console.WriteLine($"I have chosen a number between 1 and 100. You have {maxTry} attempts to guess it.");

    // Game loop
        while (attempts < maxTry)
        {
            Console.WriteLine($"Attempt {attempts + 1} of {maxTry}: Please guess the number between 1 and 100.");
        
            int userInput;
        // Ensure valid input
            if (!int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
                continue;
            }

            attempts++;

            if (userInput == correctAnswer)
            {
                Console.WriteLine($"Correct! The number was {correctAnswer}. You guessed it in {attempts} attempts.");
                break;
            }
            else if (userInput > correctAnswer)
            {
                Console.WriteLine($"Wrong! The number is lower. You have {maxTry - attempts} attempts left.");
            }
            else
            {
                Console.WriteLine($"Wrong! The number is higher. You have {maxTry - attempts} attempts left.");
            }
        }

    // End game statement
        if (attempts == maxTry && correctAnswer != 0) // if no correct answer after max attempts
        {
            Console.WriteLine($"The correct answer was {correctAnswer}. Better luck next time!");
        }
    }
    public static void Main()
    {
        // Test
        GuessingGame(); 
    }
}
