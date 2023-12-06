using System.Text.RegularExpressions;

namespace Advent_of_Code_2023___Snowpocalypse.Day5_Gardening;

public class Almanac
{
    public List<ElfMap> ElfMaps = new List<ElfMap>();
    public List<long> Seeds;
    public static Regex AnyDigit = new Regex("\\d+");

    public Almanac(string[] lines)
    {
        Seeds = AnyDigit.Matches(lines[0]).Select(m => long.Parse(m.Value)).ToList();
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
    }

    public long SeedToMinLocation()
    {
        var locations = new List<long>();
        foreach (var seed in Seeds)
        {
            Console.WriteLine($"Starting mapping for seed {seed}");
            var foo = seed;
            foreach (var map in ElfMaps)
            {
                foo = map.Map(foo);
                Console.WriteLine($"{map.Title} {foo}");
            }
            locations.Add(foo);
            Console.WriteLine("");
        }

        return locations.Min();
    }
}