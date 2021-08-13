using Store.Models;
using Store.Permissions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;

namespace Store.Repositories
{
    public class UserGroupsRepository : BaseRepository<UserGroups, int>
    {
        public override UserGroups Get(IDictionary<string, object> ids)
        {
            UserGroups userGroups = new UserGroups() { Id = (int)ids["Id"]};

            try
            {
                DbDataReader reader = _database.ExecuteReader($"select * from {_getFunction.Value}({GenerateIds(ids)})", _database.GetParameters(ids));

                while (reader.Read())
                {
                    int groupId = Convert.ToInt32(reader["GroupId"]);
                    userGroups.GroupId += 1 << (groupId - 1);
                }
            }
            finally
            {
                _database.GetConnection().Close();
            }

            return userGroups;
        }

        #region Overloads

        public DataTable[] GetRelatedData()
        {
            return GetRelatedData("User_V");
        }

        #endregion

        protected override DbParameter[] GetParameters(int? userId, UserGroups model, IEnumerable<string> names)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            if (userId != null)
                values.Add("@UserId", userId);

            values.Add("Id", model.Id);
            int permissions = (int)model.GroupId;


            foreach (string permisionNames in Enum.GetNames(typeof(UserPermissions)))
            {
                values.Add($"@{permisionNames}", permissions & 1);
                permissions = (permissions >> 1);
            }

            return _database.GetParameters(values);
        }
    }
}
