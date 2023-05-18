using Feest.ADO.Model;
using Feest.Domain.Interface;
using Feest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.ADO.Mappers {
    public class EventMapper : IEventRepository {

        private readonly DbConnection _db;
        private readonly string _connectionString;
        private SqlConnection _connection;
        private const string tableName = "Events";

        public EventMapper() {
            _db = new DbConnection();
            _connection = new(_db.ConnectionString);
            Console.WriteLine(_db.ConnectionString);
        }

        public List<Event> GetAllEvents() {
            List<Event> events = new();

            try {
                _connection.Open();
                SqlCommand command = new($"SELECT * FROM {tableName}", _connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    try {
                        string id = (string)reader["Id"];
                        string title = (string)reader["Title"];
                        DateTime start = (DateTime)reader["StartDate"];
                        DateTime end = (DateTime)reader["EndDate"];
                        decimal price = (decimal)reader["Price"];
                        string description = (string)reader["Description"];

                        events.Add(new Event(id, title, start, end, price, description));
                    } catch (Exception ex) {
                        throw;
                    }
                }

                return events;
            } catch (Exception ex) {
                throw;
            } finally {
                _connection.Close();
            }
        }

        public Event GetEventById(string id) {
            Event obj = null;
            try {
                _connection.Open();
                SqlCommand command = new($"SELECT * FROM {tableName} WHERE Id = @Id", _connection);

                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    try {
                        string title = (string)reader["Title"];
                        DateTime start = (DateTime)reader["StartDate"];
                        DateTime end = (DateTime)reader["EndDate"];
                        decimal price = (decimal)reader["Price"];
                        string description = (string)reader["Description"];

                        obj = new(id, title, start, end, price, description);
                    } catch (Exception ex) { 
                        throw; 
                    }
                }

                return obj;
            } catch (Exception ex) {
                throw;
            } finally { 
                _connection.Close(); 
            }
        }
    }
}
