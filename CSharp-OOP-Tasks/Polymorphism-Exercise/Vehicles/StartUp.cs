using System;
using System.Linq;
using Vehicles.Core;
using Vehicles.Factories;
using Vehicles.IO;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader(); // FileReader();
            IWriter writer = new ConsoleWriter();
            IVehicleFactory vehicleFactory = new VehicleFactory();

            IEngine engine = new Engine(reader, writer, vehicleFactory);
            engine.Run();
        }
    }
}
