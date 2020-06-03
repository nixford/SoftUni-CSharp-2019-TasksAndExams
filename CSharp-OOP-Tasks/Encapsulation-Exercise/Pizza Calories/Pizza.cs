using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza
{
    public class Pizza
    {
		private string name;		
		private Dough dough;
		private Topping topping;
		private List<Topping> toppingsList;
		private decimal totalCalories;

		public Pizza(string name)
		{
			this.Name = name;
			this.Dough = dough;
			this.Topping = topping;
			this.toppingsList = new List<Topping>();
		}

		public string Name
		{
			get 
			{ 
				return this.name; 
			}
			set 
			{
				if (string.IsNullOrEmpty(value) || value.Length > 15)
				{
					throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
				}
				this.name = value; 
			}
		}

		public Dough Dough
		{
			get
			{
				return this.dough;
			}
			set
			{
				this.dough = value;
			}
		}

		public Topping Topping 
		{
			get
			{
				return this.topping;
			}
			set
			{
				this.topping = value;
			}
		}

		public List<Topping> ToppingsList
		{
			get 
			{ 
				return this.toppingsList; 
			}
			set 
			{ 
				this.toppingsList = value; 
			}
		}

		public decimal TotalCalories 
		{
			get
			{
				return this.totalCalories;
			}
			set
			{
				totalCalories = value;
			}
		}

		public void AddToppings(Topping topping)
		{
			if (toppingsList.Count <= 10)
			{
				toppingsList.Add(this.topping);
			}
			else
			{
				throw new ArgumentException("Number of toppings should be in range [0..10].");
			}			
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb
				.AppendLine($"{this.Name} - {this.TotalCalories:f2} Calories.");

			return sb.ToString().TrimEnd();
		}
	}
}
