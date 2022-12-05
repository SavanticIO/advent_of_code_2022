using System.Diagnostics;
using System.Text.Json;
using System.Diagnostics;
using System.Text.Json;

namespace AOC.Day03;

public class Day03
{
    public static void Setup()
    {
        var containers = 
            JsonSerializer.Deserialize<List<string>>(Input.JsonString);
        var count = 0;
        var tempContainerGroup = new List<Container>();
        foreach (var container in containers)
        {
            ContainerManager.RegisterContainer(container);
        }

        foreach (var cont in ContainerManager.AllContainers)
        {
            count++;
            tempContainerGroup.Add(cont);
            if (count != 3) continue;
            count = 0;
            ContainerManager.RegisterContainerGroup(tempContainerGroup);
        }

        var check = ContainerManager.AllContainerGroups;
        Console.WriteLine($"Container Priorities Sum: {ContainerManager.CalculatePrioritiesSum(ContainerManager.ContainersBySharedItemType)}");
        Console.WriteLine($"ContainerGroup Priorities Sum: {ContainerManager.CalculatePrioritiesSum(ContainerManager.ContainerGroupsBySharedItemType)}");
    }

    
}