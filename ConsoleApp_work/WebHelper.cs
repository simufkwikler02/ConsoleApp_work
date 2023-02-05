using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ConsoleApp_work
{
    public static class WebHelper
    {
        private static readonly WebClient _webClient = new WebClient();

        public static async void DownloadFileAsync(string uri, string outputPath)
        {
            Uri uriResult;

            if (!Uri.TryCreate(uri, UriKind.Absolute, out uriResult))
                throw new InvalidOperationException("URI is invalid.");


            var bt = await _webClient.DownloadDataTaskAsync(uriResult);
            File.Create(outputPath);
            //File.WriteAllBytes(outputPath, fileBytes);
        }
    }
}
