using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_work
{
    public class Record
    {
        public ushort Mcc { get; set; }

        public byte Net { get; set; }

        public ushort Area { get; set; }

        public uint Cell { get; set; }

        public double Lon { get; set; }

        public double Lat { get; set; }

        public Record()
        {
            this.Mcc = 0;
            this.Net = 0;
            this.Area = 0;
            this.Cell = 0;
            this.Lon = 0;
            this.Lat = 0;
        }
    }
}
