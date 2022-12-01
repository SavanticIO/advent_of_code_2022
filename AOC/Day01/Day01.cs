using System.Diagnostics;
using System.Text.Json;

namespace AOC.Day01;

public class Day01
{
    public static void Setup()
    {
        var elves = 
            JsonSerializer.Deserialize<List<List<int>>>(Input.JsonString);

        Debug.Assert(elves != null, nameof(elves) + " != null");
        foreach (var elf in elves)
        {
            ElfManager.Register(elf);
        }
        
        Console.WriteLine($"{ElfManager.HighestTotalCalories}");
        
        var threeHighest = ElfManager.AllTotalCalories
            .OrderByDescending(t => t)
            .Take(3)
            .ToList();
        Console.WriteLine($"{threeHighest.Sum()}");
    }
}