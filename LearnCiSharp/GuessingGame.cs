namespace Games.GuessingGame;

public class GuessingGame
{
    private const int MIN = 0;
    private const int MAX = 50;

    public static void RunGame()
    {
        Random random = new Random();
        int secretNumber = random.Next(MIN, MAX + 1);

        do
        {
            Console.WriteLine($"\nGuess my number! (from {MIN} to {MAX})");
            Console.Write("Your answer: ");

            int playerAnswer;
            while (!Int32.TryParse(Console.ReadLine(), out playerAnswer) || !Enumerable.Range(MIN, MAX).Contains(playerAnswer))
            {
                Console.WriteLine($"Please, provide only numbers from {MIN} to {MAX}");
                Console.Write("Your answer: ");
            }

            if (playerAnswer > secretNumber)
            {
                Console.WriteLine("My number is smaller..");
            }
            else if (playerAnswer < secretNumber)
            {
                Console.WriteLine("My number is bigger..");
            }
            else
            {
                Console.WriteLine("Bullseye!");

                Console.WriteLine("\nDo you want to play one more time? (type: 'No' or 'N' if you don't want to play with me anymore)");
                string answer = Console.ReadLine();
                if (answer.Equals("N") || answer.Equals("No"))
                {
                    break;
                }

                Console.Clear();
                secretNumber = random.Next(MIN, MAX + 1);
            }
        } while (true);

        Console.WriteLine("\nThank you for the game!\nBye!");
        Task.Delay(10000).Wait();
    }
}