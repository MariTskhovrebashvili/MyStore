using System.Data.SqlClient;
using System.Data;

namespace Store.Models
{
    public class Product : BaseModel<int>
    {
        public override int Id { get; set; }
        
        public int CategoryId { get; set; }
        
        public string Name { get; set; }
        
        public decimal Price { get; set; }
        
        public bool IsDeleted { get; set; }
    }
}