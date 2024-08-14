using System;

class task5
{
    static void Main()
    {
        // Step 1: Declare and initialize a 2D array
        int[,] array = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        // Get the number of rows and columns
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);

        // Step 2: Calculate the row-wise sums
        int[] rowSums = new int[rows];

        for (int i = 0; i < rows; i++)
        {
            int sum = 0;
            for (int j = 0; j < columns; j++)
            {
                sum += array[i, j];
            }
            rowSums[i] = sum;
        }

        // Step 3: Display the row-wise sums
        Console.WriteLine("Row-wise sums:");
        for (int i = 0; i < rows; i++)
        {
            Console.WriteLine($"Row {i + 1}: {rowSums[i]}");
        }
    }
}
