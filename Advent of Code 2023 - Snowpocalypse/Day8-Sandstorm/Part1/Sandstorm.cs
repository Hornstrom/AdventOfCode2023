using System.Text.RegularExpressions;

namespace Advent_of_Code_2023___Snowpocalypse.Day8_Sandstorm.Part1;

public class Sandstorm
{
    public char[] Directions;
    public Dictionary<string, Tuple<string, string>> Coordinates;
    public static Regex AnyWord = new Regex("\\w+");
    
    public Sandstorm(string[] lines)
    {
        Directions = lines[0].ToCharArray();
        Coordinates = new Dictionary<string, Tuple<string, string>>();

        for (int i = 2; i < lines.Length; i++)
        {
            var matches = AnyWord.Matches(lines[i]);
            Coordinates.Add(matches[0].Value, new Tuple<string, string>(matches[1].Value, matches[2].Value));
        }
    }

    public int FindPath()
    {
        var position = "AAA";
        var numberOfSteps = 0;
        // Console.WriteLine($"At {position}, number of steps {numberOfSteps}");
        while (numberOfSteps < Int32.MaxValue)
        {
            foreach (var direction in Directions)
            {
                numberOfSteps++;
                var location = Coordinates.First(c => c.Key == position);
                if (direction == 'L')
                {
                    position = location.Value.Item1;
                }
                else if (direction == 'R')
                {
                    position = location.Value.Item2;
                }
                else
                {
                    throw new Exception("Lost in the sandstorm");
                }
                
                // Console.WriteLine($"At {position}, number of steps {numberOfSteps}");

                if (position == "ZZZ")
                {
                    return numberOfSteps;
                }
            }    
        }
        throw new Exception("Lost in the sandstorm");
    }
    
}