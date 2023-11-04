namespace Math_Game;

public class GameData
{
    public GameType GameName { get; set; }
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public Difficulty Difficulty { get; set; }
    public TimeSpan Duration { get; internal set; }
}
