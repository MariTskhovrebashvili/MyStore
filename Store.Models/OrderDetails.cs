using System;

namespace Store.Models
{
    public class OrderDetails : BaseModel<int>
    {
        public override int Id { get; set; }

        public int ProductId { get; set; }
        
        public decimal UnitPrice { get; set; }
        
        public int Quantity { get; set; }
        
        public DateTime? ProvideDate { get; set; }

        public DateTime? Valid { get; set; }
    }
}