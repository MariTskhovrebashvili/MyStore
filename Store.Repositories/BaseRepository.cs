using System;
using DatabaseHelper;
using Store.Models;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Store.Settings;

namespace Store.Repositories
{
    public abstract class BaseRepository<TModel, TId> where TModel : BaseModel<TId>, new()
    {
        IDbSettings _dbSettings;
        protected readonly Database<SqlConnection> _database;
        protected readonly Lazy<string> _insertProcedure, _updateProcedure, _deleteProcedure, _getFunction, _view;
        protected readonly Lazy<IEnumerable<string>> _insertParameters, _updateParameters, _deleteParameters;

        protected BaseRepository()
        {
            _dbSettings = new SettingsReader().GetDbSettings();
            _database = new Database<SqlConnection>(_dbSettings.ConnectionString, true);
            _getFunction = new Lazy<string>(() => $"Get{typeof(TModel).Name}_F");
            _view = new Lazy<string>(() => $"{typeof(TModel).Name}_V");
            _insertProcedure = new Lazy<string>(() =>  LoadProcedure(ProcedureType.Insert));
            _insertParameters = new Lazy<IEnumerable<string>>(() => LoadProcParameters(_insertProcedure.Value));
            _updateProcedure = new Lazy<string>(() => LoadProcedure(ProcedureType.Update));
            _updateParameters = new Lazy<IEnumerable<string>>(() => LoadProcParameters(_updateProcedure.Value));
            _deleteProcedure = new Lazy<string>(() => LoadProcedure(ProcedureType.Delete));
            _deleteParameters = new Lazy<IEnumerable<string>>(() => LoadProcParameters(_deleteProcedure.Value));
        }

        #region Properties

        public IEnumerable<string> InsertParameters
        {
            get
            {
                return _insertParameters.Value;
            }
        }

        public IEnumerable<string> UpdateParameters
        {
            get
            {
                return _updateParameters.Value;
            }
        }

        public IEnumerable<string> DeleteParameters
        {
            get
            {
                return _deleteParameters.Value;
            }
        }

        #endregion

        #region Public Functions

        public virtual TModel Get(IDictionary<string, object> ids)
        {
            bool gotResult = false;

            TModel model = new TModel();

            try
            {
                DbDataReader reader = _database.ExecuteReader($"select * from {_getFunction.Value}({GenerateIds(ids)})",
                _database.GetParameters(ids));

                while (reader.Read())
                {
                    gotResult = true;
                    foreach (var property in model.GetType().GetProperties())
                    {
                        try
                        {
                            property.SetValue(model, reader[property.Name] is not DBNull ? reader[property.Name] : default);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            property.SetValue(model, default);
                        }
                    }
                }
            }
            finally
            {
                _database.GetConnection().Close();
            }
            
            return  gotResult? model : null;
        }

        public virtual TModel Get(TId id) => Get(new Dictionary<string, object>(){{"@Id", id}});

        public IEnumerable<TModel> Select()
        {
            try
            {
                DbDataReader reader = _database.ExecuteReader($"select * from {_view.Value}", null);

                while (reader.Read())
                {
                    TModel model = new TModel();
                    foreach (var property in model.GetType().GetProperties())
                    {
                        try
                        {
                            property.SetValue(model, reader[property.Name] is not DBNull ? reader[property.Name] : null);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            property.SetValue(model, default);
                        }
                    }

                    yield return model;
                }
            }
            finally
            {
                _database.GetConnection().Close();
            }
            
        }

        public IEnumerable<TModel> Select(Predicate<TModel> predicate)
        {
            foreach (var model in Select())
                if (predicate(model))
                    yield return model;
        }

        protected DataTable[] GetRelatedData(params string[] views)
        {
            DataTable[] tables = new DataTable[views.Length];
            int index = 0;

            while(index < views.Length)
            {
                try
                {
                    DbDataReader reader = _database.ExecuteReader($"select * from {views[index]}");
                    DataTable table = new DataTable();
                    table.Load(reader);
                    tables[index++] = table;
                }
                finally
                {
                    _database.GetConnection().Close();
                }
            }

            return tables;
        }

        public DataTable GetData()
        {
            DataTable table = new DataTable();

            try
            {
                DbDataReader reader = _database.ExecuteReader($"select * from {_view.Value}", null);
                table.Load(reader);
            }
            finally
            {
                _database.GetConnection().Close();
            }

            return table;
        }
        
        public virtual int Insert(int userId, TModel model)
        {
            if (_insertProcedure.Value == null)
                throw new NotSupportedException("Insert Procedure is not Supported !");

            try
            {
                return Convert.ToInt32(
                    _database.ExecuteScalar(
                        _insertProcedure.Value,
                        CommandType.StoredProcedure,
                        GetParameters(userId, model, _insertParameters.Value))
                );
            }
            finally
            {
                if(!_database.TransactionIsOn())
                    _database.GetConnection().Close();
            }
        }

