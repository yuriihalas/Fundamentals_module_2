using Games.GuessingGame;
using Games.HangmanGame;

namespace LearnCiSharp;

public class Game
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Please, type the game you want to play: 'Guessing', 'Hangman' or 'Exit'");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "Guessing":
                    GuessingGame.RunGame();
                    break;
                case "Hangman":
                    HangmanGame.RunGame();
                    break;
                case "Exit":
                    return;
                default:
                    Console.WriteLine("There is no such game!\nTry again");
                    break;
            }

            Console.Clear();
        }
    }
}   