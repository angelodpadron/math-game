namespace Math_Game;

internal class Program
{
    static void Main(string[] args)
    {

        List<dynamic> previousGames = new List<dynamic>();

        while (true)
        {
            Console.WriteLine("\nWhat game would you like to play today? Choose from the options below:");
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
                    PrintPreviousGames(previousGames);                    
                    break;

                case ConsoleKey.A:
                    PlayGame((x, y) => x + y, " + ", "Addition", previousGames, 5);
                    break;

                case ConsoleKey.S:
                    PlayGame((x, y) => x - y, " - ", "Substraction", previousGames, 5);
                    break;

                case ConsoleKey.M:
                    PlayGame((x, y) => x * y, " * ", "Product", previousGames, 5);
                    break;

                case ConsoleKey.D:
                    PlayGame((x, y) => x / y, " / ", "Division", previousGames, 5);
                    break;

                case ConsoleKey.Q:
                    return;

            }
        }
    }

    private static void ConfirmDialog(string message)
    {
        Console.WriteLine("\n" + message);
        Console.ReadKey();
        Console.Clear();
    }

    private static void PrintPreviousGames(List<dynamic> previousGames)
    {
        if (previousGames.Count == 0)
        {
            ConfirmDialog("No saved games. Press a button to go back to the main menu...");
            return;
        }

        previousGames.ForEach(x => Console.WriteLine(x.Date + " - " + x.Game + " - " + x.Points));
        ConfirmDialog("Press a button to go back to the main menu...");
    }

    private static void PlayGame(Func<int, int, int> operation, string opSymbol, string gameName, List<dynamic> previousGames, int rounds)
    {

        int points = 0;

        for (int i = 0; i < rounds; i++)
        {

            var random = new Random();
            int x = random.Next(1, 10);
            int y = random.Next(1, 10);

            int result = operation(x, y);
            Console.WriteLine(x + opSymbol + y);

            if (Convert.ToInt32(Console.ReadLine()) == result)
            {
                ConfirmDialog("Correct! Press a button for the next question...");
                points ++;                
            }
            else
            {
                ConfirmDialog("Nicen't!... The correct answer was " + result + "\n" + "Press a button for the next question...");
            }

        }

        previousGames.Add(new
        {
            Game = gameName,
            Date = DateTime.Now,
            Points = points
        });

        ConfirmDialog("And that's it. Total points for this game: " + points + "\n" + "Press a button to go back to the main menu");

    }


}