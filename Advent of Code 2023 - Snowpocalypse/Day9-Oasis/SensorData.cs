namespace Advent_of_Code_2023___Snowpocalypse.Day9_Oasis;

public class SensorData
{
    public List<List<int>> Histories = new List<List<int>>();
    
    public SensorData(string line)
    {
        var dataPoints = new List<int>();
        var measurements = line.Split(" ");
        foreach (var measurement in measurements)
        {
            dataPoints.Add(int.Parse(measurement));
        }
        Histories.Add(dataPoints);
        CalculateHistories();
        
    }

    public void CalculateHistories()
    {
        while (true)
        {
            var previousLine = Histories.Last();
            var dataPoints = new List<int>();
            for (int i = 0; i < previousLine.Count - 1; i++)
            {
                dataPoints.Add(previousLine.ElementAt(i + 1) - previousLine.ElementAt(i));
            }
            Histories.Add(dataPoints);
            if (dataPoints.All(d => d == 0))
            {
                break;
            }
        }
    }

    public void AddValueToHistories()
    {
        for (int i = Histories.Count - 1; i >= 0; i--)
        {
            var valueToAdd = 0;
            if (i != Histories.Count() - 1)
            {
                valueToAdd = Histories.ElementAt(i + 1).Last() + Histories.ElementAt(i).Last();
            }
            Histories.ElementAt(i).Add(valueToAdd);
        }
    }
    
    public void AddValueToStartOfHistories()
    {
        for (int i = Histories.Count - 1; i >= 0; i--)
        {
            var valueToAdd = 0;
            if (i != Histories.Count() - 1)
            {
                valueToAdd = Histories.ElementAt(i).First() - Histories.ElementAt(i + 1).First();
            }
            Histories.ElementAt(i).Insert(0, valueToAdd);
        }
    }
}