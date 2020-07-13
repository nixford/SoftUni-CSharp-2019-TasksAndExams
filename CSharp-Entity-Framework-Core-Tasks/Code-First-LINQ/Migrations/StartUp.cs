using P03_SalesDatabase.Data;
using System;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SalesContext sc = new SalesContext();

            sc.Database.EnsureCreated();
        }
    }
}
