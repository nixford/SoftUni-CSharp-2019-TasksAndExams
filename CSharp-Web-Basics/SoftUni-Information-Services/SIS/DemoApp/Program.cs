using SIS.HTTP;
using System;
using System.Threading.Tasks;

namespace DemoApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpServer httpServer = new HttpServer(80);

            await httpServer.StartAsync();
        }
    }
}
