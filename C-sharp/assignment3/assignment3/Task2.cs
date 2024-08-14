using System;

class Task2
{
    static void Main()
    {
        // Step 1: Input marks obtained in Physics, Chemistry, and Mathematics
        Console.Write("Input the marks obtained in Physics: ");
        int physicsMarks = Convert.ToInt32(Console.ReadLine());

        Console.Write("Input the marks obtained in Chemistry: ");
        int chemistryMarks = Convert.ToInt32(Console.ReadLine());

        Console.Write("Input the marks obtained in Mathematics: ");
        int mathMarks = Convert.ToInt32(Console.ReadLine());

        // Step 2: Calculate total marks
        int totalMarks = physicsMarks + chemistryMarks + mathMarks;
        int totalMathPhysics = mathMarks + physicsMarks;

        // Step 3: Check eligibility based on the given criteria
        bool isEligible = (mathMarks >= 65 && physicsMarks >= 55 && chemistryMarks >= 50 && totalMarks >= 180) ||
                          (totalMathPhysics >= 140);

        // Step 4: Display the result
        if (isEligible)
        {
            Console.WriteLine("The candidate is eligible for admission.");
        }
        else
        {
            Console.WriteLine("The candidate is not eligible for admission.");
        }
    }
}
