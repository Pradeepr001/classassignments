using System;

class task3
{
    static void Main()
    {
        // Declare variables for the numbers and choice
        double num1, num2;
        int choice;

        // Prompt the user for input and read the numbers
        Console.Write("Enter the first number: ");
        num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the second number: ");
        num2 = Convert.ToDouble(Console.ReadLine());

        // Display menu options
        Console.WriteLine("Choose an operation:");
        Console.WriteLine("1: Addition");
        Console.WriteLine("2: Subtraction");
        Console.WriteLine("3: Multiplication");
        Console.WriteLine("4: Division");
        Console.Write("Enter your choice (1/2/3/4): ");
        choice = Convert.ToInt32(Console.ReadLine());

        // Perform the chosen operation
        if (choice == 1)
        {
            // Addition
            double sum = num1 + num2;
            Console.WriteLine($"Result: {sum}");
        }
        else if (choice == 2)
        {
            // Subtraction
            double difference = num1 - num2;
            Console.WriteLine($"Result: {difference}");
        }
        else if (choice == 3)
        {
            // Multiplication
            double product = num1 * num2;
            Console.WriteLine($"Result: {product}");
        }
        else if (choice == 4)
        {
            // Division
            if (num2 != 0)
            {
                double quotient = num1 / num2;
                Console.WriteLine($"Result: {quotient}");
            }
            else
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Please select a valid operation.");
        }
    }
}
