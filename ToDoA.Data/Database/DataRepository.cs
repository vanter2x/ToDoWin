using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using Dapper;
using Npgsql;
using ToDoA.Data.Entity;
using IConfigurationSystem = System.Configuration.IConfigurationSystem;

namespace ToDoA.Data.Database
{
    public class DataRepository : IDataRepository<Memento>
    {
        private readonly IDbConnection _connection;
        private string _config = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(_config);
            }
        }


        public DataRepository()
        { 
            _connection = new NpgsqlConnection(_config);
        }
        
        public void AddMemo(Memento memento)
        {
            using (IDbConnection dbConnection = Connection)
            {
                _connection.Execute("INSERT INTO mementos (text) VALUES(@Text)", memento);
            }
        }

        public void DeleteMemo(Memento memento)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Memento> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                return _connection.Query<Memento>("Select * From mementos").ToList();
            }

        }

        public Memento GetMemo(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateMemo(Memento memento)
        {
            throw new System.NotImplementedException();
        }
    }
}