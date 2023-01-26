using System;
using System.Collections.Generic;
using System.Text;


namespace ConsoleApp_work
{
    public class FileData
    {
        private string PathRead { get; set; }
        private List<Record> list = new List<Record>();

        public  FileData(string path)
        {
            PathRead = path;
        }

        public void ReadAll()
        {
            if (!File.Exists(this.PathRead))
            {
                Console.WriteLine("ERROR read. This path is not exist");
                return;
            }

            using (StreamReader reader = new StreamReader(this.PathRead))
            {
                var cvReader = new CsvReader(reader);
                this.list = cvReader.ReadAll();
            }
        }
        public void Write6()
        {
            var pathWrite = Path.GetDirectoryName(PathRead);
            if (!Directory.Exists(pathWrite))
            {
                Console.WriteLine("ERROR write. This directory is not exist");
                return;
            }

            var nameRead = Path.GetFileName(PathRead);
            pathWrite = pathWrite + nameRead.Insert(nameRead.LastIndexOf("."), "_out");

            using (StreamWriter writer = new StreamWriter(pathWrite, false))
            {
                var cvReader = new CsvWriter(writer);
                cvReader.Write6(list);
            }
        }

        public void DeleteAll()
        {    
            this.list.Clear();   
        }

    }
}
