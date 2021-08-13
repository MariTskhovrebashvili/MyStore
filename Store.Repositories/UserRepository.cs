using System;
using System.Collections.Generic;
using System.Data;
using Store.Models;
using System.Data.Common;

namespace Store.Repositories
{
	public class UserRepository : BaseRepository<User, int>
	{
		public UserRepository()
		{
			
		}

		#region Overloads

		public int Insert(int userId, int id, string username, string password)
		{
			return Insert(userId, new User()
			{
				Id = id,
				Username = username,
				Password = password
			});
		}

		public DataTable[] GetRelatedData()
		{
			return GetRelatedData("Employee_V");
		}

		#endregion

		public int LogIn(User user)
        {
			int id = -1;
            try
            {
				object returnedValue = _database.ExecuteScalar("LogInUser_SP", CommandType.StoredProcedure, GetParameters(null, user, new string[] { "Username", "Password" }));
				id = (int)returnedValue;
			}
            finally
            {
				_database.GetConnection().Close();
            }
			
			return id;
        }

		public int LogIn(string username, string password) => LogIn(new User() { Username = username, Password = password });

		public IEnumerable<short> GetUserPermissions(int id)
		{
			try
			{
				DbDataReader reader = _database.ExecuteReader("select * from GetPermissionById_F(@UserId)", _database.GetParameters(new Dictionary<string, object>() { { "@UserId", id } }));
				while (reader.Read())
					yield return (short)reader[0];

				yield return -5; //Default permission for all users. Need for App
			}
			finally
			{
				_database.GetConnection().Close();
			}
		}
	}
}
