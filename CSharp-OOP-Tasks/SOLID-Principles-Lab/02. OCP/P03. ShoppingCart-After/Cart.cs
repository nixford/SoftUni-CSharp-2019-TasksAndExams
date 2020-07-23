namespace P03._ShoppingCart_After
{
    using P03._ShoppingCart_After.Contracts;
    using P03._ShoppingCart_After.Rules;
    using System.Collections.Generic;
    using System.Linq;

    public class Cart
    {
        private readonly List<OrderItem> items;

        public Cart()
        {
            this.items = new List<OrderItem>();
        }

        public IEnumerable<OrderItem> Items
        {
            get { return new List<OrderItem>(this.items); }
        }

        public string CustmerEmail { get; set; }

        public void Add(OrderItem orderItem)
        {
            this.items.Add(orderItem);
        }

        public decimal TotalAmount()
        {
            decimal total = 0m;
            List<IAmountRules> rules = new List<IAmountRules>()
            {
                new EachAmountRule(),
                new WeightAmountRule(),
                new SpecialAmountRule()
            };

            foreach (var item in this.items)
            {
                total += rules.First(r => r.IsMatch(item)).Calcilate(item);
            }

            return total; 
        }
    }
}
