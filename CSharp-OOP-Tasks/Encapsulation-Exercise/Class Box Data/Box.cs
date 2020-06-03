using LanguageExt.UnitsOfMeasure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Box_Data
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Length 
        {
            get
            {
                return this.length; 
            }
            private set
            {
                if (value > 0)
                {
                    this.length = value;
                }
                else
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                
            }
        }
       
        public double Width 
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }                
            }
        }
      
        public double Height 
        { 
            get
            {
                return this.height;
            }
            private set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }                
            }
        }
        
        
        public void GetSurfaceArea(Box box)
        {
            Console.WriteLine($"Surface Area - {(2 * this.length * this.width) + (2 * this.length * this.height) + (2 * this.width * this.height):f2}");  
        }

        public void GetLateralSurfaceArea(Box box)
        {
            Console.WriteLine($"Lateral Surface Area - {(2 * this.length * this.height) + (2 * this.width * this.height):f2}"); 
        }
             
        public void GetVolume(Box box)
        {
            Console.WriteLine($"Volume - {(this.length * this.width * this.height):f2}"); 
        }
    }
}
