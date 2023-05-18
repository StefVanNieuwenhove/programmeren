using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace H10_People {
    public class PersonsApplication {

        private const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=People;Integrated Security=True";

        private SqlConnection _connection;

        public PersonsApplication() {
            MainWindow _mainWindow = new MainWindow();
            _mainWindow.Show();

            //List<Person> list = GetPersons();

            _connection = new(connectionString);

            _mainWindow.People = GetPersons();
        }

        private List<Person> GetPersons() {
            List<Person> list = new ();
            try {

                _connection.Open();
                SqlCommand command = _connection.CreateCommand();
                command.CommandText = "Select * from Persons";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {

                    try {
                        int id = (int)(reader["ID"]);
                        string firstName = (string)reader["FirstName"];
                        string lastName = (string)reader["LastName"];

                        list.Add(new Person(id, firstName, lastName));
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                }

                    return list;
            } catch {
                throw;
            } finally { _connection.Close(); }
        }
    }
}
