namespace Advent_of_Code_2023___Snowpocalypse.Day6_BoatRace;

public class BoatRace
{
    public List<long> RecordBreakingTU = new List<long>();
    
    public BoatRace(long time, long distance)
    {
        CalculateTus(time, distance);
    }

    private void CalculateTus(long time, long distance)
    {
        for (long i = 0; i < time; i++)
        {
            var iDistance = i * (time - i);
            if (iDistance > distance)
            {
                RecordBreakingTU.Add(i);
            }
            else
            {
                if (RecordBreakingTU.Any())
                {
                    // No need to run out the entire set of times
                    break;
                }
            }
        }
    }
    
    
    
    
}