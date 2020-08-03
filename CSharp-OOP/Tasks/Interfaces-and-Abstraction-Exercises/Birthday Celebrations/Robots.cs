using System;
using System.Collections.Generic;
using System.Text;

namespace Border
{
    public class Robots : IObject ,IHumanLike
    {
        public Robots(string type, string model, string id)
        {
            this.Type = type;
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }

        public string Id { get; set; }
        public string Type { get; set; }
    }
}
