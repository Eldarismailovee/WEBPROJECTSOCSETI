using System.ComponentModel.DataAnnotations;

namespace Store2.Domain
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price() => (Product.Price * Quantity);
        public Product Product { get; set; }
    }
}
