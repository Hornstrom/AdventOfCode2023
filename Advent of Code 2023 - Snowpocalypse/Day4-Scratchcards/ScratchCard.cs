using System.Text.RegularExpressions;

namespace Advent_of_Code_2023___Snowpocalypse.Day4_Scratchcards;

public class ScratchCard
{
    public List<int> WinningNumbers = new List<int>();
    public List<int> CardNumbers = new List<int>();
    public string Line;
    public int Points;
    public string StringId;
    public int Id;
    public static Regex AnyDigit = new Regex("\\d+");
    public int NumberOfWinningNumbers;
    public int NumberOfCopies;
    

    public ScratchCard(string line)
    {
        Line = line;
        NumberOfCopies = 1;
        var data = line.Split(":");
        StringId = data[0];
        Id = int.Parse(AnyDigit.Match(StringId).Value);
        var numbers = data[1].Split("|");
        var winningCollection = AnyDigit.Matches(numbers[0]);
        foreach (Match winningNumber in winningCollection)
        {
            WinningNumbers.Add(int.Parse(winningNumber.Value));
        }
        var numbersCollection = AnyDigit.Matches(numbers[1]);
        foreach (Match cardNumber in numbersCollection)
        {
            CardNumbers.Add(int.Parse(cardNumber.Value));
        }

        Points = CalculatePoints(WinningNumbers, CardNumbers);
    }

    private int CalculatePoints(List<int> winningNumbers, List<int> cardNumbers)
    {
        var points = 0;
        foreach (var cardNumber in cardNumbers)
        {
            if (winningNumbers.Contains(cardNumber))
            {
                if (points == 0)
                {
                    points = 1;
                }
                else
                {
                    points = points * 2;
                }

                NumberOfWinningNumbers++;
            }
        }
        return points;
    }
}