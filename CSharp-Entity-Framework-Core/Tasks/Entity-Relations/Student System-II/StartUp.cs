using P03_FootballBetting.Data;
using System;

namespace P03_FootballBetting
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            FootballBettingContext fb = new FootballBettingContext();

            fb.Database.EnsureCreated();
        }
    }
}
