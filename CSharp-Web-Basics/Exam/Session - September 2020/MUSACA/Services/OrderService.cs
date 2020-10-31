using Microsoft.EntityFrameworkCore;
using MUSACA.Data;
using MUSACA.Models;
using MUSACA.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MUSACA.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext context;

        public OrderService(ApplicationDbContext appDb)
        {
            this.context = appDb;
        }

        public bool AddProductToCurrentActiveOrder(string productId, string userId)
        {
            Product productFromDb = this.context.Products.SingleOrDefault(p => p.Id == productId);

            Order currentActiveOrder = this.GetCurrentActiveOrderByCashierId(userId);
            currentActiveOrder.Products.Add(new OrderProduct { Product = productFromDb });

            this.context.Update(currentActiveOrder);
            this.context.SaveChanges();

            return true;
        }

        public Order CompleteOrder(string orderId, string userId)
        {
            Order orderFromDb = this.context.Orders.SingleOrDefault(order => order.Id == orderId);

            orderFromDb.IssuedOn = DateTime.UtcNow;
            orderFromDb.Status = OrderStatus.Completed;

            this.context.Update(orderFromDb);
            this.context.SaveChanges();

            this.CreateOrder(new Order { CashierId = userId });

            return orderFromDb;
        }

        public Order CreateOrder(Order order)
        {
            this.context.Add(order);
            this.context.SaveChanges();

            return order;
        }

        public List<Order> GetAllCompletedOrdersByCashierId(string userId)
        => this.context.Orders
                .Include(order => order.Products)
                .ThenInclude(orderProduct => orderProduct.Product)
                .Include(order => order.Cashier)
                .Where(order => order.CashierId == userId)
                .Where(order => order.Status == OrderStatus.Completed)
                .ToList();

        public Order GetCurrentActiveOrderByCashierId(string userId)
            => this.context.Orders
                .Include(order => order.Products)
                .ThenInclude(orderProduct => orderProduct.Product)
                .Include(order => order.Cashier)
                .SingleOrDefault(order => order.CashierId == userId && order.Status == OrderStatus.Active);
    }
}
