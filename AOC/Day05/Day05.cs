using System.Text.Json;

namespace AOC.Day05;

public class Day05
{
    private static readonly List<List<char>> Crates = new()
    {
        new List<char>() {'G','D','V','Z','J','S','B'},
        new List<char>() {'Z','S','M','G','V','P'},
        new List<char>() {'C','L','B','S','W','T','Q','F'},
        new List<char>() {'H','J','G','W','M','R','V','Q'},
        new List<char>() {'C','L','S','N','F','M','D'},
        new List<char>() {'R','G','C','D'},
        new List<char>() {'H','G','T','R','J','D','S','Q'},
        new List<char>() {'P','F','V'},
        new List<char>() {'D','R','S','T','J'}
    };
    public static void Setup()
    {
        var commands = 
            JsonSerializer.Deserialize<List<List<int>>>(Input.JsonString);

        foreach (var command in commands)
        {
            ExecuteCommand(command[0],command[1],command[2]);
        }

        string TopStackString = null;
        foreach (var vCrate in Crates)
        {
            TopStackString += vCrate[^1];
        }
        Console.WriteLine($"{TopStackString}");
    }

    public static void ExecuteCommand(int move, int from, int to)
    {
        for (var i = 0; i < move; i++)
        {
            Crates[to-1].Add(Crates[from-1][Crates[from-1].Count-move+i]);
            Crates[from-1].RemoveAt(Crates[from-1].Count-move+i);
        }
    }
}