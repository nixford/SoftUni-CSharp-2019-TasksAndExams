using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services;
using System;
using System.Linq;
using System.Text;

namespace RealEstate.ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var db = new RealEstateDbContext();
            db.Database.Migrate();

            IPropertiesService propertiesService = new PropertiesService(db);

            Console.Write("Min price: ");
            int minPrice = int.Parse(Console.ReadLine());
            Console.Write("Max price: ");
            int maxPrice = int.Parse(Console.ReadLine());
            var properties = propertiesService.SearchByPrice(minPrice, maxPrice);
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.District}, fl. {property.Floor}");
            }

            Console.WriteLine(new string('-', 60));

            IDistrictService districtService = new DistrictService(db);
            var districts = districtService.GetTopDistrictsByAvaragePrice(10);
            foreach (var district in districts)
            {
                Console.WriteLine($"{district.Name} => Price: {district.AveragePrice:0.00} ({district.MinPrice}-{district.MaxPrice}) => {district.PropertiesCount} properties");
            }
        }
    }
}
