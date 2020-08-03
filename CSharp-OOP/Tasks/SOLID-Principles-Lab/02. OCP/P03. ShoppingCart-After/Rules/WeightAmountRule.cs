using P03._ShoppingCart_After.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03._ShoppingCart_After.Rules
{
    public class WeightAmountRule : IAmountRules
    {
        decimal IAmountRules.Calcilate(OrderItem item)
        {
            // quantity is in grams, price is per kg
            return item.Quantity * 4m / 1000;
        }

        bool IAmountRules.IsMatch(OrderItem item)
        {
            return item.Sku.StartsWith("WEIGHT");
        }
    }
}
