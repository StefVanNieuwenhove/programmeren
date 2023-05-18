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
    public class UserMapper : IUserRepository {

        private readonly DbConnection _db;
        private readonly string _connectionString;
        private SqlConnection _connection;
        private const string tableName = "Users";

        public UserMapper() {
            _db = new DbConnection();
            _connection = new(_db.ConnectionString);
            Console.WriteLine(_db.ConnectionString);
        }

        public List<User> GetAllUsers() {
            List<User> users = new();

            try {
                _connection.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM {tableName}", _connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    try {
                        int id = (int)reader["Id"];
                        string firstName = (string)reader["FirstName"];
                        string lastName = (string)reader["LastName"];
                        string email = (string)reader["Email"];
                        decimal budget = (decimal)reader["Budget"];

                        users.Add(new User(id, firstName, lastName, email, budget));
                    } catch (Exception ex) {
                        throw;
                    }
                }

                return users;
            } catch (Exception ex) {
                throw;
            } finally {
                _connection.Close();
            }            
        }

        public User GetUserById(int id) {
            User user = null;
            try {
                _connection.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM {tableName} WHERE Id = @Id", _connection);

                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    try {
                        
                        string firstName = (string)reader["firstName"];
                        string lastName = (string)reader["lastName"];
                        string email = (string)reader["email"];
                        decimal budget = (decimal)reader["budget"];

                        user = new User(id, firstName, lastName, email, budget);
                    } catch (Exception ex) {
                        throw;
                    }
                }

                return user;
            } catch (Exception ex) {
                throw;
            } finally {
                _connection.Close();
            }
        }
    }
}
