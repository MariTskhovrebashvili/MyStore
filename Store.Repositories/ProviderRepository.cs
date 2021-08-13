using Store.Models;

namespace Store.Repositories
{
    public class ProviderRepository : BaseRepository<Provider, int>
    {
        public ProviderRepository()
        {

        }

        #region Overloads

        public int Insert(int userId, string name, string phone, string email, string location) => Insert(userId, new Provider()
        {
            Name = name,
            Email = email,
            Phone = phone,
            Location = location

        });

        #endregion
    }
}