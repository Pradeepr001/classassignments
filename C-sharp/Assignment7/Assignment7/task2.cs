using System;
using System.IO;

class task2
{
    static void Main()
    {
        while (true)
        {
            // Display menu options
            Console.WriteLine("File Operations Menu:");
            Console.WriteLine("1. Create a new file");
            Console.WriteLine("2. Add contents to the file");
            Console.WriteLine("3. Append contents to the file");
            Console.WriteLine("4. Display contents one by one");
            Console.WriteLine("5. Display all contents together");
            Console.WriteLine("6. Exit");

            // Get user choice
            Console.Write("Enter your choice (1-6): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateFile();
                    break;
                case "2":
                    AddContents();
                    break;
                case "3":
                    AppendContents();
                    break;
                case "4":
                    DisplayContentsOneByOne();
                    break;
                case "5":
                    DisplayAllContents();
                    break;
                case "6":
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    static void CreateFile()
    {
        Console.Write("Enter the file name to create: ");
        string fileName = Console.ReadLine();

        try
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                Console.WriteLine($"File '{fileName}' created successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void AddContents()
    {
        Console.Write("Enter the file name to add contents: ");
        string fileName = Console.ReadLine();

        Console.Write("Enter the content to add: ");
        string content = Console.ReadLine();

        try
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(content);
                Console.WriteLine("Content added successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void AppendContents()
    {
        Console.Write("Enter the file name to append contents: ");
        string fileName = Console.ReadLine();

        Console.Write("Enter the content to append: ");
        string content = Console.ReadLine();

        try
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(content);
                Console.WriteLine("Content appended successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void DisplayContentsOneByOne()
    {
        Console.Write("Enter the file name to display contents: ");
        string fileName = Console.ReadLine();

        try
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                Console.WriteLine("File contents:");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Please create the file first.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void DisplayAllContents()
    {
        Console.Write("Enter the file name to display all contents: ");
        string fileName = Console.ReadLine();

        try
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                Console.WriteLine("File contents:");
                Console.WriteLine(sr.ReadToEnd());
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Please create the file first.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
