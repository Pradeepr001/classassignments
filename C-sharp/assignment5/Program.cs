using System;
using System.Collections.Generic;

abstract class Employee
{
    public string ID { get; set; }
    public string Name { get; set; }
    public string ReportingManager { get; set; }

    public Employee(string id, string name, string reportingManager)
    {
        ID = id;
        Name = name;
        ReportingManager = reportingManager;
    }

    public abstract void DisplayDetails();
}

class OnContractEmployee : Employee
{
    public DateTime ContractDate { get; set; }
    public int Duration { get; set; } // Duration in months
    public double Charges { get; set; }

    public OnContractEmployee(string id, string name, string reportingManager, DateTime contractDate, int duration, double charges)
        : base(id, name, reportingManager)
    {
        ContractDate = contractDate;
        Duration = duration;
        Charges = charges;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Employee ID: {ID}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Reporting Manager: {ReportingManager}");
        Console.WriteLine($"Contract Date: {ContractDate.ToShortDateString()}");
        Console.WriteLine($"Duration (months): {Duration}");
        Console.WriteLine($"Charges: {Charges:C}");
        Console.WriteLine();
    }
}

class OnPayrollEmployee : Employee
{
    public DateTime JoiningDate { get; set; }
    public int Experience { get; set; } // Experience in years
    public double BasicSalary { get; set; }
    public double DA { get; private set; }
    public double HRA { get; private set; }
    public double PF { get; private set; }

    public OnPayrollEmployee(string id, string name, string reportingManager, DateTime joiningDate, int experience, double basicSalary)
        : base(id, name, reportingManager)
    {
        JoiningDate = joiningDate;
        Experience = experience;
        BasicSalary = basicSalary;
        CalculateSalaryComponents();
    }

    private void CalculateSalaryComponents()
    {
        if (Experience > 10)
        {
            DA = 0.10 * BasicSalary;
            HRA = 0.085 * BasicSalary;
            PF = 6200;
        }
        else if (Experience > 7)
        {
            DA = 0.07 * BasicSalary;
            HRA = 0.065 * BasicSalary;
            PF = 4100;
        }
        else if (Experience > 5)
        {
            DA = 0.041 * BasicSalary;
            HRA = 0.038 * BasicSalary;
            PF = 1800;
        }
        else
        {
            DA = 0.019 * BasicSalary;
            HRA = 0.020 * BasicSalary;
            PF = 1200;
        }
    }

    public double CalculateNetSalary()
    {
        return BasicSalary + DA + HRA - PF;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Employee ID: {ID}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Reporting Manager: {ReportingManager}");
        Console.WriteLine($"Joining Date: {JoiningDate.ToShortDateString()}");
        Console.WriteLine($"Experience: {Experience} years");
        Console.WriteLine($"Basic Salary: {BasicSalary:C}");
        Console.WriteLine($"DA: {DA:C}");
        Console.WriteLine($"HRA: {HRA:C}");
        Console.WriteLine($"PF: {PF:C}");
        Console.WriteLine($"Net Salary: {CalculateNetSalary():C}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        // Adding some sample employees
        employees.Add(new OnContractEmployee("C001", "Alice", "Bob", new DateTime(2023, 1, 15), 12, 5000));
        employees.Add(new OnContractEmployee("C002", "Charlie", "David", new DateTime(2023, 2, 1), 6, 3000));

        employees.Add(new OnPayrollEmployee("P001", "Eve", "Frank", new DateTime(2015, 6, 1), 9, 50000));
        employees.Add(new OnPayrollEmployee("P002", "Grace", "Hank", new DateTime(2018, 8, 15), 4, 35000));

        Console.WriteLine("Employee Details:\n");

        foreach (var employee in employees)
        {
            employee.DisplayDetails();
        }

        Console.WriteLine($"Total number of Employees: {employees.Count}");
    }
}
