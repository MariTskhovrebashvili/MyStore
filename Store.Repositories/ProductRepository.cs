using System;
using Store.Models;
using System.Data;

namespace Store.Repositories
{
    public class ProductRepository : BaseRepository<Product, int>
    {
        public ProductRepository()
        {

        }

        #region Overloads

        public int Insert(int userId, int categoryId, string name, decimal price) => Insert(userId, new Product()
        {
            CategoryId = categoryId,
            Name = name,
            Price = price
        });

        public DataTable[] GetRelatedData()
        {
            return GetRelatedData("Category_V");
        }

        #endregion
    }
}
