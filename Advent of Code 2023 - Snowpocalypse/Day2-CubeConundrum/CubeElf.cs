using System.Reflection.PortableExecutable;

namespace Advent_of_Code_2023___Snowpocalypse.Day2_CubeConundrum;

public class CubeElf
{
    public List<Game> Games = new List<Game>();
    
    public CubeElf(string[] games)
    {
        foreach (var game in games)
        {
            Games.Add(new Game(game));
        }
    }

    public int SumValidGames()
    {
        return Games.Where(g => g.GamePossible()).Sum(g => g.GameId);
    }
    
    public int SumGamePower()
    {
        return Games.Sum(g => g.GamePower());
    }
}
