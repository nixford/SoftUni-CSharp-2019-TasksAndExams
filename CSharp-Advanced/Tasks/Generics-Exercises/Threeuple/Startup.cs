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
            string town = string.Empty;
            for (int i = 3; i < personInfo.Length; i++)
            {
                town += $"{personInfo[i]} ";
            }          

            string[] nameAndBeer = Console.ReadLine().Split().ToArray();
            string name = nameAndBeer[0];
            int beerAmount = int.Parse(nameAndBeer[1]);
            string drinkOrNot = nameAndBeer[2];
            bool isDrunk = false;
            if (drinkOrNot == "drunk")
            {
                isDrunk = true;
            }
            else if (drinkOrNot == "not")
            {
                isDrunk = false;
            }           

            string[] bankInfo = Console.ReadLine().Split().ToArray();
            string userName = bankInfo[0];
            double accountBalance = double.Parse(bankInfo[1]);
            string bankName = bankInfo[2];

            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>(fullName, adress, town);
            Threeuple<string, int, bool> secondTuple = new Threeuple<string, int, bool>(name, beerAmount, isDrunk);
            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(userName, accountBalance, bankName);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
