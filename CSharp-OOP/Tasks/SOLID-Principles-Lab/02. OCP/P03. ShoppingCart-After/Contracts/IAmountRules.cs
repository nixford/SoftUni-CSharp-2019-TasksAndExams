using System;
using System.Collections.Generic;
using System.Text;

namespace P03._ShoppingCart_After.Contracts
{
    public interface IAmountRules
    {
        decimal Calcilate(OrderItem item);

        bool IsMatch(OrderItem item);
    }
}
