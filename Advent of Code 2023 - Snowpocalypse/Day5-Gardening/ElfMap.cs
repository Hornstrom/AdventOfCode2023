namespace Advent_of_Code_2023___Snowpocalypse.Day5_Gardening;

public class ElfMap
{
    public string Title;
    public List<ElfRange> Ranges = new List<ElfRange>();

    public long Map(long source)
    {
        foreach (var range in Ranges)
        {
            if (range.InRange(source))
            {
                return range.Map(source);
            }
        }
        return source;
    }
}