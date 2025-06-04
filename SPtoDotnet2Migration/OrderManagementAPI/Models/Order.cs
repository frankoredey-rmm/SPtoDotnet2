using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementAPI.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        
        [Required]
        public int CustomerID { get; set; }
        
        [Required]
        public DateTime OrderDate { get; set; }
        
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; } = null!;
        
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
