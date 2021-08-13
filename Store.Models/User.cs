using System;
using System.Data;
using System.Data.SqlClient;

namespace Store.Models
{
    public class User : BaseModel<int>
    {
        public override int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
