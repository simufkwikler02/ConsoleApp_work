using System;
using System.IO;
using ConsoleApp_work;

do
{
    Console.WriteLine("Enter the path file:");
    string path = Console.ReadLine() ?? string.Empty;
    ..path = "D:\\257.csv";
    if (!File.Exists(path))
    {
        Console.WriteLine("This path is not exist");
        continue;
    }
    var fileData = new FileData(path);
    fileData.ReadAll();
    Console.WriteLine("Read finish");
    fileData.Write6();
    Console.WriteLine("Write finish");
    Console.WriteLine("---------------------------------------------");

} while (true);


