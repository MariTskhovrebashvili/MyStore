using Store.Models;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace Store.Repositories
{
    public class SellDetailsRepository : BaseRepository<SellDetails, int>
    {
        public SellDetailsRepository()
        {
        }
        
        #region Overloads

        public int Insert(int userId, int id, int productId, int quantity, decimal unitPrice, decimal discount) => Insert(userId,
            new SellDetails()
            {
                Id = id,
                ProductId = productId,
                Quantity = quantity,
                UnitPrice = unitPrice,
                Discount = discount
            });

        public DataTable[] GetRelatedData()
        {
            return GetRelatedData("Product_V");
        }

        #endregion

        public DataTable GetSellDetailsById(int sellId)
        {
            DataTable table = new DataTable();

            try
            {
                DbDataReader reader = _database.ExecuteReader("select * from GetSellDetailsById_F(@Id)", _database.GetParameters(new Dictionary<string, object>() { { "@Id", sellId } }));
                table.Load(reader);
            }
            finally
            {
                _database.GetConnection().Close();
            }

            return table;
        }

        public int GetProductQuantityById(int productId)
        {
            try
            {
                return (int)_database.ExecuteScalar("select dbo.GetProductSumById_F(@Id)", _database.GetParameters(new Dictionary<string, object>() { { "@Id", productId } }));
            }
            finally
            {
                _database.GetConnection().Close();
            }
        }
     }
}