using System;

class task4
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

        // Step 2: Calculate the column-wise sums
        int[] columnSums = new int[columns];

        for (int j = 0; j < columns; j++)
        {
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                sum += array[i, j];
            }
            columnSums[j] = sum;
        }

        // Step 3: Display the column-wise sums
        Console.WriteLine("Column-wise sums:");
        for (int j = 0; j < columns; j++)
        {
            Console.WriteLine($"Column {j + 1}: {columnSums[j]}");
        }
    }
}
