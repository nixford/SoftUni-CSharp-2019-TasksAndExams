using System;
using System.Collections.Generic;
using System.Text;

namespace Border
{
    public class Citizens : IObject
    {
        public Citizens(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }
        
    }
}
