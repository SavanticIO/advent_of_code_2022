using System.Text.Json;

namespace AOC.Day04;

public class Day04
{
    public static void Setup()
    {
        var assignmentPair = 
            JsonSerializer.Deserialize<List<List<List<int>>>>(Input.JsonString);

        foreach (var pair in assignmentPair)
        {
            var assignmentOne = AssignmentManager.RegisterAssignment(pair[0]);
            var assignmentTwo = AssignmentManager.RegisterAssignment(pair[1]);
            AssignmentManager.RegisterAssignmentPair(assignmentOne,assignmentTwo);
        }
        
        var withinCount = 0;
        var overlapCount = 0;
        foreach (var pair in AssignmentManager.AllAssignmentPairs)
        {
            if (pair.IsAnAssignmentWithinAnother) withinCount++;
            if (pair.IsOverlap) overlapCount++;
        }
        Console.WriteLine($"{withinCount}");
        Console.WriteLine($"{overlapCount}");
    }
}