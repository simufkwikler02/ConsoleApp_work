using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_work
{
    public class FileData
    {
        public string Path { get; set; }
        private List<Record> list = new List<Record>();

        public  FileData(string path)
        {
            Path = path;
        }

        public void ReadAll()
        {
            if (!File.Exists(this.Path))
            {
                Console.WriteLine("ERROR READ. This path is not exist");
                return;
            }

            using (StreamReader reader = new StreamReader(this.Path))
            {
                var cvReader = new CsvReader(reader);
                this.list = cvReader.ReadAll();
            }
        }
        public void Write6()
        {
            var pathWrite = "D:\\result.csv";

            using (StreamWriter writer = new StreamWriter(pathWrite, false))
            {
                var cvReader = new CsvWriter(writer);
                cvReader.Write6(list);
            }
        }

        public void DeleteAll()
        {
            using (StreamReader reader = new StreamReader(this.Path))
            {
                var cvReader = new CsvReader(reader);
                this.list.Clear();
            }
        }

    }
}
