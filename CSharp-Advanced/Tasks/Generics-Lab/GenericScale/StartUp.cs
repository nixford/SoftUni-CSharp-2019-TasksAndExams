using System;

namespace GenericScale
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var scale = new EqualityScale<int>(5, 5);

            Console.WriteLine(scale.AreEqual(5,5));
        }
    }
}
