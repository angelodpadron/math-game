using System.Diagnostics;

namespace Math_Game
{
    public static class GameLogic
    {
        private static void PlayGame(GameType game, Difficulty difficulty, List<GameData> previousGames)
        {

            int score = 0;
            
            Stopwatch stopwatch = new Stopwatch();

            List<int> xValues = Helpers.RangeForDifficulty(difficulty);
            List<int> yValues = Helpers.RangeForDifficulty(difficulty);

            var random = new Random();
            string opSymbol = Helpers.GetOperationSymbol(game);
            Func<int, int, int> operation = Helpers.GetOperationFor(game);

            stopwatch.Start();

            for (int i = 0; i < 5; i++)
            {
                int x = xValues[random.Next(0, xValues.Count)];
                int y = yValues[random.Next(0, yValues.Count)];

                if (game == GameType.Division)
                {
                    var integerDivisors = Enumerable.Range(1, 100).Where(n => x % n == 0).ToList();
                    y = integerDivisors[random.Next(0, integerDivisors.Count)];
                }

                Console.WriteLine(x + opSymbol + y);

                int result = operation(x, y);

                int answer = Helpers.ValidateInput(Console.ReadLine());

                if (answer == result)
                {
                    Helpers.ConfirmDialog("Correct! Press a button for the next question...");
                    score++;
                }
                else
                {
                    Helpers.ConfirmDialog($"Incorrect. The correct answer was {result}. \nPress a button for the next question...");
                }

            }

            stopwatch.Stop();

            previousGames.Add(new GameData
            {
                GameName = game,
                Date = DateTime.Now,
                Score = score,
                Difficulty = difficulty,
                Duration = stopwatch.Elapsed,
            });;

            Helpers.ConfirmDialog($"\nAnd that's it! Total points for this game: {score} \nPress a button to go back to the main menu...");
        }

        public static void Start(GameType game, List<GameData> previousGames)
        {
            Console.WriteLine("Select difficulty: \n");
            Console.WriteLine("1. Easy\n2. Normal \n3. Hard");

            ConsoleKey input = Console.ReadKey().Key;

            Console.Clear();

            switch (input)
            {
                case ConsoleKey.D1:
                    PlayGame(game, Difficulty.Easy, previousGames);
                    break;
                case ConsoleKey.D2:
                    PlayGame(game, Difficulty.Normal, previousGames);
                    break;
                case ConsoleKey.D3:
                    PlayGame(game, Difficulty.Hard, previousGames);
                    break;
            }
        }
    }


}
