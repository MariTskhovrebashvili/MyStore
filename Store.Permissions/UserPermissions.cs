using System;

namespace Store.Permissions
{
    [Flags]
    public enum UserPermissions
    {
        Admin = 1,
        Cashier = 2,
        Manager = 4,
        SupplyManager = 8
    }
}
