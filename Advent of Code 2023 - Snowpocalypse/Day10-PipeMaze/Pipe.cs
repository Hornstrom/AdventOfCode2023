namespace Advent_of_Code_2023___Snowpocalypse.Day10_PipeMaze;

public class Pipe
{
    public bool NorthConnection;
    public bool EastConnection;
    public bool SouthConnection;
    public bool WestConnection;
    public bool Visited;
    public char PipeSymbol;
    public int X;
    public int Y;
    public bool OnRightSide;
    public bool OnLeftSide;

    public Pipe(int x, int y, char pipeSymbol)
    {
        X = x;
        Y = y;
        PipeSymbol = pipeSymbol;

        switch (pipeSymbol)
        {
            case '|':
                NorthConnection = true;
                SouthConnection = true;
                break;
            case '-':
                EastConnection = true;
                WestConnection = true;
                break;
            case 'L':
                NorthConnection = true;
                EastConnection = true;
                break;
            case 'J':
                NorthConnection = true;
                WestConnection = true;
                break;
            case '7':
                SouthConnection = true;
                WestConnection = true;
                break;
            case 'F':
                SouthConnection = true;
                EastConnection = true;
                break;
            case 'S':
                NorthConnection = true;
                EastConnection = true;
                SouthConnection = true;
                WestConnection = true;
                Visited = true;
                break;
        }
    }


}