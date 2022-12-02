namespace AOC.Day02;

public static class GameManager
{
    private static readonly List<Game> AllGames = new();
    public static int OpponentTotalScorePart1;
    public static int MyTotalScorePart1;
    public static int OpponentTotalScorePart2;
    public static int MyTotalScorePart2;
    
    public static void Register(List<string> actions)
    {
        var game = new Game(actions);
        AllGames.Add(game);
        MyTotalScorePart1 += game.Part1MyScore;
        OpponentTotalScorePart1 += game.Part1OpponentScore;
        MyTotalScorePart2 += game.Part2MyScore;
        OpponentTotalScorePart2 += game.Part2OpponentScore;
    }
}

public class Game
{
    private static readonly Dictionary<string, string> ActionsMap = new()
    {
        { "A", "Rock" },
        { "B", "Paper" },
        { "C", "Scissors" },
        { "X", "Rock" },
        { "Y", "Paper" },
        { "Z", "Scissors" },

    };

    private static readonly Dictionary<string, int> PointsMap = new()
    {
        { "Rock", 1 },
        { "Paper", 2 },
        { "Scissors", 3 }
    };

    private static readonly Dictionary<string, int> OutcomeMap = new()
    {
        { "Win", 6 },
        { "Draw", 3 },
        { "Loss", 0 }
    };

    private static readonly Dictionary<string, string> StrategyMap = new()
    {
        { "X", "Loss" },
        { "Y", "Draw" },
        { "Z", "Win" }
    };

    public readonly int Part1OpponentScore;
    public readonly int Part1MyScore;
    public readonly int Part2OpponentScore;
    public readonly int Part2MyScore;

    public Game(List<string> actions)
    {
        var opponentPlayed = ActionsMap[actions[0]];
        var iPlayed = ActionsMap[actions[1]];
        Part1OpponentScore += PointsMap[opponentPlayed];
        Part1MyScore += PointsMap[iPlayed];
        
        var part1Outcome = GetOutCome(opponentPlayed, iPlayed);
        switch (part1Outcome)
        {
            case "Win":
                Part1MyScore += OutcomeMap[part1Outcome];
                Part1OpponentScore += OutcomeMap["Loss"];
                break;
            case "Draw":
                Part1MyScore += OutcomeMap[part1Outcome];
                Part1OpponentScore += OutcomeMap[part1Outcome];
                break;
            case "Loss":
                Part1MyScore += OutcomeMap[part1Outcome];
                Part1OpponentScore += OutcomeMap["Win"];
                break;
        }

        var part2Outcome = StrategyMap[actions[1]];
        
        switch (part2Outcome)
        {
            case "Win":
                Part2OpponentScore += PointsMap[opponentPlayed];
                Part2MyScore += PointsMap[GetWin(opponentPlayed)];
                Part2MyScore += OutcomeMap[part2Outcome];
                Part2OpponentScore += OutcomeMap["Loss"];
                break;
            case "Draw":
                Part2OpponentScore += PointsMap[opponentPlayed];
                Part2MyScore += PointsMap[opponentPlayed];
                Part2MyScore += OutcomeMap[part2Outcome];
                Part2OpponentScore += OutcomeMap[part2Outcome];
                break;
            case "Loss":
                Part2OpponentScore += PointsMap[opponentPlayed];
                Part2MyScore += PointsMap[GetLoss(opponentPlayed)];
                Part2MyScore += OutcomeMap[part2Outcome];
                Part2OpponentScore += OutcomeMap["Win"];
                break;
        }
    }

    private string? GetOutCome(string? opponent, string? me)
    {
        var outcome = me switch
        {
            "Rock" => opponent switch
            {
                "Paper" => "Loss",
                "Scissors" => "Win",
                _ => "Draw"
            },
            "Paper" => opponent switch
            {
                "Scissors" => "Loss",
                "Rock" => "Win",
                _ => "Draw"
            },
            "Scissors" => opponent switch
            {
                "Rock" => "Loss",
                "Paper" => "Win",
                _ => "Draw"
            },
            _ => null
        };

        return outcome;
    }

    private string? GetWin(string? opponent)
    {
        var outcome = opponent switch
        {
            "Rock" => "Paper",
            "Paper" => "Scissors",
            "Scissors" => "Rock",
            _ => null
        };

        return outcome;
    }

    private string? GetLoss(string? opponent)
    {
        var outcome = opponent switch
        {
            "Rock" => "Scissors",
            "Paper" => "Rock",
            "Scissors" => "Paper",
            _ => null
        };

        return outcome;
    }
}