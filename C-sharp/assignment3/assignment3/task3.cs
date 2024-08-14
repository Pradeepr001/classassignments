using System;

class task3
{
    static void Main()
    {
        // Input customer details
        Console.Write("Enter Customer ID: ");
        int customerId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Customer Name: ");
        string customerName = Console.ReadLine();

        Console.Write("Enter Units Consumed: ");
        int unitsConsumed = Convert.ToInt32(Console.ReadLine());

        // Calculate the bill based on units consumed
        double amountCharges = 0.0;

        if (unitsConsumed <= 199)
        {
            amountCharges = unitsConsumed * 1.20;
        }
        else if (unitsConsumed >= 200 && unitsConsumed < 400)
        {
            amountCharges = unitsConsumed * 1.50;
        }
        else if (unitsConsumed >= 400 && unitsConsumed < 600)
        {
            amountCharges = unitsConsumed * 1.80;
        }
        else if (unitsConsumed >= 600)
        {
            amountCharges = unitsConsumed * 2.00;
        }

        // Apply surcharge if bill exceeds Rs. 400
        double surcharge = 0.0;
        if (amountCharges > 400)
        {
            surcharge = amountCharges * 0.15;
        }

        // Ensure minimum bill is Rs. 100
        if (amountCharges < 100)
        {
            amountCharges = 100;
        }

        // Calculate total amount to be paid
        double totalAmount = amountCharges + surcharge;

        // Print the results
        Console.WriteLine();
        Console.WriteLine($"Customer IDNO      : {customerId}");
        Console.WriteLine($"Customer Name      : {customerName}");
        Console.WriteLine($"Units Consumed     : {unitsConsumed}");
        Console.WriteLine($"Amount Charges @Rs. {GetChargePerUnit(unitsConsumed):0.00} per unit : {amountCharges:0.00}");
        Console.WriteLine($"Surcharge Amount   : {surcharge:0.00}");
        Console.WriteLine($"Net Amount Paid By the Customer : {totalAmount:0.00}");
    }

    // Helper method to determine charge per unit
    static double GetChargePerUnit(int units)
    {
        if (units <= 199)
        {
            return 1.20;
        }
        else if (units >= 200 && units < 400)
        {
            return 1.50;
        }
        else if (units >= 400 && units < 600)
        {
            return 1.80;
        }
        else
        {
            return 2.00;
        }
    }
}
