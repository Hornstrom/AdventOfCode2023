namespace Advent_of_Code_2023___Snowpocalypse.Day10_PipeMaze;

public class PipeMaze
{
    public Pipe[,] Pipes;
    private int xStart;
    private int yStart;
    
    public PipeMaze(string[] lines)
    {
        var xLength = lines[0].Length;
        var yLength = lines.Length;
        Pipes = new Pipe[xLength,yLength];

        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < yLength; y++)
            {
                var pipeSymbol = lines[y].ElementAt(x);
                Pipes[x, y] = new Pipe(x, y, pipeSymbol);
                if (pipeSymbol == 'S')
                {
                    xStart = x;
                    yStart = y;
                }
            }
        }
    }

    public int NavigateMaze()
    {
        var x = xStart;
        var y = yStart;
        var xMax = Pipes.GetLength(0);
        var yMax = Pipes.GetLength(1);
        var numberOfSteps = 0;
        var shouldRun = true;

        while (shouldRun)
        {
            shouldRun = false;
            if (x + 1 < xMax && Pipes[x, y].EastConnection && Pipes[x + 1, y].WestConnection && !Pipes[x + 1, y].Visited)
            {
                Pipes[x + 1, y].Visited = true;
                numberOfSteps++;
                shouldRun = true;
                //What pipes do we have to our right?
                if (y + 1 < yMax)
                {
                    Pipes[x, y + 1].OnRightSide = true;
                    Pipes[x + 1, y + 1].OnRightSide = true;
                }
                x += 1;
            }

            if (x - 1 >= 0 && Pipes[x, y].WestConnection && Pipes[x - 1, y].EastConnection && !Pipes[x - 1, y].Visited)
            {
                Pipes[x - 1, y].Visited = true;
                numberOfSteps++;
                shouldRun = true;
                //What pipes do we have to our right?
                if (y - 1 >= 0)
                {
                    Pipes[x, y - 1].OnRightSide = true;
                    Pipes[x - 1, y - 1].OnRightSide = true;
                }
                x -= 1;
            }
            
            if (y + 1 < yMax && Pipes[x, y].SouthConnection && Pipes[x, y + 1].NorthConnection && !Pipes[x, y + 1].Visited)
            {
                Pipes[x, y + 1].Visited = true;
                numberOfSteps++;
                shouldRun = true;
                //What pipes do we have to our right?
                if (x - 1 >= 0)
                {
                    Pipes[x - 1, y].OnRightSide = true;
                    Pipes[x - 1, y + 1].OnRightSide = true;
                }
                y += 1;
            }
            
            if (y - 1 >= 0 && Pipes[x, y].NorthConnection && Pipes[x, y - 1].SouthConnection && !Pipes[x, y - 1].Visited)
            {
                Pipes[x, y - 1].Visited = true;
                numberOfSteps++;
                shouldRun = true;
                //What pipes do we have to our right?
                if (x + 1 < xMax)
                {
                    Pipes[x + 1, y].OnRightSide = true;
                    Pipes[x + 1, y - 1].OnRightSide = true;
                }
                y -= 1;
            }
            // PrintMaze(numberOfSteps);
        }

        numberOfSteps = (numberOfSteps + 1) / 2;
        PrintMaze(numberOfSteps);

        return numberOfSteps;
    }

    private void PrintMaze(int steps)
    {
        Console.WriteLine($"Number of steps: {steps}");
        for (int y = 0; y < Pipes.GetLength(1); y++)
        {
            for (int x = 0; x < Pipes.GetLength(0); x++)
            {
                if (Pipes[x, y].Visited)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    if (Pipes[x,y].OnRightSide)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                }
                Console.Write(Pipes[x, y].PipeSymbol);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
        }
        
    }
}