using System;
using Store.Models;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;

namespace Store.Repositories
{
    public class OrderDetailsRepository: BaseRepository<OrderDetails, int>
    {
        public OrderDetailsRepository()
        {
        }

        #region Overloads

        public int Insert(int userId, int id, int productId, decimal unitPrice, int quantity, DateTime provideDate) => Insert(userId, new OrderDetails() {
                Id = id,
                ProductId = productId,
                UnitPrice = unitPrice,
                Quantity = quantity,
                ProvideDate = provideDate
        });

        public DataTable[] GetRelatedData()
        {
            return GetRelatedData("Product_V");
        }

        public DataTable GetOrderDetailsById(int orderId)
        {
            DataTable table = new DataTable();

            try
            {
                DbDataReader reader = _database.ExecuteReader("select * from GetOrderDetailsById_F(@Id)", _database.GetParameters(new Dictionary<string, object>() { { "@Id", orderId } }));
                table.Load(reader);
            }
            finally
            {
                _database.GetConnection().Close();
            }

            return table;
        }

        public decimal GetProductPriceById(int productId)
        {
            try
            {
                return Convert.ToDecimal(_database.ExecuteScalar("select dbo.GetProductPriceById(@Id)", _database.GetParameters(new Dictionary<string, object>() { { "@Id", productId } })));
            }
            finally
            {
                _database.GetConnection().Close();
            }
        }

        #endregion
    }
}