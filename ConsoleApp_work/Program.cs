using System;
using System.IO;
using ConsoleApp_work;
using System.Diagnostics;
using BenchmarkDotNet.Running;
using System.Net;
using System.Net.NetworkInformation;

#if DEBUG
var time = new Stopwatch();
string url = "https://drive.google.com/u/0/uc?id=11gltuDZucDoX_7W32o0MfVFAp9PXFkh9&export=download";
string save_path = "D:\\257.csv";


Console.WriteLine("Start download...");
time.Start();

await Task.WhenAll(HttpHelper.DownloadFileAsync(url, save_path));
time.Stop();
Console.WriteLine($"Finish download! Time -- {time.ElapsedMilliseconds} ms.");
time.Reset();



if (!File.Exists(save_path))
{
    Console.WriteLine("This path is not exist");
    return;
}
var fileData = new FileData(save_path);
Console.WriteLine("Start read and save...");
time.Start();
fileData.ReadAndWriteCsv();
time.Stop();
Console.WriteLine($"Finish read and save! Time -- {time.ElapsedMilliseconds} ms.");
Console.WriteLine("---------------------------------------------");


#else
BenchmarkRunner.Run<DataBenchmarks>();
Console.ReadKey();
#endif


