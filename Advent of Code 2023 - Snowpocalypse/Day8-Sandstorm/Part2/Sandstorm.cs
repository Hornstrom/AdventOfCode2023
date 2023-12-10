using System.Numerics;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2023___Snowpocalypse.Day8_Sandstorm.Part2;

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

    public long FindPath()
    {
        var positions = Coordinates.Where(c => c.Key.EndsWith('A')).Select(c => c.Key).ToArray();
        var finished = new bool[positions.Count()];
        var endLocationsWithSteps = new List<Tuple<string, long>>[positions.Count()]; 
        long numberOfSteps = 0;
        Console.WriteLine($"At {positions[0]} {positions[1]}, number of steps {numberOfSteps}");
        while (numberOfSteps < Int32.MaxValue && !finished.All(c => c))
        {
            foreach (var direction in Directions)
            {
                numberOfSteps++;
                for (int i = 0; i < positions.Count(); i++)
                {
                    var location = Coordinates.First(c => c.Key == positions[i]);
                    if (direction == 'L')
                    {
                        positions[i] = location.Value.Item1;
                    }
                    else if (direction == 'R')
                    {
                        positions[i] = location.Value.Item2;
                    }
                    else
                    {
                        throw new Exception("Lost in the sandstorm");
                    }

                    if (positions[i].EndsWith('Z'))
                    {
                        finished[i] = true;
                        if (endLocationsWithSteps[i] == null)
                        {
                            endLocationsWithSteps[i] = new List<Tuple<string, long>>();
                        }
                        endLocationsWithSteps[i].Add(new Tuple<string, long>(positions[i], numberOfSteps));
                    }
                    else
                    {
                        finished[i] = false;
                    }

                    if (endLocationsWithSteps.All(l => l != null && l.Count > 0))
                    {
                        var stepsToEnd = new long[positions.Count()];
                        var steps = new long[positions.Count()];
                        long rawResult = 1;
                        for (int j = 0; j < positions.Count(); j++)
                        {
                            stepsToEnd[j] = endLocationsWithSteps[j].ElementAt(0).Item2;
                            steps[j] = endLocationsWithSteps[j].ElementAt(0).Item2;
                            rawResult = DetermineLCM(rawResult, steps[j]);
                        }

                        return rawResult;

                        // var potentialEnd = steps.Max();
                        // while (!steps.All(s => s == potentialEnd))
                        // {
                        //     for (int j = 0; j < steps.Length; j++)
                        //     {
                        //         if (steps[j] < potentialEnd)
                        //         {
                        //             steps[j] += stepsToEnd[j];
                        //             potentialEnd = steps[j];
                        //         }
                        //     }
                        // }
                        //
                        // return potentialEnd;
                    }
                }
                // Console.WriteLine($"At {positions[0]} {positions[1]}, number of steps {numberOfSteps}");
            }    
        }

        return numberOfSteps;
    }
    
    public static long DetermineLCM(long a, long b)
    {
        long num1, num2;
        if (a > b)
        {
            num1 = a; num2 = b;
        }
        else
        {
            num1 = b; num2 = a;
        }

        for (var i = 1; i < num2; i++)
        {
            long mult = num1 * i;
            if (mult % num2 == 0)
            {
                return mult;
            }
        }
        return num1 * num2;
    }
    
}