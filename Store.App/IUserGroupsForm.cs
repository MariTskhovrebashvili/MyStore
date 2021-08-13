using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Permissions;

namespace Store.App
{
    public interface IUserGroupsForm
    {
        int Id { get; }

        UserPermissions GroupId { get; }

        bool Admin { get; }

        bool Cashier { get; }

        bool Manager { get; }

        bool SupplyManager { get; }
    }
}
