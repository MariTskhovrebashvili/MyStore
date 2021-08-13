using System;

namespace Store.Models
{
    public class Sell : BaseModel<int>
    {
        public override int Id { get; set; }
        
        public int UserId { get; set; }
        
        public DateTime? SellDate { get; set; }
    }
}