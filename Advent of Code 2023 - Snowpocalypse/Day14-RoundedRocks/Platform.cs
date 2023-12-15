namespace Advent_of_Code_2023___Snowpocalypse.Day14_RoundedRocks;

public class Platform
{
    public char[,] Layout;

    public Platform(string[] lines)
    {
        Layout = new char[lines[0].Length,lines.Length];
        for (int y = 0; y < lines.Length; y++)
        {
            var lineArray = lines[y].ToCharArray();
            for (int x = 0; x < lineArray.Length; x++)
            {
                Layout[x, y] = lineArray[x];
            }
        }
    }

    public void TipNorth()
    {
        while (true)
        {
            for (int y = 0; y < Layout.GetLength(1); y++)
            {
                
            }
        }
    }
}