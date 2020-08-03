using System;
using System.Collections.Generic;
using System.Text;

namespace Border
{
    public class Citizens : IObject, IHumanLike, IAliveCreatures, IBuyer
    {
        public Citizens(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }

        public string Birthdate { get; set; }
        public string Type { get; set; }
        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
