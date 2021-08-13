using DatabaseHelper;
using Store.Models;

namespace Store.Repositories
{
    public class CategoryRepository : BaseRepository<Category, int>
    {
        public CategoryRepository()
        {
        }

        #region Overloads
        
        public int Insert(int userId, string name) => base.Insert(userId, new Category() {Name = name});

        #endregion
    }
}