using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_work
{
    public class Record
    {
        public string? Radio { get; set; }

        public int Mcc { get; set; }

        public int Net { get; set; }

        public int Area { get; set; }

        public int Cell { get; set; }

        public int Unit { get; set; }

        public double Lon { get; set; }

        public double Lat { get; set; }

        public int Range { get; set; }

        public int Samples { get; set; }

        public int Changeable { get; set; }

        public long Created { get; set; }
        
        public long Updated { get; set; }

        public int AverageSignal { get; set; }

        public Record()
        {
            this.Radio = String.Empty;
            this.Mcc = 0;
            this.Net = 0;
            this.Area = 0;
            this.Cell = 0;
            this.Unit = 0;
            this.Lon = 0;
            this.Lat = 0;
            this.Range = 0;
            this.Samples = 0;
            this.Changeable = 0;
            this.Created = 0;
            this.Updated = 0;
            this.AverageSignal = 0;
        }
    }
}
