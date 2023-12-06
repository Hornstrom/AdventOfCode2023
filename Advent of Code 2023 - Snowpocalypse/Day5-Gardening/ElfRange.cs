using System.Data;

namespace Advent_of_Code_2023___Snowpocalypse.Day5_Gardening;

public class ElfRange
{
    public long Source;
    public long Destination;
    public long NumberOfSteps;

    public ElfRange(string line)
    {
        var values = line.Split(" ");
        Destination = long.Parse(values[0]);
        Source = long.Parse(values[1]);
        NumberOfSteps = long.Parse(values[2]);
    }

    public bool InRange(long value)
    {
        return value >= Source && value < Source + NumberOfSteps;
    }

    public long Map(long value)
    {
        if (!InRange(value))
        {
            throw new Exception("Not supposed to map");
        }

        //return Destination + Source - value;
        return value + Destination - Source;
    }
}