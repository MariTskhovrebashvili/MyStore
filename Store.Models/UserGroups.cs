using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Permissions;

namespace Store.Models
{
    public class UserGroups : BaseModel<int>
    {
        public override int Id { get; set; }

        public UserPermissions GroupId { get; set; }
    }
}
