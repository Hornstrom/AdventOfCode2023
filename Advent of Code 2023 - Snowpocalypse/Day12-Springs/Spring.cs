namespace Advent_of_Code_2023___Snowpocalypse.Day12_Gears;

public class Spring
{
    public char StartingChar;
    public bool? Working;
    public bool Unknown;
    public Spring(char startingChar)
    {
        StartingChar = startingChar;
        if (startingChar.Equals('.'))
        {
            Working = true;
        }
        if (startingChar.Equals('#'))
        {
            Working = false;
        }
        if (startingChar.Equals('#'))
        {
            Unknown = true;
        }
    }
}