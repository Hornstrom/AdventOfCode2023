using System.Text.RegularExpressions;

namespace Advent_of_Code_2023___Snowpocalypse.Day5_Gardening;

public class AlmanacPart2
{
    public List<ElfMap> ElfMaps = new List<ElfMap>();
    public List<long> Seeds;
    public static Regex AnyDigit = new Regex("\\d+");
    public long MinLocation = long.MaxValue;

    public AlmanacPart2(string[] lines)
    {
        // Parse seed string
        var seedSetup = AnyDigit.Matches(lines[0]).Select(m => long.Parse(m.Value)).ToList();
        
        // Create all ze maps
        for (int i = 1; i < lines.Length; i++)
        {
            if (lines[i] == "")
            {
                continue;
            }

            if (lines[i].Contains(":"))
            {
                var elfMap = new ElfMap();
                elfMap.Title = lines[i];
                ElfMaps.Add(elfMap);
            }
            else
            {
                ElfMaps.Last().Ranges.Add(new ElfRange(lines[i]));
            }
        }

        for (int i = 0; i < seedSetup.Count; i = i + 2)
        {
            var seedStart = seedSetup[i];
            var seedEnd = seedStart + seedSetup[i + 1];
            for (long j = seedStart; j < seedEnd; j++)
            {
                var location = SeedToLocation(j);
                if (location < MinLocation)
                {
                    MinLocation = location;
                }
            }
        }
    }

    public long SeedToLocation(long seed)
    {
        var foo = seed;
        foreach (var map in ElfMaps)
        {
            foo = map.Map(foo);
        }
        
        return foo;
    }
}