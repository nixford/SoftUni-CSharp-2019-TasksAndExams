using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossroads
{
    class Crossroads
    {
        static void Main(string[] args)
        {
            int greenLightIntervall = int.Parse(Console.ReadLine());
            int freeWindowInterval = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            bool crash = false;
            string crashedCar = string.Empty;
            int hitIndex = -1;

            int totalCarsPassed = 0;

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                int currGreenLight = greenLightIntervall;

                if (command == "green")
                {
                    while (currGreenLight > 0 && cars.Any())
                    {
                        string currentCar = cars.Peek();
                        int carLength = currentCar.Length;
                        
                        if (carLength <= currGreenLight)
                        {
                            currGreenLight -= carLength;
                            cars.Dequeue();
                            totalCarsPassed++;
                        }
                        else
                        {
                            carLength -= currGreenLight;

                            if (carLength <= freeWindowInterval)
                            {
                                cars.Dequeue();
                                totalCarsPassed++;
                            }
                            else
                            {
                                crash = true;
                                crashedCar = currentCar;
                                hitIndex = currGreenLight + freeWindowInterval;
                                break;
                            }                            
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }

                if (crash)
                {
                    break;
                }
            }
            if (crash)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{crashedCar} was hit at {crashedCar[hitIndex]}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
            }
        }
    }
}
