using Math_Game;

public static class Utils
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

        previousGames.ForEach(x => Console.WriteLine($"{x.Date} | {x.GameName} | {x.Points} points"));
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
}