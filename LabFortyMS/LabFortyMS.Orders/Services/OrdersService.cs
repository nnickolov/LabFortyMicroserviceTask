using LabFortyMS.Common.Messages.Orders;
using LabFortyMS.Common.Services.Messages;
using LabFortyMS.Orders.Data;
using LabFortyMS.Orders.Data.Models;
using LabFortyMS.Orders.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LabFortyMS.Orders.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly OrdersDbContext _context;
        private readonly IPublisher _publisher;

        public OrdersService(OrdersDbContext context, IPublisher publisher)
        {
            _context = context;
            _publisher = publisher;
        }

        public async Task<int> CreateOrderAsync(int userId, OrderCreateRequestModel request)
        {
            var order = new Order
            {
                UserId = userId,
                Ticker = request.Ticker,
                Quantity = request.Quantity,
                Side = request.Side,
                Price = request.Price
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            // TODO: Add Outbox pattern

            var message = new OrderCreatedMessage
            {
                UserId = order.UserId,
                Ticker = order.Ticker,
                Quantity = order.Quantity,
                Price = order.Price
            };

            await _publisher.Publish(message);

            return order.Id;
        }
    }
}
