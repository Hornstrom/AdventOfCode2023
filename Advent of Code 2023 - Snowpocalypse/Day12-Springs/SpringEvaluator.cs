namespace Advent_of_Code_2023___Snowpocalypse.Day12_Gears;

public class SpringEvaluator
{
    public List<SpringLine> SpringLines = new List<SpringLine>();

    public SpringEvaluator(string[] lines)
    {
        foreach (var line in lines)
        {
            SpringLines.Add(new SpringLine(line));
        }
    }

    public void CalculateAndOutputArrangements()
    {
        Console.WriteLine("Part 1");
        foreach (var spring in SpringLines)
        {
            Console.WriteLine($"{spring.Line} - {CalculateArrangements(spring)} arrangement(s)");
        }
    }

    private int CalculateArrangements(SpringLine springLine)
    {
        return 0;
    }
}