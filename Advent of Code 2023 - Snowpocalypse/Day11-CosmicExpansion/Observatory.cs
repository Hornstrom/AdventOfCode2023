namespace Advent_of_Code_2023___Snowpocalypse.Day11_CosmicExpansion;

public class Observatory
{
    private List<string> _map = new List<string>();

    public Observatory(string[] lines)
    {
        var offset = 0;
        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            _map.Add(line);
            if (!line.Contains('#'))
            {
                offset++;
                _map.Add(line);
                // Print(null, y + offset);
            }
        }

        var yMax = _map.Count;
        string[] tempStringArray = new string[yMax];
        tempStringArray = _map.ToArray();
        var insertOffset = 0;
        for (int x = 0; x < lines[0].Length; x++)
        {
            var allAreDots = true;
            for (var y = 0; y < yMax; y++)
            {
                var line = _map.ElementAt(y);
                if (line.ElementAt(x).Equals('#'))
                {
                    allAreDots = false;
                }
            }

            if (allAreDots)
            {
                for (int y = 0; y < yMax; y++)
                {
                    var newLine = tempStringArray[y].Insert(x + insertOffset + 1, ".");
                    tempStringArray[y] = newLine;
                }
                Console.WriteLine($"found empty column at {x} insert at {x + insertOffset + 1}");
                insertOffset++;
                // Print(x + insertOffset, null);
            }
            
        }

        _map = tempStringArray.ToList();
        // Print(null, null);
    }

    public void Print(int? xHighlight, int? yHighlight)
    {
        for (var y = 0; y < _map.Count; y++)
        {
            var line = _map[y];
            if (yHighlight.HasValue && y == yHighlight.Value)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }

            if (xHighlight.HasValue)
            {
                Console.Write(line.Substring(0, xHighlight.Value));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(line.Substring(xHighlight.Value, 1));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(line.Substring(xHighlight.Value + 1));
            }
            else
            {
                Console.WriteLine(line);    
            }
            
            Console.ForegroundColor = ConsoleColor.White;
        }

        Console.WriteLine();
    }

    public long GalaxyDistanceSum()
    {
        long sum = 0;
        var numberOfGalaxiesFound = 0;

        for (int y = 0; y < _map.Count; y++)
        {
            for (int x = 0; x < _map.ElementAt(y).Length; x++)
            {
                if(_map.ElementAt(y)[x].Equals('#'))
                {
                    numberOfGalaxiesFound++;
                    var numberOfGalaxiesMatchedAgainst = 0;
                    var firstRun = true;
                    // Measure distance to all galaxies after
                    for (int y2 = y; y2 < _map.Count; y2++)
                    {
                        for (int x2 = 0; x2 < _map.ElementAt(y2).Length; x2++)
                        {
                            if (firstRun && x + 1 >= _map.ElementAt(y2).Length)
                            {
                                firstRun = false;
                                continue;
                            }
                            if (y == y2 && firstRun)
                            {
                                x2 = x + 1;
                            }

                            firstRun = false;

                            if (_map.ElementAt(y2)[x2].Equals('#'))
                            {
                                numberOfGalaxiesMatchedAgainst++;
                                var distance = Math.Abs(x2 - x) + Math.Abs(y2 - y); 
                                sum += distance;
                                // Console.WriteLine($"Distance between galaxy {numberOfGalaxiesFound} and galaxy {numberOfGalaxiesFound + numberOfGalaxiesMatchedAgainst} is {distance}");
                            }
                        }
                    }
                }
                
            }
        }

        return sum;
    }
}