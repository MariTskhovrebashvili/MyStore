using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.App
{
    public interface ICategoryForm
    {
        int Id { get; }

        string CategoryName { get; }
    }
}
