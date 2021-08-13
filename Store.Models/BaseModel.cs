using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
	public abstract class BaseModel<T>
	{
        public abstract T Id { get; set; }
	}
}
