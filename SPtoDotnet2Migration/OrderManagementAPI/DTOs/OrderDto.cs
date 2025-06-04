using System.ComponentModel.DataAnnotations;

namespace OrderManagementAPI.DTOs
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
    
    public class OrderItemDto
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
    
    public class CreateOrderDto
    {
        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string CustomerEmail { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; } = string.Empty;
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }
        
        [Required]
        public DateTime OrderDate { get; set; }
    }
}
