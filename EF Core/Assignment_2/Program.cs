using System;
using StudentConsoleApp.Services;
using StudentConsoleApp.Models;

namespace StudentConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new StudentService();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Display All Students");
                Console.WriteLine("2. Add New Student");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayAllStudents(service);
                        break;
                    case "2":
                        AddNewStudent(service);
                        break;
                    case "3":
                        UpdateStudent(service);
                        break;
                    case "4":
                        DeleteStudent(service);
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void DisplayAllStudents(StudentService service)
        {
            var students = service.GetAll();
            Console.WriteLine("All Students:");
            foreach (var student in students)
            {
                Console.WriteLine($"RN: {student.Rn}, Name: {student.Name}, Address: {student.Address}, Batch: {student.Batch}");
            }
        }

        private static void AddNewStudent(StudentService service)
        {
            var newStudent = new Student();

            Console.Write("Enter student name: ");
            newStudent.Name = Console.ReadLine();

            Console.Write("Enter student address: ");
            newStudent.Address = Console.ReadLine();

            Console.Write("Enter student batch: ");
            newStudent.Batch = Console.ReadLine();

            service.Add(newStudent);
            Console.WriteLine("Student added successfully.");
        }

        private static void UpdateStudent(StudentService service)
        {
            Console.Write("Enter student RN to update: ");
            var rn = int.Parse(Console.ReadLine());

            var student = service.GetById(rn);
            if (student != null)
            {
                Console.Write("Enter new name: ");
                student.Name = Console.ReadLine();

                Console.Write("Enter new address: ");
                student.Address = Console.ReadLine();

                Console.Write("Enter new batch: ");
                student.Batch = Console.ReadLine();

                service.Update(student);
                Console.WriteLine("Student updated successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        private static void DeleteStudent(StudentService service)
        {
            Console.Write("Enter student RN to delete: ");
            var rn = int.Parse(Console.ReadLine());

            service.Delete(rn);
            Console.WriteLine("Student deleted successfully.");
        }
    }
}
