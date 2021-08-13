using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.App
{
    public interface IUserForm
    {
        int Id { get; }

        string Username { get; }

        string Password { get; }
    }
}
