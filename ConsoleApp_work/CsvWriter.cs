using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ConsoleApp_work
{
    public class CsvWriter
    {
        private readonly StreamWriter writer;

        public CsvWriter(StreamWriter fstream)
        {
            this.writer = fstream;
        }

        public void Write6(List<Record> records)
        {
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            this.writer.WriteLine("mcc,net,area,cell,lon,lat");
            foreach (var record in records)
            {
                if(record.Radio.Equals("GSM", StringComparison.InvariantCultureIgnoreCase))
                {
                    this.writer.WriteLine($"{record.Mcc},{record.Net},{record.Area},{record.Cell},{record.Lon.ToString(formatter)},{record.Lat.ToString(formatter)}");
                }
            }
        }
    }
}
