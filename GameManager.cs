using Games.GuessingGame;
using Games.HangmanGame;

namespace LearnCiSharp;

public static class GameManager
{
    public static void RunGame()
    {
        while (true)
        {
            Console.WriteLine("Please, type the game you want to play: 'Guessing', 'Hangman' or 'Exit'");
            var answer = Console.ReadLine();
            Console.Clear();
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
        }
    }
}