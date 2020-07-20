using P01._DrawingShape_After.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01._DrawingShape_After
{
    public class Rectangle : IShape
    {
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Area
        {
            get { return this.Width * this.Height; }
        }        
    }
}
