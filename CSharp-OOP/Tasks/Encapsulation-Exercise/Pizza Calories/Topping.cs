using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizza
{
    public class Topping
    {	

		private decimal weight;
		private string toppingType;

		public Topping(decimal weight, string toppingType)
		{			
			this.ToppingType = toppingType;
			this.Weight = weight;
		}
		public string ToppingType 
		{ 
			get
			{
				return this.toppingType;
			}
			private set
			{
				if (value != "meat" && value != "veggies" && 
					value != "cheese" && value != "sauce")
				{
					throw new ArgumentException($"Cannot place {value.First().ToString().ToUpper() + value.Substring(1)} on top of your pizza.");
				}
				this.toppingType = value;
			}
		}

		public decimal Weight
		{
			get 
			{ 
				return this.weight; 
			}
			private set 
			{
				if (value >= 1 && value <= 50)
				{
					this.weight = value;
				}
				else
				{
					throw new ArgumentException($"{this.toppingType.First().ToString().ToUpper() + this.toppingType.Substring(1)} weight should be in the range [1..50].");
				}
			}
		}
		
		public decimal GetCalloriesForTopping()
		{
			decimal result = 0;
			if (this.toppingType == "meat")
			{
				result = (2 * this.weight) * 1.2m;
			}
			else if (this.toppingType == "veggies")
			{
				result = (2 * this.weight) * 0.8m;
			}
			else if (this.toppingType == "cheese")
			{
				result = (2 * weight) * 1.1m;
			}
			else if (this.toppingType == "sauce")
			{
				result = (2 * weight) * 0.9m;
			}

			return result;
		}
	}
}
