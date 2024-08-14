using System;

class task7
{
    static void Main()
    {
        // Prompt the user to enter a number
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Display the multiplication table using a for loop
        Console.WriteLine($"\nMultiplication table for {number} using for loop:");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{number} x {i} = {number * i}");
        }


        /*{
            // Prompt the user to enter a number
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            // Initialize the counter
            int i = 1;

            // Display the multiplication table using a while loop
            Console.WriteLine($"\nMultiplication table for {number} using while loop:");
            while (i <= 10)
            {
                Console.WriteLine($"{number} x {i} = {number * i}");
                i++;
            }
        }*/
       /* // Prompt the user to enter a number
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Initialize the counter
        int i = 1;

        // Display the multiplication table using a do-while loop
        Console.WriteLine($"\nMultiplication table for {number} using do-while loop:");
        do
        {
            Console.WriteLine($"{number} x {i} = {number * i}");
            i++;
        } while (i <= 10);*/
    }

}
