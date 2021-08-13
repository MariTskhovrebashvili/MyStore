using Store.Models;
using System;

namespace Store.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, int>
    {
        public EmployeeRepository()
        {
            
        }

        #region Overloads

        public int Insert(int userId, string firstname, string lastName, string personalId, string phone, string email, string homeAdress, DateTime startJob)
        {
            return Insert(
                userId,
                new Employee()
                {
                    FirstName = firstname,
                    LastName = lastName,
                    PersonalId = personalId,
                    Phone = phone,
                    Email = email,
                    HomeAddress = homeAdress,
                    StartJob = startJob
                }
            );
        }

        #endregion
    }
}