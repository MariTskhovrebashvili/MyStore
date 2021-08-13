using Store.Models;
using System;
using System.Data;

namespace Store.Repositories
{
    public class OrderRepository : BaseRepository<Order, int>
    {
        public OrderRepository()
        {
        }

        #region Overloads

        public int Insert(int providerId, int userId, DateTime orderDate, DateTime requireDate) => Insert(userId, new Order()
        {
            ProviderId = providerId,
            UserId = userId,
            OrderDate = orderDate,
            RequiredDate = requireDate
        });

        public DataTable[] GetRelatedData()
        {
            return GetRelatedData("Provider_V");
        }

        #endregion
    }
}