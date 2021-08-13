using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.App
{
	static class LocalStorage
	{
		static public int UserId { get; set; }

		static public string UserName { get; set; }

		static public IEnumerable<short> UserPermissions { get; set; }
	}
}
