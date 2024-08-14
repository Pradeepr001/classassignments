using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Step 1: Declare and initialize the array
        int[] array = { 1, 3, 4, 2, 2, 4, 5, 5, 5 };

        // Step 2: Use a dictionary to track occurrences of each element
        Dictionary<int, int> occurrences = new Dictionary<int, int>();

        foreach (int num in array)
        {
            if (occurrences.ContainsKey(num))
            {
                occurrences[num]++;
            }
            else
            {
                occurrences[num] = 1;
            }
        }

        // Step 3: Count the number of duplicate elements
        int duplicateCount = 0;

        foreach (var entry in occurrences)
        {
            if (entry.Value > 1)
            {
                duplicateCount++;
            }
        }

        // Step 4: Display the total number of duplicate elements
        Console.WriteLine($"Total number of duplicate elements: {duplicateCount}");
    }
}
