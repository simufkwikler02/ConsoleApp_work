using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;


namespace ConsoleApp_work
{
    public class FileData
    {
        private string PathRead { get; set; }
        private char Separator = ',';

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
                            var lineSpan = line.AsSpan();
                            var ind = line.IndexOf(Separator);
                            if (ind == -1)
                                continue;

                            var firstLine = lineSpan.Slice(0, ind);
                            if (!(firstLine[0] == 'G' && firstLine[1] == 'S' && firstLine[2] == 'M'))
                            {
                                continue;
                            }

                            var indBuf = ind;
                            ind = line.IndexOf(Separator, indBuf + 1);
                            if (ind == -1)
                                continue;

                            var Mcc = ushort.Parse(lineSpan.Slice(indBuf + 1, ind - indBuf - 1));
                            
                            indBuf = ind;
                            ind = line.IndexOf(Separator, indBuf + 1);
                            if (ind == -1)
                                continue;

                            var Net = byte.Parse(lineSpan.Slice(indBuf + 1, ind - indBuf - 1));

                            indBuf = ind;
                            ind = line.IndexOf(Separator, indBuf + 1);
                            if (ind == -1)
                                continue;

                            var Area = ushort.Parse(lineSpan.Slice(indBuf + 1, ind - indBuf - 1));

                            indBuf = ind;
                            ind = line.IndexOf(Separator, indBuf + 1);
                            if (ind == -1)
                                continue;

                            var Cell = uint.Parse(lineSpan.Slice(indBuf + 1, ind - indBuf - 1));

                            indBuf = ind;
                            ind = line.IndexOf(Separator, indBuf + 1);
                            if (ind == -1)
                                continue;

                            indBuf = ind;
                            ind = line.IndexOf(Separator, indBuf + 1);
                            if (ind == -1)
                                continue;

                            var Lon = double.Parse(lineSpan.Slice(indBuf + 1, ind - indBuf - 1), NumberStyles.Float, formatter);

                            indBuf = ind;
                            ind = line.IndexOf(Separator, indBuf + 1);
                            if (ind == -1)
                                continue;

                            var Lat = double.Parse(lineSpan.Slice(indBuf + 1, ind - indBuf - 1), NumberStyles.Float, formatter);

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
