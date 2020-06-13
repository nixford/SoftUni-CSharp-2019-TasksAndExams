using System;
using System.Collections.Generic;
using System.Text;

namespace Border
{
    public class Citizens : IObject, IHumanLike, IAliveCreatures
    {
        public Citizens(string type, string name, int age, string id, string birthdate)
        {
            this.Type = type;
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
    }
}
