using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.Data;
using OrderManagementAPI.DTOs;
using OrderManagementAPI.Models;

namespace OrderManagementAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderManagementContext _context;
        
        public OrderService(OrderManagementContext context)
        {
            _context = context;
        }
        
        // Migrated from GetOrdersByCustomerEmail stored procedure
        public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerEmailAsync(string email)
        {
            var orders = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .Where(o => o.Customer.Email == email)
                .OrderByDescending(o => o.OrderDate)
                .Select(o => new OrderDto
                {
                    OrderID = o.OrderID,
                    CustomerName = o.Customer.Name,
                    CustomerEmail = o.Customer.Email,
                    OrderDate = o.OrderDate,
                    OrderItems = o.OrderItems.Select(oi => new OrderItemDto
                    {
                        ProductName = oi.Product.ProductName,
                        Quantity = oi.Quantity
                    }).ToList()
                })
                .ToListAsync();
                
            return orders;
        }
        
        // Migrated from InsertOrder stored procedure
        public async Task<int> InsertOrderAsync(CreateOrderDto orderDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            
            try
            {
                // Get or create customer
                var customer = await _context.Customers
                    .FirstOrDefaultAsync(c => c.Email == orderDto.CustomerEmail);
                    
                if (customer == null)
                {
                    customer = new Customer
                    {
                        Name = orderDto.CustomerName,
                        Email = orderDto.CustomerEmail
                    };
                    _context.Customers.Add(customer);
                    await _context.SaveChangesAsync();
                }
                
                // Get or create product
                var product = await _context.Products
                    .FirstOrDefaultAsync(p => p.ProductName == orderDto.ProductName);
                    
                if (product == null)
                {
                    product = new Product
                    {
                        ProductName = orderDto.ProductName
                    };
                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();
                }
                
                // Create order
                var order = new Order
                {
                    CustomerID = customer.CustomerID,
                    OrderDate = orderDto.OrderDate
                };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                
                // Create order item
                var orderItem = new OrderItem
                {
                    OrderID = order.OrderID,
                    ProductID = product.ProductID,
                    Quantity = orderDto.Quantity
                };
                _context.OrderItems.Add(orderItem);
                await _context.SaveChangesAsync();
                
                await transaction.CommitAsync();
                return order.OrderID;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        
        // Migrated from DeleteOrderById stored procedure
        public async Task<bool> DeleteOrderByIdAsync(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.OrderID == orderId);
                
            if (order == null)
                return false;
                
            _context.OrderItems.RemoveRange(order.OrderItems);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            
            return true;
        }
        
        // Migrated from GetAllOrders stored procedure
        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .Select(o => new OrderDto
                {
                    OrderID = o.OrderID,
                    CustomerName = o.Customer.Name,
                    CustomerEmail = o.Customer.Email,
                    OrderDate = o.OrderDate,
                    OrderItems = o.OrderItems.Select(oi => new OrderItemDto
                    {
                        ProductName = oi.Product.ProductName,
                        Quantity = oi.Quantity
                    }).ToList()
                })
                .ToListAsync();
                
            return orders;
        }
    }
}
