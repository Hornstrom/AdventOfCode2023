namespace Advent_of_Code_2023___Snowpocalypse.Day13_Mirrors;

public class LavaField
{
    public List<Mirror> Mirrors = new List<Mirror>();

    public LavaField(string[] lines)
    {
        var lastMirror = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i] == "" || i == lines.Length - 1)
            {
                Mirrors.Add(new Mirror(lines.Skip(lastMirror).Take(i - lastMirror).ToArray()));
                lastMirror = i + 1;
            }
        }
    }

    public long Part1()
    {
        long result = 0;
        foreach (var mirror in Mirrors)
        {
            result += mirror.ReflectionInColumn + 100 * mirror.ReflectionInRow;
        }

        return result;
    }
}
