namespace SULS.App
{
    using SUS.MvcFramework;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main()
        {
            await Host.CreateHostAsync(new StartUp(), 80);
        }
    }
}