namespace Advent_of_Code_2023___Snowpocalypse.Day7_Poker.Part1;

public class Hand// : IComparable<Hand>
{
    public string Cards;
    public int[] CardsArray = new int[5];
    public int Bet;
    public int Type;
    public long Lazy;

    public Hand(string line)
    {
        var setup = line.Split(" ");
        Cards = setup[0];
        Bet = int.Parse(setup[1]);
        CardStringToIntArray(Cards);
        CalculateType();
        SetLazy();
    }

    private void CardStringToIntArray(string cards)
    {
        var charArray = cards.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            if (int.TryParse(charArray[i].ToString(), out var cardValue))
            {
                CardsArray[i] = cardValue;
            }
            if (charArray[i].Equals('T'))
            {
                CardsArray[i] = 10;
            }
            if (charArray[i].Equals('J'))
            {
                CardsArray[i] = 11;
            }
            if (charArray[i].Equals('Q'))
            {
                CardsArray[i] = 12;
            }
            if (charArray[i].Equals('K'))
            {
                CardsArray[i] = 13;
            }
            if (charArray[i].Equals('A'))
            {
                CardsArray[i] = 14;
            }
        }
    }
    
    private void CalculateType()
    {
        var type = int.MaxValue;
        var orderedArray = CardsArray.OrderByDescending(c => c);
        var numberOfInstancesOfCard = new int[5];
        for (int i = 0; i < CardsArray.Length; i++)
        {
            numberOfInstancesOfCard[i] = CardsArray.Count(c => c.Equals(CardsArray[i]));
        }
        
        if (numberOfInstancesOfCard.Max() == 5)
        {
            Type = 1;
        }
        else if (numberOfInstancesOfCard.Max() == 4)
        {
            Type = 2;
        }
        else if (numberOfInstancesOfCard.Contains(3) && numberOfInstancesOfCard.Contains(2))
        {
            Type = 3;
        }
        else if (numberOfInstancesOfCard.Max() == 3)
        {
            Type = 4;
        }
        else if (numberOfInstancesOfCard.Count(n => n == 2) == 4)
        {
            Type = 5;
        }
        else if (numberOfInstancesOfCard.Count(n => n == 2) == 2)
        {
            Type = 6;
        }
        else
        {
            Type = 7;
        }
    }

    private void SetLazy()
    {
        long foo = 100000000000;
        long lazy = 0;
        foreach (var card in CardsArray)
        {
            lazy += card * foo;
            foo = foo / 100;
        }
        Lazy = lazy;
    }
    
    

    //
    // public int CompareTo(Hand? other)
    // {
    //     if (ReferenceEquals(this, other)) return 0;
    //     if (ReferenceEquals(null, other)) return 1;
    //     var cardsComparison = string.Compare(Cards, other.Cards, StringComparison.Ordinal);
    //     if (cardsComparison != 0) return cardsComparison;
    //     var betComparison = Bet.CompareTo(other.Bet);
    //     if (betComparison != 0) return betComparison;
    //     return Type.CompareTo(other.Type);
    // }
}