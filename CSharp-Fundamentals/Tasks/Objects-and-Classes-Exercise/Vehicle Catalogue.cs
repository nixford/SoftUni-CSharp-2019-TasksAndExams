using System;
using System.Collections.Generic;
using System.Linq;

public class Vehicle
{
    public Vehicle(){}
    public Vehicle(string type, string model, string color, int horsepower)
    {
      this.Type = type;
      this.Model= model;
      this.Color = color;
      this.Horsepower = horsepower;    
    }
    
 public string Type {get; set;}
 public string Model {get; set;}
 public string Color {get; set;}
 public int Horsepower {get; set;}
}
                    
public class Program
{
    public static void Main()
    {
      var orderVehiclkles = new List<Vehicle>();
        
        string inputPrim = null;
        
        while ((inputPrim = Console.ReadLine()) != "End")
        {
            string[] input = inputPrim
                .Split();

            orderVehiclkles.Add(new Vehicle(input[0], input[1], input[2], int.Parse(input[3])));        
        } // end while
        
        while ((inputPrim = Console.ReadLine()) != "Close the Catalogue")
        {        
          foreach (var kvp in orderVehiclkles)
          {
             if(kvp.Model == inputPrim)
             {
                var currnetVehicle = new Vehicle(kvp.Type, kvp.Model, kvp.Color, kvp.Horsepower);
                GetPrintTisVehickle(currnetVehicle);
                break;
             }
          } // first foreach
        } // end while
        
        decimal CarsHorsepower = 0;
        decimal TrucksHorsepower = 0;
        
         foreach (var kvp in orderVehiclkles)
          {
            if(kvp.Type == "car") 
            {
             CarsHorsepower += kvp.Horsepower;  
            }
            else
            {
             TrucksHorsepower += kvp.Horsepower;  
            }
            
          } // first foreach
        int n = orderVehiclkles.Where(s => s.Type == "car").Count();
        int x = orderVehiclkles.Where(s => s.Type == "truck").Count();
        if(n > 0)
        {
         CarsHorsepower = CarsHorsepower / n;    
         Console.WriteLine("Cars have average horsepower of: {0:0.00}.", CarsHorsepower);
        }
        else
        {
         Console.WriteLine("Cars have average horsepower of: 0.00.");
        }
        
        if (x > 0)
        {
         TrucksHorsepower = TrucksHorsepower / x;
         Console.WriteLine("Trucks have average horsepower of: {0:0.00}.", TrucksHorsepower);
        }
        else
        {
         Console.WriteLine("Trucks have average horsepower of: 0.00.");
        } // end dable if-else
        
    }
    
    public static void GetPrintTisVehickle(Vehicle currnetVehicle)
    {
        if(currnetVehicle.Type == "car")
        {
         Console.WriteLine("Type: Car"); 
        }
        else
        {
         Console.WriteLine("Type: Truck");     
        }
        
        Console.WriteLine("Model: {0}", currnetVehicle.Model); 
        Console.WriteLine("Color: {0}", currnetVehicle.Color);                  
        Console.WriteLine("Horsepower: {0}", currnetVehicle.Horsepower); 
    }                
}