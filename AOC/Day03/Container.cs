namespace AOC.Day03;

public class ContainerManager
{
    private const string PrioritiesString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static readonly Dictionary<char, int> PrioritiesMap = new();

    public static readonly List<Container> AllContainers = new();
    public static readonly List<ContainerGroup> AllContainerGroups = new();
    public static readonly Dictionary<char, List<Container>> ContainersBySharedItemType = new();
    public static readonly Dictionary<char, List<ContainerGroup>> ContainerGroupsBySharedItemType = new();

    static ContainerManager()
    {
        foreach (var c in PrioritiesString)
        {
            PrioritiesMap[c] = PrioritiesString.IndexOf(c) + 1;
        }
    }
    
    public static int CalculatePrioritiesSum<T>(Dictionary<char, List<T>> sharedItemType)
    {
        var sum = 0;
        foreach (var itemType in sharedItemType)
        {
            sum += itemType.Value.Count * PrioritiesMap[itemType.Key];
        }

        return sum;
    }
    public static void RegisterContainer(string items)
    {
        var container = new Container(items);
        AllContainers.Add(container);
        if (!container.IsItemTypeShared) return;
        if (ContainersBySharedItemType.ContainsKey(container.SharedItemType))
        {
            ContainersBySharedItemType[container.SharedItemType].Add(container);
        }
        else
        {
            ContainersBySharedItemType[container.SharedItemType] = new List<Container> { container };
        }
    }
    
    public static void RegisterContainerGroup(List<Container> containers)
    {
        var containerGroup = new ContainerGroup(containers);
        AllContainerGroups.Add(containerGroup);
        if (ContainerGroupsBySharedItemType.ContainsKey(containerGroup.SharedItemType))
        {
            ContainerGroupsBySharedItemType[containerGroup.SharedItemType].Add(containerGroup);
        }
        else
        {
            ContainerGroupsBySharedItemType[containerGroup.SharedItemType] = new List<ContainerGroup> { containerGroup };
        }
    }
}

public class ContainerGroup
{
    private readonly List<Container> _containers;
    public readonly char SharedItemType;
    
    public ContainerGroup(List<Container> containers)
    {
        _containers = containers;
        SharedItemType = GetSharedItemType();
    }

    public char GetSharedItemType()
    {
        var prim = new bool[52];
        var itemType = '\0';

        for (var i = 0; i < prim.Length; i++)
        {
            prim[i] = true;
        }

        foreach (var container in _containers)
        {
            var sec = new bool[52];
            for (var i = 0; i < sec.Length; i++)
            {
                sec[i] = false;
            }

            foreach (var c in container.AllItems)
            {
                if (c+26 - 'A' >= 0 && c+26 - 'A' <= prim.Length && prim[c - 'A'])
                {
                    sec[c - 'A'] = true;
                }
                if (c - 'a' >= 0 && c - 'a' <= prim.Length && prim[c - 'a'])
                {
                    sec[c - 'a'] = true;
                }
            }

            Array.Copy(sec, 0, prim, 0, 52);

            for (var i = 0; i < prim.Length; i++)
            {
                if (prim[i])
                {
                    if (i < 27)
                    {
                        itemType = (char)(i + 97);
                    }
                    else
                    {
                        itemType = (char)(i + 65);
                    }

                }
            }
        }
        return itemType;
    }
}

    public class Container
{
    public readonly string AllItems;
    public readonly string CompartmentOne;
    public readonly string CompartmentTwo;
    public readonly char SharedItemType;
    public bool IsItemTypeShared;
    
    
    public Container(string items)
    {
        AllItems = items;
        CompartmentOne = items[..(items.Length/2)];
        CompartmentTwo = items.Substring((int)(items.Length / 2), (int)(items.Length / 2));
        IsItemTypeShared = false;
        SharedItemType = GetSharedItemType();
    }

    public char GetSharedItemType()
    {
        var itemType = '\0';
        foreach(var itemOne in CompartmentOne){
            foreach (var itemTwo in CompartmentTwo)
            {
                if (itemOne != itemTwo) continue;
                itemType = itemOne;
                IsItemTypeShared = true;
                break;
            }
        }

        return itemType;
    }
}