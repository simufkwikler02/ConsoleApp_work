using System;
using System.IO;
using ConsoleApp_work;
using System.Diagnostics;
using BenchmarkDotNet.Running;
using System.Net;
using System.Net.NetworkInformation;

#if DEBUG
string url = "https://drive.google.com/u/0/uc?id=1nlcqoqpXKyfMs3nbBfhAGzniT4JXHu7Z&export=download";
string save_path = "D:\\";
string name = "popopop";


HttpHelper.DownloadFileAsync(url, save_path + name);
Console.ReadKey();






//do
//{
//    //Console.WriteLine("Enter the path file:");
//    //string path = Console.ReadLine() ?? string.Empty;
//    //path = "D:\\257.csv";
//    //var t = new Stopwatch();
//    //t.Start();
//    //if (!File.Exists(path))
//    //{
//    //    Console.WriteLine("This path is not exist");
//    //    continue;
//    //}
//    //var fileData = new FileData(path);
//    //fileData.ReadAndWriteCsv();
//    //t.Stop();
//    //Console.WriteLine($"Read adn write finish t = {t.ElapsedMilliseconds}");
//    //Console.WriteLine("---------------------------------------------");

//} while (true);
#else
BenchmarkRunner.Run<DataBenchmarks>();
#endif


