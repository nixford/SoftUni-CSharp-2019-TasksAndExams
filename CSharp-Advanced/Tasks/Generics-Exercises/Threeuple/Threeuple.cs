using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Threeuple<Tfirst, Tsecond, Tthird>
    {
        public Threeuple(Tfirst firstItem, Tsecond secondItem, Tthird thirdItem)
        {
            this.FirstItem = firstItem;
            this.SecondItem = secondItem;
            this.ThirdItem = thirdItem;
        }
        public Tfirst FirstItem { get; set; }
        public Tsecond SecondItem { get; set; }
        public Tthird ThirdItem { get; set; }
        public override string ToString()
        {
            return $"{this.FirstItem} -> {this.SecondItem} -> {this.ThirdItem}";
        }
    }
}