using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models.DBModels;
using api.Models;
namespace api.Repositories.Dependencies
{
    public interface IOrderRepository
    {
        Task<int> Create(OrderModel model);
        Task<IEnumerable<OrderModel>> GetOrdersByUserId(int userId);
        Task<IEnumerable<ProductModel>> GetOrderItemsByOrderId(int orderId);
        Task<int> Update(OrderModel model);
    }
}