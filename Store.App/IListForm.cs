using System;
using System.Data;
using System.Collections.Generic;

namespace Store.App
{
	public interface IListForm
	{
		DataTable Table { get; }

		IDictionary<string, object> GetSelectedId();

		Action<object, EventArgs> AddFunction { get; set; }

	    Action<object, EventArgs> EditFunction { get; set; }

		Action<object, EventArgs> DeleteFunction { get; set; }

		void RefreshData();
	}
}
