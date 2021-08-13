using System;
using System.Data;
using System.Data.SqlClient;

namespace Store.Models
{
    public class Order : BaseModel<int>
    {
        public override int Id { get; set; }
        
        public int ProviderId { get; set; }
        
        public int UserId { get; set; }
        
        public DateTime? OrderDate { get; set; }
        
        public DateTime? RequiredDate { get; set; }
    }
}