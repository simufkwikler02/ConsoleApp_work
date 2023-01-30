using System;
using System.IO;
using ConsoleApp_work;
using System.Diagnostics;
using BenchmarkDotNet.Running;

do
{
    Console.WriteLine("Enter the path file:");
    string path = Console.ReadLine() ?? string.Empty;
    path = "D:\\257.csv";
    var t = new Stopwatch();
    t.Start();
    if (!File.Exists(path))
    {
        Console.WriteLine("This path is not exist");
        continue;
    }
    var fileData = new FileData(path);
    fileData.ReadAndWriteCsv();
    t.Stop();
    Console.WriteLine($"Read adn write finish t = {t.ElapsedMilliseconds}");
    Console.WriteLine("---------------------------------------------");

} while (true);

//BenchmarkRunner.Run<DataBenchmarks>();


