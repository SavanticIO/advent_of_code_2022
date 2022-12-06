namespace AOC.Day06;

public class Day06
{
    public static void Setup()
    {
        var charList = Input.InputString.ToList();
        var count = 0;
        for (var i = 0; i < charList.Count; i++)
        {
            var tempList = new List<char>
            {
                charList[i],
                charList[i + 1],
                charList[i + 2],
                charList[i + 3],
                charList[i + 4],
                charList[i + 5],
                charList[i + 6],
                charList[i + 7],
                charList[i + 8],
                charList[i + 9],
                charList[i + 10],
                charList[i + 11],
                charList[i + 12],
                charList[i + 13]
            };
            var tempHastSet = new HashSet<char>();
            foreach (var t in tempList)
            {
                var uniqueList = tempHastSet.Add(t);
                if (!uniqueList || tempHastSet.Count != 14) continue;
                count = i + 14;
                break;
            }
            if (count > 0) break;
        }
        Console.WriteLine($"{count}");
    }
}