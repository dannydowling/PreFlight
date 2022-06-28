using PreFlight_API.BLL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreFlight_API.BLL
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrderListAsync(int pageNumber, int pageSize);
        Task<Order> GetOrderAsync(Guid id);
        Task<Order> CreateOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Guid id);
    }
}
