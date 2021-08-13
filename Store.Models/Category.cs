using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Store.Models
{
    public class Category : BaseModel<int>
    {
        public override int Id { get; set; }
        
        public string Name { get; set; }
    }
}