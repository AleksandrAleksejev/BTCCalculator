using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace BTSCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            BTCrate bitcoin = GetRates();

            Console.WriteLine($"Current rate in{bitcoin.bpi.USD.code}: {bitcoin.bpi.USD.rate_float}");
            Console.WriteLine($"Current rate in{bitcoin.bpi.EUR.code}: {bitcoin.bpi.EUR.rate_float}");
            Console.WriteLine($"Current rate in{bitcoin.bpi.GBP.code}: {bitcoin.bpi.GBP.rate_float}");
        }

        public static BTCrate GetRates()
        {
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            BTCrate bitcoin;

            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                bitcoin = JsonConvert.DeserializeObject<BTCrate>(response);

            }
            return bitcoin; 
        }
    }
}
