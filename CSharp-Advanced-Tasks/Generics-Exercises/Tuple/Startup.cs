using System;
using System.Linq;

namespace Tuple
{
    class Startup
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split().ToArray();
            string fullName = $"{personInfo[0]} {personInfo[1]}";
            string adress = $"{personInfo[2]}";

            string[] nameAndBeer = Console.ReadLine().Split().ToArray();
            string name = nameAndBeer[0];
            int beerAmount = int.Parse(nameAndBeer[1]);

            string[] thirdInput = Console.ReadLine().Split().ToArray();
            int firstArg = int.Parse(thirdInput[0]);
            double secondArgs = double.Parse(thirdInput[1]);

            Tuple<string, string> firstTuple = new Tuple<string, string>(fullName, adress);
            Tuple<string, int> secondTuple = new Tuple<string, int>(name, beerAmount);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(firstArg, secondArgs);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
