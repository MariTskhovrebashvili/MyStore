using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.App
{
    public interface IEmployeeForm
    {
        int Id { get; }

        string FirstName { get; }

        string LastName { get; }

        string PersonalId { get; }

        string Phone { get; }

        string Email { get; }

        string HomeAddress { get; }

        DateTime? StartJob { get; }
    }
}
