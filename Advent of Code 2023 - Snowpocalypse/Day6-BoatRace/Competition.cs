using System.Text.RegularExpressions;

namespace Advent_of_Code_2023___Snowpocalypse.Day6_BoatRace;

public class Competition
{
    private List<BoatRace> _boatRaces = new List<BoatRace>();
    public static Regex AnyDigit = new Regex("\\d+");

    public Competition(string[] lines)
    {
        var times = AnyDigit.Matches(lines[0]).Select(m => long.Parse(m.Value)).ToList();
        var distances = AnyDigit.Matches(lines[1]).Select(m => long.Parse(m.Value)).ToList();

        for (int i = 0; i < times.Count; i++)
        {
            _boatRaces.Add(new BoatRace(times[i], distances[i]));
        }
    }

    public int NumberOfWaysToBeatFactor()
    {
        var beat = 1;
        foreach (var boatRace in _boatRaces)
        {
            beat = beat * boatRace.RecordBreakingTU.Count;
        }

        return beat;
    }
}