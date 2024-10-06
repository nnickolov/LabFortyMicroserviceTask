using LabFortyMS.Orders.Services.Models;
using System.Threading.Tasks;

namespace LabFortyMS.Orders.Services
{
    public interface IOrdersService
    {
        Task<int> CreateOrderAsync(int userId, OrderCreateRequestModel request);

        Task<int> UpdatOrderAsync(int id, OrderUpdateRequestModel request);
    }
}
