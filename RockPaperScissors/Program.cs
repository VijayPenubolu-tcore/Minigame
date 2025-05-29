// you'll enter code and comments here
// write 'hello world' to the console
//Console.WriteLine("hello world");

//Create mini game of rock, paper, scissors 
// rock beats scissors
//scissors beats paper
//paper beats rock
//This is a two player game and computer is one of the players
//At each turn, the player and computer will choose rock, paper, or scissors
//Invalid input need to be warned and the player will be asked to choose again
//At each turn players must select rock, paper, or scissors and informed if they win, lose, or draw
//Max points will be 5 and it should be configurable
//minigame must handle user inputs, putting them in lowercase and informing the user if the option is invalid.
//The game will end when one of the players reaches the max points
//These are the rules of the game: now generate the code
using System;
using System.Collections.Generic;

//Create a class to represent the game
public class RockPaperScissorsGame
{
    private int playerScore;
    private int computerScore;
    private const int maxPoints = 5;

    public void StartGame()
    {
        Console.WriteLine("Welcome to Rock, Paper, Scissors!");
        while (playerScore < maxPoints && computerScore < maxPoints)
        {
            PlayRound();
        }
        AnnounceWinner();
    }

    private void PlayRound()
    {
        string playerChoice = GetPlayerChoice();
        string computerChoice = GetComputerChoice();

        Console.WriteLine($"Computer chose: {computerChoice}");
        DetermineWinner(playerChoice, computerChoice);
    }

    private string GetPlayerChoice()
    {
        string choice;
        do
        {
            Console.Write("Enter rock, paper, or scissors: ");
            choice = Console.ReadLine()?.ToLower();
            if (choice != "rock" && choice != "paper" && choice != "scissors")
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        } while (choice != "rock" && choice != "paper" && choice != "scissors");

        return choice;
    }

    private string GetComputerChoice()
    {
        Random random = new Random();
        int choice = random.Next(0, 3);
        return choice switch
        {
            0 => "rock",
            1 => "paper",
            _ => "scissors",
        };
    }

    private void DetermineWinner(string playerChoice, string computerChoice)
    {
        if (playerChoice == computerChoice)
        {
            Console.WriteLine("It's a draw!");
        }
        else if ((playerChoice == "rock" && computerChoice == "scissors") ||
                 (playerChoice == "scissors" && computerChoice == "paper") ||
                 (playerChoice == "paper" && computerChoice == "rock"))
        {
            Console.WriteLine("You win this round!");
            playerScore++;
        }
        else
        {
            Console.WriteLine("You lose this round!");
            computerScore++;
        }

        Console.WriteLine($"Scores - Player: {playerScore}, Computer: {computerScore}");
    }

    private void AnnounceWinner()
    {
        if (playerScore >= maxPoints)
        {
            Console.WriteLine("Congratulations! You reached the maximum points and won the game!");
        }
        else
        {
            Console.WriteLine("The computer reached the maximum" +
                              " points and won the game! Better luck next time!");
        }
    }
}
// Main program to run the game
public class Program
{
    public static void Main(string[] args)
    {
        RockPaperScissorsGame game = new RockPaperScissorsGame();
        game.StartGame();
    }
}   