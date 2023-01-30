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
        private const string path = "D:\\257.csv";

        [Benchmark]
        public void Foo1()
        {
            var fileData = new FileData(path);
            fileData.ReadAndWriteCsv();
        }
    }
}
