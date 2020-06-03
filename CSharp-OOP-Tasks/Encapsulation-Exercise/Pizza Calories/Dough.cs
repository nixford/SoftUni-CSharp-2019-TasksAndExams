using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza
{
	public class Dough
	{
		
		private decimal weight;
		private string flourType;
		private string bakingTechnique;

		public Dough(decimal weight, string flourType, string bakingTechnique)
		{
			this.Weight = weight;
			this.FlourType = flourType;
			this.BakingTechnique = bakingTechnique;
		}
		public decimal Weight
		{
			get 
			{ 
				return this.weight; 
			}
			private set 
			{
				if (value >= 1 && value <= 200)
				{
					this.weight = value;
				}
				else
				{
					throw new ArgumentException("Dough weight should be in the range [1..200].");
				}
			}
		}

		public string FlourType 
		{
			get
			{
				return this.flourType;
			}
			private set
			{
				if (value != "white" && value != "wholegrain")
				{
					throw new ArgumentException("Invalid type of dough.");					
				}
				this.flourType = value;
			}		
		}

		public string BakingTechnique 
		{
			get
			{
				return this.bakingTechnique;
			}
			private set
			{
				if (value != "crispy" && value != "chewy" && value != "homemade")
				{
					throw new ArgumentException("Invalid type of dough.");					
				}
				this.bakingTechnique = value;
			}			
		}

		public decimal GetCallories()
		{
			decimal result = 0;
			if (this.flourType == "white")
			{
				if (this.bakingTechnique == "crispy")
				{
					result = (2 * this.weight) * 1.5m * 0.9m;
				}
				else if (bakingTechnique == "chewy")
				{
					result = (2 * this.weight) * 1.5m * 1.1m;
				}
				else if (this.bakingTechnique == "homemade")
				{
					result = (2 * weight) * 1.5m * 1.0m;
				}
			}
			else if (this.flourType == "wholegrain")
			{
				if (this.bakingTechnique == "crispy")
				{
					result = (2 * this.weight) * 1.0m * 0.9m;
				}
				else if (this.bakingTechnique == "chewy")
				{
					result = (2 * this.weight) * 1.0m * 1.1m;
				}
				else if (this.bakingTechnique == "homemade")
				{
					result = (2 * this.weight) * 1.0m * 1.0m;
				}
			}
			return result;
		}
	}
}
