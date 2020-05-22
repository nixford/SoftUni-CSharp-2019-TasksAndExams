using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Point_in_Rectangle
{
    public class Rectangle
    {
        
        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;
        }
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public bool Contains(Point point)
        {
            return this.TopLeft.X <= point.X && this.BottomRight.X >= point.X && 
                this.TopLeft.Y <= point.Y && this.BottomRight.Y >= point.Y;
        }
    }
}
