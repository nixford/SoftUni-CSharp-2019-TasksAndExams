using P03._ShoppingCart_After.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03._ShoppingCart_After.Rules
{
    public class EachAmountRule : IAmountRules
    {
        public decimal Calcilate(OrderItem item)
        {
            return item.Quantity * 5m;
        }

        public bool IsMatch(OrderItem item)
        {
            return item.Sku.StartsWith("EACH");
        }
    }
}
