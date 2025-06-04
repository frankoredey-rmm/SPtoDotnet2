using OrderManagementAPI.DTOs;

namespace OrderManagementAPI.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetOrdersByCustomerEmailAsync(string email);
        Task<int> InsertOrderAsync(CreateOrderDto orderDto);
        Task<bool> DeleteOrderByIdAsync(int orderId);
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
    }
}
