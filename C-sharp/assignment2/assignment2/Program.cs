using System;

class Program
{
    static void Main()
    {
        // Step 1: Declare and initialize the array
        int[] numbers = { 10, 20, 30, 40, 50 };

        // Step 2: Calculate the sum of the array elements
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        // Step 3: Calculate the average of the array elements
        double average = (double)sum / numbers.Length;

        // Step 4: Display the sum and average
        Console.WriteLine($"Sum of the array elements: {sum}");
        Console.WriteLine($"Average of the array elements: {average}");
    }
}
