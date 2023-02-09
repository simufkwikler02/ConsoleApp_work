using System;
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
        private string url = "https://vk.com/doc167552191_659635597?hash=ac787D3lBhREUIqwLeZT5px3AIDPc6Cv1G02z8t8zQT&dl=BBoKYqPxbO5iAGwqTLBHK8uESEMNcamlv3qJozQU5eL";
        private string save_path = "D:\\";

        [Benchmark]
        public async Task Foo1()
        {
            if (!Directory.Exists(save_path))
            {
                Console.WriteLine("This path is not exist");
                return;
            }

            var fileData = new FileData();
            await fileData.DownloadAndSaveCsv(url, save_path);
        }
    }
}
