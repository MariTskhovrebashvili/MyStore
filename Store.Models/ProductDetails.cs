using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class ProductDetails : BaseModel<int>
    {
        public override int Id { get; set; }

        public DateTime? Valid { get; set; }

        public int Quantity { get; set; } 
    }
}
