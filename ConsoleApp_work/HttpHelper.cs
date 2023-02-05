using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_work
{
    public static class HttpHelper
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task DownloadFileAsync(string uri, string outputPath)
        {
            Uri uriResult;

            if (!Uri.TryCreate(uri, UriKind.Absolute, out uriResult))
                throw new InvalidOperationException("URI is invalid.");

            

            var response = await _httpClient.GetAsync(uriResult);
            var bt = await response.Content.ReadAsStringAsync();
            using var writer = File.CreateText(outputPath);
            writer.Write(bt);
            Console.WriteLine("OK");
        }
    }
}
