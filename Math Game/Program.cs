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
                    Helpers.PrintPreviousGames(previousGames);
                    break;

                case ConsoleKey.A:
                    GameLogic.Start(
                        GameType.Addition,
                        previousGames);
                    break;

                case ConsoleKey.S:
                    GameLogic.Start(
                       GameType.Substraction,
                       previousGames);
                    break;

                case ConsoleKey.M:
                    GameLogic.Start(
                       GameType.Multiplication,
                       previousGames);
                    break;

                case ConsoleKey.D:
                    GameLogic.Start(
                       GameType.Division,
                       previousGames);
                    break;

                case ConsoleKey.Q:
                    return;

            }
        }
    }





}