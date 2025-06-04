using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementAPI.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemID { get; set; }
        
        [Required]
        public int OrderID { get; set; }
        
        [Required]
        public int ProductID { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; } = null!;
        
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; } = null!;
    }
}
