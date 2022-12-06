namespace AOC.Day04;

public class AssignmentManager
{
    public static readonly List<Assignment> AllAssignments = new();
    public static readonly List<AssignmentPair> AllAssignmentPairs = new();
    
    public static void RegisterAssignmentPair(Assignment one, Assignment two)
    {
        var pair = new AssignmentPair(one,two);
        AllAssignmentPairs.Add(pair);
    }
    
    public static Assignment RegisterAssignment(List<int> range)
    {
        var assignment = new Assignment(range);
        AllAssignments.Add(assignment);
        return assignment;
    }
}

public class AssignmentPair
{
    public Assignment AssignmentOne;
    public Assignment AssignmentTwo;
    public bool IsAnAssignmentWithinAnother;
    public bool IsOverlap;
    public AssignmentPair(Assignment one, Assignment two)
    {
        AssignmentOne = one;
        AssignmentTwo = two;
        IsAnAssignmentWithinAnother = CheckIfAssignmentIsWithinAnother();
        IsOverlap = CheckIfOverlap();
    }

    private bool CheckIfAssignmentIsWithinAnother()
    {
        bool result = AssignmentOne.AssignedSections[0] <= AssignmentTwo.AssignedSections[0] && AssignmentOne.AssignedSections[1] >= AssignmentTwo.AssignedSections[1] || AssignmentTwo.AssignedSections[0] <= AssignmentOne.AssignedSections[0] && AssignmentTwo.AssignedSections[1] >= AssignmentOne.AssignedSections[1];
        return result;
    }
    
    private bool CheckIfOverlap()
    {
        var result = false;
        if ((AssignmentOne.AssignedSections[0] <= AssignmentTwo.AssignedSections[0] && AssignmentOne.AssignedSections[1] >= AssignmentTwo.AssignedSections[0]) || (AssignmentOne.AssignedSections[0] <= AssignmentTwo.AssignedSections[1] && AssignmentOne.AssignedSections[1] >= AssignmentTwo.AssignedSections[1]))
        {
            result = true;
        }
        if ((AssignmentTwo.AssignedSections[0] <= AssignmentOne.AssignedSections[0] && AssignmentTwo.AssignedSections[1] >= AssignmentOne.AssignedSections[0]) || (AssignmentTwo.AssignedSections[0] <= AssignmentOne.AssignedSections[1] && AssignmentTwo.AssignedSections[1] >= AssignmentOne.AssignedSections[1]))
        {
            result = true;
        }
        return result;
    }
}

public class Assignment
{
    public List<int> AssignedSections;
    public Assignment(List<int> range)
    {
        AssignedSections = range;
    }
}