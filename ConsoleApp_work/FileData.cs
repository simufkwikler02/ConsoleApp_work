using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;


namespace ConsoleApp_work
{
    public class FileData
    {
        private string PathRead { get; set; }

        public  FileData(string path)
        {
            PathRead = path;
        }

        public void ReadAndWriteCsv()
        {
            if (!File.Exists(this.PathRead))
            {
                Console.WriteLine("ERROR read. This path is not exist");
                return;
            }


            using (StreamReader reader = new StreamReader(this.PathRead))
            {
                var pathWrite = Path.GetDirectoryName(PathRead);
                var nameRead = Path.GetFileName(PathRead);
                pathWrite = pathWrite + nameRead.Insert(0, "out_");

                using (StreamWriter writer = new StreamWriter(pathWrite, false))
                {
                    string? line;
                    int i = 0;
                    IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };

                    while ((line = reader.ReadLine()) != null)
                    {
                        i++;
                        try
                        {
                            var ind = line.IndexOf(',');
                            
                            if (!line.Substring(0, ind).Equals("GSM", StringComparison.InvariantCultureIgnoreCase))
                            {
                                continue;
                            }

                            var indBuf = ind;
                            ind = line.IndexOf(',', indBuf + 1);
                            var Mcc = ushort.Parse(line.Substring(indBuf + 1, ind - indBuf - 1), CultureInfo.InvariantCulture);
                            
                            indBuf = ind;
                            ind = line.IndexOf(',', indBuf + 1);
                            var Net = byte.Parse(line.Substring(indBuf + 1, ind - indBuf - 1), CultureInfo.InvariantCulture);

                            indBuf = ind;
                            ind = line.IndexOf(',', indBuf + 1);
                            var Area = ushort.Parse(line.Substring(indBuf + 1, ind - indBuf - 1), CultureInfo.InvariantCulture);

                            indBuf = ind;
                            ind = line.IndexOf(',', indBuf + 1);
                            var Cell = uint.Parse(line.Substring(indBuf + 1, ind - indBuf - 1), CultureInfo.InvariantCulture);

                            indBuf = ind;
                            ind = line.IndexOf(',', indBuf + 1);
                            indBuf = ind;
                            ind = line.IndexOf(',', indBuf + 1);
                            var Lon = double.Parse(line.Substring(indBuf + 1, ind - indBuf - 1), formatter);

                            indBuf = ind;
                            ind = line.IndexOf(',', indBuf + 1);
                            var Lat = double.Parse(line.Substring(indBuf + 1, ind - indBuf - 1), formatter);

                            writer.WriteLine($"{Mcc},{Net},{Area},{Cell},{Lon.ToString(formatter)},{Lat.ToString(formatter)}");
                        }
                        catch
                        {
                            Console.WriteLine($"line number {i} convert error,line skipped");
                            continue;
                        }
                    }
                }
            }
        }
    }
}
