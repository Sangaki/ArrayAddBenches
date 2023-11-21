using BenchmarkDotNet.Attributes;

namespace ConsoleApp1;

[ShortRunJob]
[Config(typeof(SerialiserBenchmarksConfig))]
public class ArrayTasks
{
    [Benchmark]
    public int[] ArrayFilterViaResultArraySameSized()
    {
        var numbers = new int[] { -99, -54, -124, -178, -42, -3, 1, -2, 1, -2, -1, 0, 0, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 9 };
        var numberToRemove = 1;
        
        var tempNumbers = new int[numbers.Length];
        var offset = 0;
        
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] != numberToRemove)
            {
                tempNumbers[i - offset] = numbers[i];
            }
            else
            {
                offset++;
            }
        }

        var resultNumbers = new int[numbers.Length - offset];
        for (int i = 0; i < resultNumbers.Length; i++)
        {
            resultNumbers[i] = tempNumbers[i];
        }

        return resultNumbers;
    }
    
    [Benchmark]
    public int[] ArrayFilterViaResize()
    {
        var numbers = new int[] { -99, -54, -124, -178, -42, -3, 1, -2, 1, -2, -1, 0, 0, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 9 };
        var numberToRemove = 1;
        
        var resultNumbers = Array.Empty<int>();
        var offset = 0;
        
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] != numberToRemove)
            {
                Array.Resize(ref resultNumbers, i - offset + 1);
                resultNumbers[i - offset] = numbers[i];
            }
            else
            {
                offset++;
            }
        }

        return resultNumbers;
    }
    
    [Benchmark]
    public int[] ArrayFilterViaArrayConcat()
    {
        var numbers = new int[] { -99, -54, -124, -178, -42, -3, 1, -2, 1, -2, -1, 0, 0, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 9 };
        var numberToRemove = 1;
        
        var resultNumbers = Array.Empty<int>();
        
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] != numberToRemove)
            {
                resultNumbers = resultNumbers.Concat(new[] { numbers[i] }).ToArray();
            }
        }

        return resultNumbers;
    }
    
    [Benchmark]
    public int[] ArrayFilterViaWhereClause()
    {
        var numbers = new int[] { -99, -54, -124, -178, -42, -3, 1, -2, 1, -2, -1, 0, 0, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 9 };
        var numberToRemove = 1;
        
        var resultNumbers = numbers.Where(x => x != numberToRemove).ToArray();

        return resultNumbers;
    }
    
    [Benchmark]
    public List<int> ArrayFilterViaListsWhereClause()
    {
        var numbers = new List<int>() { -99, -54, -124, -178, -42, -3, 1, -2, 1, -2, -1, 0, 0, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 9 };
        var numberToRemove = 1;
        
        var resultNumbers = numbers.Where(x => x != numberToRemove).ToList();

        return resultNumbers;
    }
    
    [Benchmark]
    public List<int> ArrayFilterViaListsAdd()
    {
        var numbers = new List<int>() { -99, -54, -124, -178, -42, -3, 1, -2, 1, -2, -1, 0, 0, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 9 };
        var numberToRemove = 1;
        
        var resultNumbers = new List<int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] != numberToRemove)
            {
                resultNumbers.Add(numbers[i]);
            }
        }
        
        return resultNumbers;
    }
}