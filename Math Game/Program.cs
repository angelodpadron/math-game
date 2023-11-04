namespace Math_Game;

internal class Program
{
    static void Main(string[] args)
    {

        List<GameData> previousGames = new List<GameData>();

        while (true)
        {
            Console.WriteLine("What game would you like to play today? Choose from the options below:\n");
            Console.WriteLine("V - View Previous Games");
            Console.WriteLine("A - Addition");
            Console.WriteLine("S - Substraction");
            Console.WriteLine("M - Multiplication");
            Console.WriteLine("D - Division");
            Console.WriteLine("Q - Quit the program");

            ConsoleKey input = Console.ReadKey().Key;

            Console.Clear();

            switch (input)
            {
                case ConsoleKey.V:
                    Utils.PrintPreviousGames(previousGames);
                    break;

                case ConsoleKey.A:
                    PlayGame(
                        (x, y) => x + y,
                        previousGames,
                        GameType.Addition,
                        5);
                    break;

                case ConsoleKey.S:
                    PlayGame(
                        (x, y) => x - y,
                        previousGames,
                        GameType.Substraction,
                        5);
                    break;

                case ConsoleKey.M:
                    PlayGame(
                        (x, y) => x * y,
                        previousGames,
                        GameType.Multiplication,
                        5);
                    break;

                case ConsoleKey.D:
                    PlayGame(
                        (x, y) => x / y,
                        previousGames,
                        GameType.Division,
                        5);
                    break;

                case ConsoleKey.Q:
                    return;

            }
        }
    }


    private static void PlayGame(
        Func<int, int, int> operation,
        List<GameData> previousGames,
        GameType gameType,
        int rounds)
    {

        int points = 0;

        for (int i = 0; i < rounds; i++)
        {

            var random = new Random();

            int x = random.Next(0, 100);
            int y = random.Next(0, 100);

            if (gameType == GameType.Division)
            {
                var integerDivisors = Enumerable.Range(1, 100).Where(n => x % n == 0).ToList();
                y = integerDivisors[random.Next(0, integerDivisors.Count)];
            }

            string opSymbol = Utils.GetOperationSymbol(gameType);

            Console.WriteLine(x + opSymbol + y);

            int result = operation(x, y);

            try
            {

                if (Convert.ToInt32(Console.ReadLine()) == result)
                {
                    Utils.ConfirmDialog("Correct! Press a button for the next question...");
                    points++;
                }
                else
                {
                    Utils.ConfirmDialog($"Nicen't!... The correct answer was {result}. \nPress a button for the next question...");
                }
            }
            catch (FormatException)
            {
                Utils.ConfirmDialog("Try it again but using a number instead :) \nPress a button for the next question...");

            }


        }

        previousGames.Add(new GameData
        {
            GameName = gameType,
            Date = DateTime.Now,
            Points = points
        });

        Utils.ConfirmDialog($"\nAnd that's it! Total points for this game: {points} \nPress a button to go back to the main menu...");

    }



}