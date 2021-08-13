namespace Store.Models
{
    public class SellDetails : BaseModel<int>
    {
        public override int Id { get; set; }
        
        public int ProductId { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal UnitPrice { get; set; }
        
        public decimal Discount { get; set; }
    }
}