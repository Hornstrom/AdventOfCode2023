namespace Advent_of_Code_2023___Snowpocalypse.Day4_Scratchcards;

public class ScratchMaster3000
{
    public List<ScratchCard> ScratchCards = new List<ScratchCard>();

    public ScratchMaster3000(string[] lines)
    {
        foreach (var line in lines)
        {
            ScratchCards.Add(new ScratchCard(line));
        }
    }

    public int SumPoints()
    {
        return ScratchCards.Sum(s => s.Points);
    }

    public int NumberOfWonScratchcards()
    {
        for (int i = 0; i < ScratchCards.Count; i++)
        {
            var nrOfIds = ScratchCards[i].NumberOfWinningNumbers;
            for (int j = 1; j <= nrOfIds; j++)
            {
                ScratchCards[i + j].NumberOfCopies += ScratchCards[i].NumberOfCopies;
            }
        }

        return ScratchCards.Sum(c => c.NumberOfCopies);
    }
}