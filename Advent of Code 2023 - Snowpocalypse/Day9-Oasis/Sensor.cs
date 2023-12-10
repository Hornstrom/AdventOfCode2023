namespace Advent_of_Code_2023___Snowpocalypse.Day9_Oasis;

public class Sensor
{
    public List<SensorData> SensorDataList;

    public Sensor(string[] lines)
    {
        SensorDataList = new List<SensorData>();
        foreach (var line in lines)
        {
            SensorDataList.Add(new SensorData(line));
        }
    }

    public long Part1()
    {
        long sum = 0;
        foreach (var sensorData in SensorDataList)
        {
            sensorData.AddValueToHistories();
            sum += sensorData.Histories.First().Last();

        }

        return sum;
    }

    public long Part2()
    {
        long sum = 0;
        foreach (var sensorData in SensorDataList)
        {
            sensorData.AddValueToStartOfHistories();
            sum += sensorData.Histories.First().First();

        }

        return sum;
    }
}