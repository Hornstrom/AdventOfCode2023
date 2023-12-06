using System.Text.RegularExpressions;

namespace Advent_of_Code_2023___Snowpocalypse.Day3_GearRatops;

public class SchematicParser
{
    public List<Symbol> Symbols = new List<Symbol>();
    public List<PartNumber> PartNumbers = new List<PartNumber>();
    public static Regex AnyDigit = new Regex("\\d+");
    public static Regex AnySymbol = new Regex("(?!(\\.|\\d+)).");

    public SchematicParser(string[] lines)
    {
        for (int y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            var numbersOnLine = AnyDigit.Matches(line);
            foreach (Match match in numbersOnLine)
            {
                var start = match.Index;
                var end = start + match.Length - 1;
                var value = int.Parse(match.Value);
                PartNumbers.Add(new PartNumber
                {
                    Y = y,
                    XStart = start,
                    XEnd = end,
                    Value = value,
                    PartOfMachine = false
                });
            }

            var symbolsOnLine = AnySymbol.Matches(line);
            foreach (Match symbol in symbolsOnLine)
            {
                Symbols.Add(new Symbol
                    {
                        X = symbol.Index,
                        Y = y,
                        Character = symbol.Value
                    });
            }
        }

        foreach (var partNumber in PartNumbers)
        {
            partNumber.PartOfMachine = Symbols
                .Any(s => s.X >= partNumber.XStart - 1
                            && s.X <= partNumber.XEnd + 1
                            && Math.Abs(s.Y - partNumber.Y) <= 1);
            
        }
    }

    public int SumValidPartNumber()
    {
        return PartNumbers.Where(p => p.PartOfMachine).Sum(p => p.Value);
    }

    public int GearRatioCalculator()
    {
        var sum = 0;
        var gearSymbols = Symbols.Where(s => s.Character == "*");
        foreach (var gearSymbol in gearSymbols)
        {
            var matchingParts = PartNumbers.Where(pn => gearSymbol.X >= pn.XStart - 1
                                                        && gearSymbol.X <= pn.XEnd + 1 && Math.Abs(gearSymbol.Y - pn.Y) <= 1);
            if (matchingParts.Count() == 2)
            {
                sum += matchingParts.ElementAt(0).Value * matchingParts.ElementAt(1).Value;
            }
        }

        return sum;
    }
    
}
