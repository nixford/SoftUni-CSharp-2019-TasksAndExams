using System;
using System.Collections.Generic;
using System.Text;

namespace Border
{
    public class Pet: IObject, IAliveCreatures
    {
        public Pet(string type, string name, string birthdate)
        {
            this.Type = type;
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }

        public string Birthdate { get; set; }
        public string Type { get; set; }
    }
}
