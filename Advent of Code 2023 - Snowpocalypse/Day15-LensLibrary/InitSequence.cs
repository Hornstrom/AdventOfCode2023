namespace Advent_of_Code_2023___Snowpocalypse.Day15_LensLibrary;

public class InitSequence
{
    public string Sequence;

    public InitSequence(string[] lines)
    {
        Sequence = lines[0];
    }

    public int Part1()
    {
        
        var sum = 0;
        var sequences = Sequence.Split(",");

        foreach (var sequence in sequences)
        {
            var controlValue = 0;
            var sequenceArray = sequence.ToCharArray();

            for (int i = 0; i < sequenceArray.Length; i++)
            {
                controlValue += sequenceArray[i];
                controlValue *= 17;
                controlValue %= 256;
            }

            sum += controlValue;
        }
        
        

        return sum;
    }
}