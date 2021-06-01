using System;
using System.Net.Http;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var hc = new HttpClient();
            Console.WriteLine(hc.GetStringAsync("https://ipv4.icanhazip.com/").Result);
        }
    }
}
