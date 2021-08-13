using NUnit.Framework;
using Store.Repositories;
using Store.Models;

namespace Test.Repository
{
    public class UserRepositoryTests : BaseRepositoryTest<UserRepository, User>
    {
        private static string _connectionString = "server=localhost; database=Store; uid=sa; pwd=secret";
        
        public UserRepositoryTests() : base(new UserRepository(_connectionString))
        {
            
        }
    }
}
