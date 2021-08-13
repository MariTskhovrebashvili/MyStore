using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Employee : BaseModel<int>
    {
        public override int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalId { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string HomeAddress { get; set; }

        public DateTime? StartJob { get; set; }

        public DateTime? LeftJob { get; set; }

        public bool IsDeleted { get; set; }
    }
}