        public virtual (DbTransaction dbTransaction, int lastReturn) Insert(int userId, TModel model, DbTransaction transaction, bool commit)
        {
            (int dbTransaction, int lastReturn) = (default, default);
            
            try
            {
                transaction = transaction == null ? _database.BeginTransaction() : transaction;

                lastReturn = Convert.ToInt32(_database.ExecuteScalar(
                    _insertProcedure.Value,
                    CommandType.StoredProcedure,
                    transaction,
                    GetParameters(userId, model, _insertParameters.Value))
                );
            }
            catch (NullReferenceException referenceException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _database.RollbackTransaction();
                throw;
            }
            
            if(commit)
                _database.CommitTransaction();

            return (transaction, lastReturn);
        }

        public virtual int InsertMany(int userId, IEnumerable<TModel> models)
        {
            int lastReturn = 0;

            if (_insertProcedure.Value == null || _insertParameters.Value == null)
                throw new Exception("Insert Procedure is not Supported !");

            try
            {
                _database.BeginTransaction();

                foreach (TModel model in models)
                {
                    _database.ExecuteScalar(
                        _insertProcedure.Value,
                        CommandType.StoredProcedure,
                        GetParameters(userId, model, _insertParameters.Value));
                }

                _database.CommitTransaction();
            }
            catch(Exception ex)
            {
                _database.RollbackTransaction();
                throw;
            }
            finally
            {
                _database.GetConnection().Close();
            }

            return lastReturn;
        }

        public virtual (DbTransaction, int) InsertMany(int userId, IEnumerable<TModel> models, DbTransaction transaction, bool commit)
        {
            (DbTransaction dbTransaction, int lastReturn) = (default, default);

            if(models == null || models.Count() == 0)
                throw new ArgumentException("there is no models to insert");
            
            try
            {
                transaction = transaction == null ? _database.BeginTransaction() : transaction;

                foreach (var model in models)
                    (dbTransaction, lastReturn) = Insert(userId, model, transaction, false);
            }
            catch (NullReferenceException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                try
                {
                    _database.RollbackTransaction();
                }
                catch (Exception innerException)
                {
                    throw new Exception(ex.Message, innerException);
                }
            }
            
            if(commit)
                _database.CommitTransaction();

            return (dbTransaction, lastReturn);
        }

        public virtual void Update(int userId, TModel model)
        {
            if (_updateProcedure.Value == null)
                throw new NotSupportedException("Update Procedure is not Supported !");

            try
            {
                _database.ExecuteNonQuery(_updateProcedure.Value, CommandType.StoredProcedure,
                    GetParameters(userId, model, _updateParameters.Value));
            }
            finally
            {
                _database.GetConnection().Close();
            }
        }

        public virtual void Delete(int userId, TModel model)
        {
            if(_deleteProcedure.Value == null)
                throw new NotSupportedException("Delete Procedure is not Supported !");
                
            try
            {
                _database.ExecuteNonQuery(_deleteProcedure.Value, CommandType.StoredProcedure,
                    GetParameters(userId, model, _deleteParameters.Value));
            }
            finally
            {
                _database.GetConnection().Close();
            }
        }

        public void AbortFlow(DbTransaction transaction)
        {
            _database.AbortAnyTransaction(transaction);
        }

        public void AbortFlow()
        {
            _database.RollbackTransaction();
            _database.GetConnection().Close();
        }

        #endregion

        #region Private Functions

        protected virtual DbParameter[] GetParameters(int? userId, TModel model, IEnumerable<string> names)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            if(userId != null)
                values.Add("@UserId", userId);

            foreach (PropertyInfo property in model.GetType().GetProperties())
            {
                if (property.Name == "UserId")
                    continue;

                if (names.Contains(property.Name))
                    values.Add(property.Name, property.GetValue(model));
            }

            return _database.GetParameters(values);
        }

        private string LoadProcedure(ProcedureType procedureType)
        {
            if (ProcedureExists())
                return $"{procedureType.ToString()}{typeof(TModel).Name}_SP";

            return null;
            
            bool ProcedureExists()
            {
                try
                {
                    return (bool) _database.ExecuteScalar("select dbo.CheckProcExistence_F(@ProcedureName)",
                        _database.GetParameters(new Dictionary<string, object>()
                            {{"@ProcedureName", $"{procedureType.ToString()}{typeof(TModel).Name}_SP"}}));
                }
                finally
                {
                    if(!_database.TransactionIsOn())
                        _database.GetConnection().Close();
                }
            }
        }
        
        private IEnumerable<string> LoadProcParameters(string procedureName)
        {
            if (procedureName == null)
                yield break;

            DbDataReader reader = null;
            int index = 0; 
            
            try
            {
                reader = _database.ExecuteReader("select Name from GetProcParameters_F(@ProcedureName)",
                    _database.GetParameters(new Dictionary<string, object>() {{"@ProcedureName", procedureName}}));

                while (reader.Read())
                {
                    string parameter = reader[0].ToString().Replace("@", "");
                    if (parameter == "UserId" && typeof(TModel).GetProperty("UserId") == null)
                        continue;
                    yield return parameter;
                }  
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                if(!_database.TransactionIsOn())
                    _database.GetConnection().Close();
            }
        }

        protected string GenerateIds(IDictionary<string, object> ids)
        {
            string idString = "";

            foreach (var item in ids)
            {
                idString += $" @{item.Key},";
            }
            return idString.Trim().Substring(0, idString.Length - 2);
        }

        #endregion
    }
}