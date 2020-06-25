using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        List<Present> data;

        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.data = new List<Present>();
        }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }       

        public string Color { get; set; }

        public int Capacity { get; set; }

        public void Add(Present present)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            if (this.data.Any(p => p.Name == name))
            {
                this.data.RemoveAll(p => p.Name == name);
                return true;
            }
            return false;
        }

        public Present GetHeaviestPresent()
        {
            Present present = this.data.OrderByDescending(p => p.Weight).FirstOrDefault();
            return present;
        }

        public Present GetPresent(string name)
        {
            Present present = this.data.FirstOrDefault(p => p.Name == name);
            return present;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb
            .AppendLine($"{this.Color} bag contains:");

            foreach (Present present in data)
            {
                sb
                    .AppendLine($"{present}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
