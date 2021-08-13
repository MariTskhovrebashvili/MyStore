using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.App
{
    public interface IProductForm
    {
        int Id { get; }

        int CategoryId { get; }

        string ProductionName { get; }

        decimal Price { get; }
    }
}
