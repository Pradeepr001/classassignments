using System;

class Program
{
    static void Main()
    {
        // Declare two variables to store the numbers
        double num1, num2;

        // Prompt the user for input and read the numbers
        Console.Write("Enter the first number: ");
        num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the second number: ");
        num2 = Convert.ToDouble(Console.ReadLine());

        // Perform calculations
        double sum = num1 + num2;
        double difference = num1 - num2;
        double product = num1 * num2;
        double quotient = num2 != 0 ? num1 / num2 : double.NaN; // Handle division by zero

        // Display the results
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Difference: {difference}");
        Console.WriteLine($"Product: {product}");
        Console.WriteLine($"Quotient: {(double.IsNaN(quotient) ? "Undefined (division by zero)" : quotient.ToString())}");
    }
}
