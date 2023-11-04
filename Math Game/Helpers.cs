using Math_Game;

public static class Helpers
{
    public static void ConfirmDialog(string message)
    {
        Console.WriteLine("\n" + message);
        Console.ReadKey();
        Console.Clear();
    }

    public static void PrintPreviousGames(List<GameData> previousGames)
    {
        if (previousGames.Count == 0)
        {
            ConfirmDialog("No saved games. Press a button to go back to the main menu...");
            return;
        }
        Console.WriteLine("Date | Game | Difficulty | Duration | Score\n");
        previousGames.ForEach(x => Console.WriteLine($"{x.Date} | {x.GameName} | {x.Difficulty} | {FormatElapsedTime(x.Duration)} | {x.Score}"));
        ConfirmDialog("Press a button to go back to the main menu...");
    }

    public static string GetOperationSymbol(GameType gameType)
    {
        switch (gameType)
        {
            case GameType.Division:
                return " / ";

            case GameType.Addition:
                return " + ";

            case GameType.Substraction:
                return " - ";

            case GameType.Multiplication:
                return " * ";

            default:
                return "";

        }
    }

    internal static Func<int, int, int> GetOperationFor(GameType game)
    {
        switch (game)
        {
            case GameType.Addition:
                return (x, y) => x + y;

            case GameType.Substraction:
                return (x, y) => x - y;

            case GameType.Multiplication:
                return (x, y) => x * y;

            case GameType.Division:
                return (x, y) => x / y;

            default:
                return (x, y) => x + y;
        }
    }

    internal static int ValidateInput(string input)
    {
        while (string.IsNullOrEmpty(input) || !Int32.TryParse(input, out _))
        {
            Console.WriteLine("Your answer needs to be an integer. Try agan.");
            input = Console.ReadLine();
        }

        return int.Parse(input);
    }

    internal static List<int> RangeForDifficulty(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                return Enumerable.Range(1, 25).ToList();

            case Difficulty.Normal:
                return Enumerable.Range(1, 50).ToList();


            case Difficulty.Hard:
                return Enumerable.Range(1, 100).ToList();


            default:
                return Enumerable.Range(1, 25).ToList();

        }
    }

    static string FormatElapsedTime(TimeSpan elapsed)
    {
        if (elapsed.TotalMinutes >= 1)
        {
            return $"{(int)elapsed.TotalMinutes} minute(s)";
        }

        if (elapsed.TotalSeconds >= 1)
        {
            return $"{(int)elapsed.TotalSeconds} second(s)";
        }
        else
        {
            return $"{elapsed.TotalMilliseconds} millisecond(s)";
        }
    }
}