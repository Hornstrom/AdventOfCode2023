namespace Advent_of_Code_2023___Snowpocalypse.Day7_Poker.Part2;

public class CamelCards
{
    public List<Hand> Hands = new List<Hand>();

    public CamelCards(string[] lines)
    {
        foreach (var line in lines)
        {
            Hands.Add(new Hand(line));
        }

        
    }

    public long Play()
    {
        var orderedHands = Hands.OrderByDescending(h => h.Type).ThenBy(h => h.Lazy);
        long winnings = 0;
        for (int i = 0; i < orderedHands.Count(); i++)
        {
            Console.WriteLine($"{orderedHands.ElementAt(i).Cards} has type {orderedHands.ElementAt(i).Type}, bet {orderedHands.ElementAt(i).Bet}, rank {i + 1}");
            winnings += orderedHands.ElementAt(i).Bet * (i + 1);
        }

        return winnings;
    }
}