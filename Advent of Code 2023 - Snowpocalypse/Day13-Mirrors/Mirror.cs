namespace Advent_of_Code_2023___Snowpocalypse.Day13_Mirrors;

public class Mirror
{
    public string[] Image;
    public int ReflectionInColumn;
    public int ReflectionInRow;
    public int SecondReflectionColumn;
    public int SecondReflectionRow;

    public Mirror(string[] lines)
    {
        Image = lines;
        ReflectionInColumn = FindReflection(Image);
        ReflectionInRow = FindReflection(Transpose(Image));
        SecondReflectionColumn = FindSecondReflection(Image, ReflectionInColumn);
        SecondReflectionRow = FindSecondReflection(Transpose(Image), ReflectionInRow);
    }

    private string[] Transpose(string[] image)
    {
        var transposedImage = new string[image[0].Length];
    
        for (int orgX = 0; orgX < image[0].Length; orgX++)
        {
            var niceString = "";
            for (int orgY = 0; orgY < image.Length; orgY++)
            {
                niceString = niceString + image[orgY].ElementAt(orgX);
            }
            transposedImage[orgX] = niceString;
        }

        return transposedImage;
    }

    private int FindReflection(string[] image, int? ignoreResultColumn = null)
    {
        var result = 0;
        // Start with finding reflection in a Column
        var possibleColumnReflections = new bool[image[0].Length - 1];
        for (int i = 0; i < possibleColumnReflections.Length; i++)
        {
            possibleColumnReflections[i] = true;
        }
        
        for (int y = 0; y < image.Length; y++)
        {
            for (int x = 1; x < image[y].Length; x++)
            {
                var left = image[y].Substring(0, x);
                var right = image[y].Substring(x);

                var shortestStringLength = Math.Min(left.Length, right.Length);
                var leftReflection = ToReverseString(left);
                leftReflection = leftReflection.Substring(0, shortestStringLength);
                right = right.Substring(0, shortestStringLength);

                if (leftReflection != right)
                {
                    possibleColumnReflections[x - 1] = false;
                }
            }
            
            if (possibleColumnReflections.All(r => r == false) && y > 0)
            {
                // Give up if there aren't any possible Columns left
                break;
            }
        }

        var nrOfColumnReflections = 0;
        for (int i = 0; i < possibleColumnReflections.Length; i++)
        {
            if (possibleColumnReflections[i])
            {
                if (ignoreResultColumn.HasValue && ignoreResultColumn == i + 1)
                {
                    continue;
                }
                result = i + 1;
                nrOfColumnReflections++;
            }

            // if (nrOfColumnReflections > 1)
            // {
            //     throw new Exception("Why are there two reflections?");
            // }
        }

        return result;
    }

    public int FindSecondReflection(string[] image, int previousReflection)
    {
        for (int y = 0; y < image.Length; y++)
        {
            for (int x = 0; x < image[y].Length; x++)
            {
                var orgChar = image[y].ElementAt(x);
                var orgString = image[y];
                var newChar = orgChar.Equals('#') ? '.' : '#';
                var newArray = orgString.ToCharArray();
                newArray[x] = newChar;
                var newString = new string(newArray);
                image[y] = newString;
                var reflection = FindReflection(image, previousReflection);
                image[y] = orgString;
                
                if (reflection != 0 && reflection != previousReflection)
                {
                    return reflection;
                }
            }
        }

        return 0;
    }

    public static string ToReverseString(string s)
    {
        var charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
