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
        private readonly string _config = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(_config);
            }
        }
        
        public void AddMemo(Memento memento)
        {
            using (IDbConnection dbConnection = Connection)
            {
                Connection.Execute("INSERT INTO mementos (text) VALUES(@Text)", memento);
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
                var result = Connection.Query<Memento>("Select * From mementos").ToList();

                return result;
            }
        }

        public Memento GetMemo(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var result = Connection.Query<Memento>($"Select * From mementos where id = @Id", new { Id = id }).FirstOrDefault();

                return result;
            }
        }

        public void UpdateMemo(Memento memento)
        {
            using (IDbConnection dbConnection = Connection)
            {
                Connection.Query<Memento>($"UPDATE mementos SET text = @Text WHERE id=@Id", memento);
            }
        }
    }
}