using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Define directory paths
        string rootDir = "demo";
        string dir1 = Path.Combine(rootDir, "demo1");
        string dir2 = Path.Combine(rootDir, "demo2");

        // Create directories
        Directory.CreateDirectory(rootDir);
        Directory.CreateDirectory(dir1);
        Directory.CreateDirectory(dir2);

        // Define file paths
        string file1 = Path.Combine(rootDir, "file1.txt");
        string file2 = Path.Combine(rootDir, "file2.txt");
        string file3 = Path.Combine(dir1, "file3.txt");

        // Create and write files using File class
        File.WriteAllText(file1, "This is the content of file1.");
        File.WriteAllText(file2, "This is the content of file2.");

        // Create and write files using FileInfo class
        FileInfo fileInfo = new FileInfo(file3);
        using (StreamWriter sw = fileInfo.CreateText())
        {
            sw.WriteLine("This is the content of file3.");
        }

        // Copy file1 to demo2 folder
        string file1Copy = Path.Combine(dir2, "file1.txt");
        File.Copy(file1, file1Copy);

        // Display all files and directories with their creation time
        Console.WriteLine("Files and directories in 'demo':");
        DisplayFilesAndDirectories(rootDir);

        // Delete all files in the directories
        DeleteFiles(rootDir);
        DeleteFiles(dir1);
        DeleteFiles(dir2);

        // Delete all directories
        Directory.Delete(dir2);
        Directory.Delete(dir1);
        Directory.Delete(rootDir);

        Console.WriteLine("All files and directories have been deleted.");
    }

    static void DisplayFilesAndDirectories(string path)
    {
        // Display directories
        string[] directories = Directory.GetDirectories(path);
        foreach (string dir in directories)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            Console.WriteLine($"Directory: {dirInfo.FullName} - Created: {dirInfo.CreationTime}");
        }

        // Display files
        string[] files = Directory.GetFiles(path);
        foreach (string file in files)
        {
            FileInfo fileInfo = new FileInfo(file);
            Console.WriteLine($"File: {fileInfo.FullName} - Created: {fileInfo.CreationTime}");
        }
    }

    static void DeleteFiles(string path)
    {
        // Delete all files in the directory
        string[] files = Directory.GetFiles(path);
        foreach (string file in files)
        {
            File.Delete(file);
        }
    }
}
