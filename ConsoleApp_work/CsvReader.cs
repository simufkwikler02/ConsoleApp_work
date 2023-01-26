using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace ConsoleApp_work
{
    public class CsvReader
    {
        private readonly StreamReader reader;

        public CsvReader(StreamReader fstream)
        {
            this.reader = fstream;
        }

        public List<Record> ReadAll()
        {
            string? line;
            line = this.reader.ReadLine();
            int i = 0;
            List<Record> list = new List<Record>();
            while ((line = this.reader.ReadLine()) != null)
            {
                i++;
                try
                {
                    string[] parts = line.Split(',');
                    var record = new Record();
                    record.Radio = parts[0];
                    record.Mcc = int.Parse(parts[1], CultureInfo.InvariantCulture);
                    record.Net = int.Parse(parts[2], CultureInfo.InvariantCulture);
                    record.Area = int.Parse(parts[3], CultureInfo.InvariantCulture);
                    record.Cell = int.Parse(parts[4], CultureInfo.InvariantCulture);

                    IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
                    
                    record.Lon = double.Parse(parts[6], formatter);
                    record.Lat = double.Parse(parts[7], formatter);
                    list.Add(record);
                }
                catch
                {
                    Console.WriteLine($"line number {i} convert error,line skipped");
                    continue;
                }
            }

            return list;
        }
    }
}
