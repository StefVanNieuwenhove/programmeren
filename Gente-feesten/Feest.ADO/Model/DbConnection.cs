using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.ADO.Model {
    internal class DbConnection {

        private string _connectionString; 

        public DbConnection() {
            _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=gentse-feesten;Integrated Security=True";
        }

        public DbConnection(string connectionString) {
            ConnectionString = _connectionString;
        }

        public string ConnectionString { get { return _connectionString; } init { _connectionString = value; } }
    }
}
