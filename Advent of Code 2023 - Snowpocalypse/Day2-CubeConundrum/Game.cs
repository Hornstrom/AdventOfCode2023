using System.Text.RegularExpressions;

namespace Advent_of_Code_2023___Snowpocalypse.Day2_CubeConundrum;

public class Game
{
    private const int MaxRedCubes = 12; 
    private const int MaxGreenCubes = 13; 
    private const int MaxBlueCubes = 14;
    public int GameId;
    private List<Round> Rounds = new List<Round>();
    public static Regex AnyDigit = new Regex("\\d+");
    
    
    public Game(string line)
    {
        var gameAndRounds = line.Split(":");
        var gameId = AnyDigit.Match(gameAndRounds[0]);
        GameId = int.Parse(gameId.Value);

        var gameRounds = gameAndRounds[1].Split(";");
        foreach (var gameRound in gameRounds)
        {
            Rounds.Add(new Round(gameRound));
        }
    }

    public bool GamePossible()
    {
        return Rounds.All(r => r.GameRoundPossible());
    }

    public int GamePower()
    {
        return Rounds.Max(r => r.RedCubes) * Rounds.Max(r => r.BlueCubes) * Rounds.Max(r => r.GreenCubes);
    }

    private class Round
    {
        public readonly int RedCubes;
        public readonly int GreenCubes;
        public readonly int BlueCubes;
        
        public Round(string line)
        {
            var redRegex = new Regex("\\d+ red");
            var redMatches = redRegex.Matches(line);
            if (redMatches.Any())
            {
                RedCubes = int.Parse(AnyDigit.Match(redMatches.First().Value).Value);    
            }
            
            var greenRegex = new Regex("\\d+ green");
            var greenMatches = greenRegex.Matches(line);
            if (greenMatches.Any())
            {
                GreenCubes = int.Parse(AnyDigit.Match(greenMatches.First().Value).Value);    
            }
            
            var blueRegex = new Regex("\\d+ blue");
            var blueMatches = blueRegex.Matches(line);
            if (blueMatches.Any())
            {
                BlueCubes = int.Parse(AnyDigit.Match(blueMatches.First().Value).Value);    
            }
        }

        public bool GameRoundPossible()
        {
            return RedCubes <= MaxRedCubes && GreenCubes <= MaxGreenCubes && BlueCubes <= MaxBlueCubes;
        }
    }
}
