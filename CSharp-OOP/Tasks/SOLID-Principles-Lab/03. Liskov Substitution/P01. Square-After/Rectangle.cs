using System;
using System.Collections.Generic;
using System.Text;

namespace P01._Square_After
{
    public class Rectangle : Shape
    {
        public virtual double Width { get; set; }

        public virtual double Height { get; set; }

        public override double Area => this.Width * this.Height;
    }
}
