using SUS.MvcFramework;
using System.Threading.Tasks;

namespace SharedTrip
{
    public class Program
    {
        public static async Task Main()
        {
            await Host.CreateHostAsync(new Startup(), 80);
        }
    }
}
