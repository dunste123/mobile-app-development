using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShittyCSharpApp
{
    class WebStuff
    {
        private static HttpClient ClientDSte = new HttpClient();

        public static void InitDSte()
        {
            ClientDSte.DefaultRequestHeaders.Add("User-Agent", "Shitty C# app");
        }

        public static Stream GetStreamSyncDSte(string url)
        {
            return GetStreamDSte(url).GetAwaiter().GetResult();
        }

        public static async Task<Stream> GetStreamDSte(string url)
        {
            return await ClientDSte.GetStreamAsync(url);
        }

        public static Task<string> GetStringDSte(string url)
        {
            return ClientDSte.GetStringAsync(url);
        }
    }
}
