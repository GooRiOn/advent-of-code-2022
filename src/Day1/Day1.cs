using AdventOfCode2022;

public class Day1 : IAdventOfCodeDay
{
    public async Task ExecuteAsync()
    {
        var accumulator = 0;
        var calories = new List<int>();
        
        await foreach (var line in File.ReadLinesAsync("./Day1/day1.txt"))
        {
            if (string.IsNullOrEmpty(line))
            {
                calories.Add(accumulator);
                accumulator = 0;
                continue;
            }

            accumulator += ((IConvertible) line).ToInt32(default);
        }

        var maxCalories = calories.Max();
        var totalCaloriesOfThreeElves = calories.OrderDescending().Take(3).Sum();

        Console.WriteLine(maxCalories);
        Console.WriteLine(totalCaloriesOfThreeElves);
    }
}
