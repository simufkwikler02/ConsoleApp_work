using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

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
                    if (!parts[0].Equals("GSM", StringComparison.InvariantCultureIgnoreCase))
                    {
                        continue;
                    }
                    var record = new Record();
                    record.Mcc = ushort.Parse(parts[1], CultureInfo.InvariantCulture);
                    record.Net = byte.Parse(parts[2], CultureInfo.InvariantCulture);
                    record.Area = ushort.Parse(parts[3], CultureInfo.InvariantCulture);
                    record.Cell = uint.Parse(parts[4], CultureInfo.InvariantCulture);

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
