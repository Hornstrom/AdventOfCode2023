namespace Advent_of_Code_2023___Snowpocalypse.Day12_Gears;

public class SpringLine
{
    public string RawString;
    public int[] DamageSpringGroups;
    public string Line;
    public Spring[] Springs;
    

    public SpringLine(string rawString)
    {
        RawString = rawString;
        var rawSplit = RawString.Split(" ");
        Line = rawSplit[0];
        Springs = new Spring[Line.Length];
        for (int i = 0; i < Line.Length; i++)
        {
            Springs[i] = new Spring(Line.ElementAt(i));
        }
        DamageSpringGroups = rawSplit[1].Split(",").Select(int.Parse).ToArray();
    }

    public int NumberOfArrangements()
    {
        // pair em fuckers up
        return 1;
    }
}