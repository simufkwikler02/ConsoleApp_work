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
            
            using var reader = File.OpenText(this.PathRead);

            var pathWrite = Path.GetDirectoryName(PathRead);
            var nameRead = Path.GetFileName(PathRead);
            pathWrite = pathWrite + nameRead.Insert(0, "out_");

            using var writer = File.CreateText(pathWrite);

                
            string? line;
            int i = 0;
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            var resultLine = new StringBuilder();

            while ((line = reader.ReadLine()) != null)
            {
                resultLine.Clear();
                i++;
                
                var lineSpan = line.AsSpan();
                var ind = line.IndexOf(Separator);
                if (ind == -1)
                    continue;

                var firstLine = lineSpan.Slice(0, ind);
                if (!(firstLine[0] == 'G' && firstLine[1] == 'S' && firstLine[2] == 'M'))
                    continue;
                

                var indBuf = ind;
                ind = line.IndexOf(Separator, indBuf + 1);
                if (ind == -1)
                    continue;

                ushort Mcc;
                if (!ushort.TryParse(lineSpan.Slice(indBuf + 1, ind - indBuf - 1), out Mcc))
                {
                    Console.WriteLine($"line number {i} convert error,line skipped");
                    continue;
                }
                   
                            
                indBuf = ind;
                ind = line.IndexOf(Separator, indBuf + 1);
                if (ind == -1)
                    continue;

                byte Net;
                if (!byte.TryParse(lineSpan.Slice(indBuf + 1, ind - indBuf - 1), out Net))
                {
                    Console.WriteLine($"line number {i} convert error,line skipped");
                    continue;
                }


                indBuf = ind;
                ind = line.IndexOf(Separator, indBuf + 1);
                if (ind == -1)
                    continue;

                ushort Area;
                if (!ushort.TryParse(lineSpan.Slice(indBuf + 1, ind - indBuf - 1), out Area))
                {
                    Console.WriteLine($"line number {i} convert error,line skipped");
                    continue;
                }


                indBuf = ind;
                ind = line.IndexOf(Separator, indBuf + 1);
                if (ind == -1)
                    continue;

                uint Cell;
                if (!uint.TryParse(lineSpan.Slice(indBuf + 1, ind - indBuf - 1), out Cell))
                {
                    Console.WriteLine($"line number {i} convert error,line skipped");
                    continue;
                }

                indBuf = ind;
                ind = line.IndexOf(Separator, indBuf + 1);
                if (ind == -1)
                    continue;

                indBuf = ind;
                ind = line.IndexOf(Separator, indBuf + 1);
                if (ind == -1)
                    continue;

                double Lon;
                if (!double.TryParse(lineSpan.Slice(indBuf + 1, ind - indBuf - 1), NumberStyles.Float, formatter, out Lon))
                {
                    Console.WriteLine($"line number {i} convert error,line skipped");
                    continue;
                }

                indBuf = ind;
                ind = line.IndexOf(Separator, indBuf + 1);
                if (ind == -1)
                    continue;

                double Lat;
                if (!double.TryParse(lineSpan.Slice(indBuf + 1, ind - indBuf - 1), NumberStyles.Float, formatter, out Lat))
                {
                    Console.WriteLine($"line number {i} convert error,line skipped");
                    continue;
                }

                    
                resultLine.Append(Mcc).Append(',');
                resultLine.Append(Net).Append(',');
                resultLine.Append(Area).Append(',');
                resultLine.Append(Cell).Append(',');
                resultLine.Append(Lon.ToString(formatter)).Append(',');
                resultLine.Append(Lat.ToString(formatter)).AppendLine();
                writer.Write(resultLine);
            }

            Console.WriteLine($"Save to {pathWrite}");
        }
    }
}
