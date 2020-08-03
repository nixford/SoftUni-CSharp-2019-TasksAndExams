using System;

namespace P02._Worker_After
{
    public class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(new Worker());

            //Manager manager = new Manager(new HighPerformer());
        }
    }
}
