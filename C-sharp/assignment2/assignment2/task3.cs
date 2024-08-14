using System;

class task3
{
    static void Main()
    {
        // Step 1: Declare and initialize the integer array
        int[] numbers = { 34, 78, 12, 89, 23, 56, 99 };

        // Step 2: Find the maximum element in the array
        int max = numbers[0]; // Assume the first element is the maximum

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }

        // Step 3: Display the maximum element
        Console.WriteLine($"The maximum element in the array is: {max}");
    }
}
