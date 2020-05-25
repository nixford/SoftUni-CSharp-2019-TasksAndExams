using System;
using System.Collections.Generic;
using System.Text;

namespace P02_CarsSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private double? weight;
        private string color;
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, double weight)
            : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, double weight, string color)
            : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return this.engine;
            }
            set
            {
                this.engine = value;
            }
        }

        public double? Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string weinghtStr = this.Weight.HasValue ?
                this.Weight.ToString() : "n/a";
            string colorStr = String.IsNullOrEmpty(this.Color) ?
                "n/a" : this.Color;
            sb
                .AppendLine($"{this.Model}:")
                .AppendLine($"  {this.Engine}")
                .AppendLine($"  Weight: {weinghtStr}")
                .AppendLine($"  Color: {colorStr}");

            return sb.ToString().TrimEnd();
        }
    }
}
