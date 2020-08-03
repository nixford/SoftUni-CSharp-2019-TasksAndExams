using P03._ShoppingCart_After.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03._ShoppingCart_After.Rules
{
    public class SpecialAmountRule : IAmountRules
    {
        decimal IAmountRules.Calcilate(OrderItem item)
        {
            // $0.40 each; 3 for $1.00
            decimal total = 0m;
            total += item.Quantity * .4m;
            int setsOfThree = item.Quantity / 3;
            total -= setsOfThree * .2m;

            return total;
        }

        bool IAmountRules.IsMatch(OrderItem item)
        {
            return item.Sku.StartsWith("SPECIAL");
        }
    }
}
