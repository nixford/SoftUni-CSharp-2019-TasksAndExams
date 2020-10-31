using MUSACA.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MUSACA.Models
{
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Products = new HashSet<OrderProduct>();
        }

        public string Id { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Active;

        public DateTime IssuedOn { get; set; }

        public virtual ICollection<OrderProduct> Products { get; set; }

        [Required]
        public string CashierId { get; set; }
        public User Cashier { get; set; }
    }
}
