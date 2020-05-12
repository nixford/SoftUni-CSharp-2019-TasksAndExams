using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<Tfirst, Tsecond>
    {
        public Tuple(Tfirst firstItem, Tsecond secondItem)
        {
            this.FirstItem = firstItem;
            this.SecondItem = secondItem;
        }
        public Tfirst FirstItem { get; set; }
        public Tsecond SecondItem { get; set; }

        public override string ToString()
        {
            return $"{this.FirstItem} -> {this.SecondItem}";
        }
    }
}
