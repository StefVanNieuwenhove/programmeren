using Feest.ADO.Model;
using Feest.Domain.DTO;
using Feest.Domain.Exceptions;
using Feest.Domain.Interface;
using Feest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Feest.ADO.Mappers {
    public class DayPlanMapper : IDayPlanRepository {

        private readonly DbConnection _db;
        private SqlConnection _connection;
        private const string tableName = "DayPlan";

        public DayPlanMapper() {
            _db = new DbConnection();
            _connection = new(_db.ConnectionString);
        }

        public int CreateDayPlan(User user, DateTime date) {
            try {
                int id = 0;
                _connection.Open();

                SqlCommand command = new SqlCommand($"INSERT INTO {tableName} (Date, UserId, Price) VALUES(@Date, @UserId, 0); SELECT SCOPE_IDENTITY();", _connection);

                command.Parameters.Add("@Date", SqlDbType.DateTime);
                command.Parameters["@Date"].Value = date;

                command.Parameters.Add("@UserId", SqlDbType.Int);
                command.Parameters["@UserId"].Value = user.Id;

                id = Convert.ToInt32(command.ExecuteScalar());

                return id;
            } catch(Exception ex) {
                throw;
            } finally {
                _connection.Close();
            }
        }

        public List<DayPlan> GetDayPlanOfUser(int userId) {
           try {
                List<DayPlan> dayPlans = new();
                List<Event> events = new();

                _connection.Open();

                SqlCommand command = new($"SELECT d.Id, d.Date, d.Price, s.Id as UserId, s.FirstName, s.LastName, s.Budget, e.Id AS EventId, e.Title, e.StartDate, e.EndDate, e.Price AS EventPrice, e.Description" +
                    $" FROM DayPlan d" +
                    $" JOIN DayPlanEvents de ON d.Id = de.DayPlanId" +
                    $" JOIN Events e ON de.EventId = e.Id" +
                    $" JOIN Users s ON d.UserId = s.Id" +
                    $" WHERE de.UserId = @UserId AND d.UserId = @UserId"
                    , _connection);

                command.Parameters.AddWithValue("@UserId", userId);

                SqlDataReader reader = command.ExecuteReader();

                

                while (reader.Read()) {
                    // event info
                    int eventId = (int)reader["EventId"];
                    string title = (string)reader["Title"];
                    DateTime start = (DateTime)reader["StartDate"];
                    DateTime end = (DateTime)reader["EndDate"];
                    decimal eventPrice = (decimal)reader["EventPrice"];
                    string description = (string)reader["Description"];
                    events.Add(new Event(eventId, title, start, end, eventPrice, description));

                    // user info
                    string firstName = (string)reader["FirstName"];
                    string LastName = (string)reader["LastName"];
                    decimal budget = (decimal)reader["Budget"];

                    // dayplan info
                    int id = (int)reader["Id"];
                    DateTime date = (DateTime)reader["Date"];
                    decimal price = (decimal)reader["Price"];

                    dayPlans.Add(new DayPlan(id, date, new User(userId, firstName, LastName, budget), events, price));
                }

               

                return dayPlans;
            } catch (Exception ex) {
                throw;
            } finally {
                _connection.Close();
            }
        }

        public List<Event> GetEventsOfDatPlanUser(int dayPlanId, int userId) {
            try {
                List<Event> events = new();
                _connection.Open();

                SqlCommand command = new SqlCommand($"SELECT * FROM DayPlanEvents d JOIN Events e ON d.EventId = e.Id WHERE d.DayPlanId = @DayPlanId AND d.UserId = @UserId", _connection);
                command.Parameters.AddWithValue("@DayPlanId", dayPlanId);
                command.Parameters.AddWithValue("@userId", userId);

                SqlDataReader reader = command.ExecuteReader(); 

                while (reader.Read()) {
                    int eventId = (int)reader["EventId"];
                    string title = (string)reader["Title"];
                    DateTime start = (DateTime)reader["StartDate"];
                    DateTime end = (DateTime)reader["EndDate"];
                    decimal price = (decimal)reader["Price"];
                    string description = (string)reader["Description"];

                    events.Add(new Event(eventId, title, start, end, price, description));
                }

                return events;
            } catch (DayPlanException ex) {
                throw new DayPlanException(ex.Message);
            } finally {
                _connection.Close();
            }
        }

        public bool ExistDayPlan(int id, DateTime date) {
            try {
                _connection.Open();

                SqlCommand command = new($"SELECT COUNT(*) AS ItemExists FROM {tableName} WHERE UserId = @UserId AND Date = @Date", _connection);

                command.Parameters.AddWithValue("@UserId", id);
                command.Parameters.AddWithValue("@Date", date);

                int itemExists = (int)command.ExecuteScalar();

                if (itemExists > 0) {
                    return true;
                }
                return false;
            } catch (Exception ex) {
                throw;
            } finally {
                _connection.Close();
            }
        }

        public bool ExistEventDayPlan(int dayPlanId, int eventId) {
            try {
                _connection.Open();

                SqlCommand command = new($"SELECT COUNT(*) AS ItemExists FROM DayPlanEvents WHERE DayPlanId = @DayPlanId AND EventId = @EventId", _connection);

                command.Parameters.AddWithValue("@DayPlanId", dayPlanId);
                command.Parameters.AddWithValue("@EventId", eventId);

                int itemExists = (int)command.ExecuteScalar();

                if (itemExists > 0) {
                    return true;
                }
                return false;
            } catch (Exception ex) {
                throw;
            } finally {
                _connection.Close();
            }
        }

        public List<Event> AddEventToDayPlanUser(int dayPlanId, int userId, int eventId) {
           try {
                List<Event> events = new();
                _connection.Open();

                SqlTransaction transaction = _connection.BeginTransaction();
                SqlCommand command = new($"INSERT INTO DayPlanEvents (DayPlanId, EventId, UserId) VALUES(@DayPlanId, @EventId, @UserId);", _connection, transaction);
                command.Parameters.AddWithValue("@DayPlanId", dayPlanId);
                command.Parameters.AddWithValue("@EventId", eventId);
                command.Parameters.AddWithValue("@UserId", userId);

                command.ExecuteNonQuery();

                command = new SqlCommand($"SELECT * FROM DayPlanEvents d JOIN Events e ON d.EventId = e.Id WHERE d.DayPlanId = @DayPlanId AND d.UserId = @UserId", _connection, transaction);
                command.Parameters.AddWithValue("@DayPlanId", dayPlanId);
                command.Parameters.AddWithValue("@userId", userId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    string title = (string)reader["Title"];
                    DateTime start = (DateTime)reader["StartDate"];
                    DateTime end = (DateTime)reader["EndDate"];
                    decimal price = (decimal)reader["Price"];
                    string description = (string)reader["Description"];

                    events.Add(new Event(eventId, title, start, end, price, description));
                }
                reader.Close();
                transaction.Commit();
                return events;

            } catch (Exception ex) {
                throw;
            } finally {
                _connection.Close();
            }
        }

        
    }
}
