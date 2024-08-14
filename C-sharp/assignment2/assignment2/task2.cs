using System;

class task2
{
    static void Main()
    {
        // Step 1: Declare and initialize two 3x3 matrices
        int[,] matrix1 = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        int[,] matrix2 = {
            { 9, 8, 7 },
            { 6, 5, 4 },
            { 3, 2, 1 }
        };

        // Step 2: Calculate the sum of the two matrices
        int[,] sumMatrix = new int[3, 3];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                sumMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        // Step 3: Display the resulting sum matrix
        Console.WriteLine("Sum of the two 3x3 matrices:");

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"{sumMatrix[i, j]} ");
            }
            Console.WriteLine(); // Move to the next line after each row
        }
    }
}
