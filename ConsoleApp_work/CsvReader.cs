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
            int i = 1;
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
                    record.Unit = int.Parse(parts[5], CultureInfo.InvariantCulture);

                    IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
                    
                    record.Lon = double.Parse(parts[6], formatter);
                    record.Lat = double.Parse(parts[7], formatter);
                    record.Range = int.Parse(parts[8], CultureInfo.InvariantCulture);
                    record.Samples = int.Parse(parts[9], CultureInfo.InvariantCulture);
                    record.Changeable = int.Parse(parts[10], CultureInfo.InvariantCulture);
                    record.Created = long.Parse(parts[11], CultureInfo.InvariantCulture);
                    record.Updated = long.Parse(parts[12], CultureInfo.InvariantCulture);
                    record.AverageSignal = int.Parse(parts[13], CultureInfo.InvariantCulture);
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
