namespace AOC.Day01;

public class ElfManager
{
    public static readonly List<Elf> AllElves = new();
    public static readonly List<int> AllTotalCalories = new();
    public static int HighestBerryCount;
    public static int LowestBerryCount;
    public static int HighestTotalCalories;
    public static int HighestCalories;
    public static int LowestCalories;
    
    public static void Register(List<int> berries)
    {
        var elf = new Elf(berries);
        AllTotalCalories.Add(elf.TotalCalories);
        AllElves.Add(elf);
        if (elf.BerryCount > HighestBerryCount)
        {
            HighestBerryCount = elf.BerryCount;
        }

        if (elf.BerryCount < LowestBerryCount)
        {
            LowestBerryCount = elf.BerryCount;
        }
        
        HighestTotalCalories = AllTotalCalories.Max();
        
        if (elf.HighestCalories > HighestCalories)
        {
            HighestCalories = elf.HighestCalories;
        }
        
        if (elf.LowestCalories < LowestCalories)
        {
            LowestCalories = elf.LowestCalories;
        }
    }
}

public class Elf
{
    List<int> _berries;
    public int BerryCount;
    public int TotalCalories;
    public int HighestCalories;
    public int LowestCalories;
    
    public Elf(List<int> berries)
    {
        _berries = berries;
        BerryCount = _berries.Count;
        TotalCalories = _berries.Sum();
        HighestCalories = _berries.Max();
        LowestCalories = _berries.Min();
    }
}