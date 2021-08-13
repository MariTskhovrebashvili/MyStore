using System.Data;
using System.Data.SqlClient;

namespace Store.Models
{
    public class Provider : BaseModel<int>
    {
        public override int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Phone { get; set; }
        
        public string Email { get; set; }
        
        public string Location { get; set; }
    }
}