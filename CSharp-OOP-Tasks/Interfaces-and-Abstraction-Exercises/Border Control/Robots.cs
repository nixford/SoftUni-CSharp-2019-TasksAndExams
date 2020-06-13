using System;
using System.Collections.Generic;
using System.Text;

namespace Border
{
    public class Robots : IObject
    {
        public Robots(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }

        public string Id { get; set; }
    }
}
