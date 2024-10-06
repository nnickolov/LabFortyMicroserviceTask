using LabFortyMS.Orders.Data;
using LabFortyMS.Orders.Data.Models;
using LabFortyMS.Orders.Services.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LabFortyMS.Orders.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly OrdersDbContext _context;

        public OrdersService(OrdersDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateOrderAsync(int userId, OrderCreateRequestModel request)
        {
            var order = new Order
            {
                UserId = userId,
                TickerId = request.TickerId,
                Quantity = request.Quantity,
                Side = request.Side,
            };

            // TODO: Add Price

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return order.Id;
        }

        public async Task<int> UpdatOrderAsync(int id, OrderUpdateRequestModel request)
        {
            var order = await _context
                .Orders
                .Include(o => o.Price)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                throw new InvalidOperationException($"Order with id '{id}' does not exist.");
            }

            order.Price.Buy = request.PriceBuy;
            order.Price.Sell = request.PriceSell;

            await _context.SaveChangesAsync();

            return order.Id;
        }
    }
}
