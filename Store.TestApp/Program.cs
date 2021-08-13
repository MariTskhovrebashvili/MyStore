using System;
using Store.Repositories;
using System.IO;
using Store.Models;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Transactions;

namespace Store.TestApp
{
	class Program
	{
		static void Main(string[] args)
		{
			OrderDetailsRepository x = new();
			OrderRepository r = new();


			Order order = new Order()
			{
				UserId = 1,
				ProviderId = 1,
				OrderDate = DateTime.Now,
				RequiredDate = DateTime.MaxValue
			};

			OrderDetails y = new()
			{
				Id = 1,
				ProductId = 1,
				ProvideDate = Convert.ToDateTime("2021-07-15"),
				Quantity = 2,
				UnitPrice = 12,
				Valid = DateTime.Today
			};

			OrderDetails g = new()
			{
				Id = 1,
				ProductId = 2,
				ProvideDate = Convert.ToDateTime("2021-07-30"),
				Quantity = 4,
				UnitPrice = 11,
				Valid = DateTime.Today
			};

			List<OrderDetails> p = new List<OrderDetails>() { y, g };

			(DbTransaction tran, int id ) = r.Insert(1, order, null, false);
			foreach (var item in p)
				item.Id = id;
			x.InsertMany(1, p, tran, true);
		}
	}
}
