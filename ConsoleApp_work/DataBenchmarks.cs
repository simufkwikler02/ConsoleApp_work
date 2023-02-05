﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace ConsoleApp_work
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class DataBenchmarks
    {
        private string url = "https://drive.google.com/u/0/uc?id=11gltuDZucDoX_7W32o0MfVFAp9PXFkh9&export=download";
        private string save_path = "D:\\257.csv";

        [Benchmark]
        public async Task Foo1()
        {
            await Task.WhenAll(HttpHelper.DownloadFileAsync(url, save_path));

            if (!File.Exists(save_path))
            {
                Console.WriteLine("This path is not exist");
                return;
            }

            var fileData = new FileData(save_path);
            fileData.ReadAndWriteCsv();
        }
    }
}
