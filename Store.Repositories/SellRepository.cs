using System;
using Store.Models;

namespace Store.Repositories
{
    public class SellRepository : BaseRepository<Sell, int>
    {
        public SellRepository()
        {
        }

        #region Overloads

        public int Insert(int userId, DateTime sellDate) => Insert(userId, new Sell()
        {
            UserId = userId,
            SellDate = sellDate
        });

        #endregion
    }
}