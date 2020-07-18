using System;

namespace Square_Root
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    int n;

                    bool validNumber = int.TryParse(Console.ReadLine(), out n);

                    if (!validNumber)
                    {
                        throw new ArgumentException("Invalid number");
                    }

                    if (n < 0)
                    {
                        throw new ArithmeticException("Invalid number");
                    }

                    double x = Math.Sqrt(n);
                    Console.WriteLine("{0:F2}", x);
                    break;
                }
                catch (ArithmeticException ae)
                {
                    Console.Error.WriteLine(ae.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                finally
                {
                    Console.WriteLine("Finally block executed!");
                }
            }
            Console.WriteLine("Good bye");
        }
    }
}
