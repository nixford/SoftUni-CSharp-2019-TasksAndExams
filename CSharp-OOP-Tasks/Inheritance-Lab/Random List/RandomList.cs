using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Random_List
{
    public class RandomList : List<string>
    {
        private Random random = new Random();
        public string RandomElement()
        {
            int index = random.Next(0, this.Count);
            string element = this[index];           
            return element;
        }
        public string RemoveRandom()
        {
            int index = random.Next(0, this.Count);
            string element = this[index];
            this.RemoveAt(index);
            return element;
        }
    }
}
