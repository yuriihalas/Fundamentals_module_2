namespace Games.HangmanGame;

public static class HangmanGame
{
    private const int PLAYER_LIFE_POINTS = 6;
    private static readonly string[] _dictionary = { "fish", "dog", "parrot" };

    public static void RunGame()
    {
        int playerLifePoints = PLAYER_LIFE_POINTS;
        int randomIndex = new Random().Next(0, _dictionary.Length);
        string secretWord = _dictionary[randomIndex];

        char[] letters = secretWord.ToArray();
        char[] maskedLetters = Enumerable.Repeat('_', secretWord.Length).ToArray();
        Console.WriteLine(String.Join(" ", maskedLetters));

        while (playerLifePoints > 0)
        {
            string lifeMessage = $"Player has {playerLifePoints} life points\n";
            Console.Write(new string(' ', Console.BufferWidth - lifeMessage.Length) + lifeMessage);
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);

            Console.WriteLine("Please, provide a letter");
            Console.Write("Your letter: ");
            char playerAnswer = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (maskedLetters.Contains(playerAnswer))
            {
                Console.WriteLine(String.Join(" ", maskedLetters));
                Console.WriteLine($"You have already guessed a letter {playerAnswer}");
                Console.WriteLine("Please, select a letter that has not already been guessed");
            }
            else if (letters.Contains(playerAnswer))
            {
                List<int> indexes = Enumerable.Range(0, letters.Length).Where(i => letters[i] == playerAnswer).ToList();
                indexes.ForEach(i => maskedLetters[i] = letters[i]);

                Console.WriteLine(String.Join(" ", maskedLetters));
                if (letters.SequenceEqual(maskedLetters))
                {
                    Console.WriteLine("Congratulations!\nYou win!");
                    break;
                }
            }
            else
            {
                Console.WriteLine(String.Join(" ", maskedLetters));
                playerLifePoints--;
                Console.WriteLine("No such letter\n");
            }

            Console.WriteLine();
        }

        Console.WriteLine("Game over");
        Task.Delay(10000).Wait();
    }
}