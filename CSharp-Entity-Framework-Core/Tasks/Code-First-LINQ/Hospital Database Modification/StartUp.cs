using P01_HospitalDatabase.Data;
using System;

namespace P01_HospitalDatabase
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HospitalContext hp = new HospitalContext();

            hp.Database.EnsureCreated();
        }
    }
}
