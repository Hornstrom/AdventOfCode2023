namespace Advent_of_Code_2023___Snowpocalypse.Day1_Trebuchet;

public class DocumentDePrettifier
{
    public string[] TestCalibrationDocument = File.ReadAllLines(@"Day1-Trebuchet\testdata.txt");
    public string[] CalibrationDocument = File.ReadAllLines(@"Day1-Trebuchet\data.txt");
    
    public string[] TestCalibrationDocument2 = File.ReadAllLines(@"Day1-Trebuchet\testdata2.txt");

    public void PrintProblem()
    {
        Console.WriteLine($"Part 1: Test data return {SumTheRows(TestCalibrationDocument)}");
        Console.WriteLine($"Part 1: Data return {SumTheRows(CalibrationDocument)}");
        
        Console.WriteLine($"Part 2: Test data return {SumTheRowsPart2(TestCalibrationDocument2)}");
        Console.WriteLine($"Part 2: Data return {SumTheRowsPart2(CalibrationDocument)}");
    }

    public int SumTheRows(string[] data)
    {
        var sum = 0;
        foreach (var line in data)
        {
            var digitArray = line.Where(char.IsDigit).ToArray();
            var firstChar = char.GetNumericValue(digitArray.First());
            var secondChar =  char.GetNumericValue(digitArray.Last());
            sum += (int) firstChar * 10 + (int) secondChar;
        }
        return sum;
    }
    
    public int SumTheRowsPart2(string[] data)
    {
        var sum = 0;
        foreach (var line in data)
        {
            var updatedLine = ReplaceTextWithNumber(line);
            var digitArray = updatedLine.Where(char.IsDigit).ToArray();
            var firstChar = char.GetNumericValue(digitArray.First());
            var secondChar =  char.GetNumericValue(digitArray.Last());
            sum += (int) firstChar * 10 + (int) secondChar;
        }
        return sum;
    }

    public string ReplaceTextWithNumber(string line)
    {
        var beforeLoop = "";
        while (line != beforeLoop)
        {
            beforeLoop = line;
            if (line.Contains("one"))
            {
                line = line.Insert(line.IndexOf("one") + 1, "1");
            };
            if (line.Contains("two")) {
                line = line.Insert(line.IndexOf("two") + 1, "2");
            };
            if (line.Contains("three")) {
                line = line.Insert(line.IndexOf("three") + 1, "3");
            };
            if (line.Contains("four")) {
                line = line.Insert(line.IndexOf("four") + 1, "4");
            };
            if (line.Contains("five")) {
                line = line.Insert(line.IndexOf("five") + 1, "5");
            };
            if (line.Contains("six")) {
                line = line.Insert(line.IndexOf("six") + 1, "6");
            };
            if (line.Contains("seven")) {
                line = line.Insert(line.IndexOf("seven") + 1, "7");
            };
            if (line.Contains("eight")) {
                line = line.Insert(line.IndexOf("eight") + 1, "8");
            };
            if (line.Contains("nine")) {
                line = line.Insert(line.IndexOf("nine") + 1, "9");
            };
        }
        
        
        return line;
    }
}
