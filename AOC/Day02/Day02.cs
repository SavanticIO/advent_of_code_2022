using System.Diagnostics;
using System.Text.Json;

namespace AOC.Day02;

public class Day02
{
    public static void Setup()
    {
        var games = 
            JsonSerializer.Deserialize<List<List<string>>>(Input.JsonString);

        Debug.Assert(games != null, nameof(games) + " != null");
        foreach (var game in games)
        {
            GameManager.Register(game);
        }
        
        Console.WriteLine($"My Total Score Part1: {GameManager.MyTotalScorePart1}");
        Console.WriteLine($"Opponent Total Score Part1: {GameManager.OpponentTotalScorePart1}");
        Console.WriteLine($"My Total Score Part2: {GameManager.MyTotalScorePart2}");
        Console.WriteLine($"Opponent Total Score Part2: {GameManager.OpponentTotalScorePart2}");
    }
}