﻿using System;
using System.IO;
using ConsoleApp_work;
using System.Diagnostics;
using BenchmarkDotNet.Running;
using System.Net;
using System.Net.NetworkInformation;

#if DEBUG
var time = new Stopwatch();
//string url = "https://drive.google.com/u/0/uc?id=11gltuDZucDoX_7W32o0MfVFAp9PXFkh9&export=download";
string url = "https://vk.com/doc167552191_659388230?hash=Hb5vHpvpJfDnl70W7wfL8y7HwBx1AyxpijUj4YlJc7g&dl=EfxDp8xEgvZyFQEHgNuQV92pJNZlEorkssnvz5Aspak";
//string url = "https://opencellid.org/ocid/downloads?token=pk.b6c2d57c221ba5e71e9c481f29767a8b&type=mcc&file=257.csv.gz";
string save_path = "D:\\";

if (!Directory.Exists(save_path))
{
    Console.WriteLine("This path is not exist");
    return;
}

var fileData = new FileData();
Console.WriteLine("Start download and save...");
time.Start();
await fileData.DownloadAndSaveCsv(url, save_path);
time.Stop();
Console.WriteLine($"Finish download and save! Time -- {time.ElapsedMilliseconds} ms.");
Console.WriteLine("---------------------------------------------");


#else
BenchmarkRunner.Run<DataBenchmarks>();
Console.ReadKey();
#endif


