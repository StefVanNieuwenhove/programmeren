
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Diagnostics;
using System.Globalization;

const string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=gentse-feesten;Integrated Security=True;TrustServerCertificate=True";
const string eventsCsv = @"C:\Users\stefv\Documents\HoGent\2022-2023\Programmeren\Gente-feesten\Evenementen.csv";
const string vipsCsv = @"";

SqlConnection connection = new(connectionString);

Console.WriteLine("OPTIONS");
Console.WriteLine("-------");
Console.WriteLine("[0]: Upload a .csv file for Events");
Console.WriteLine("[1]: Upload a .csv file for VIP's");
Console.WriteLine("You choose: ");
int.TryParse(Console.ReadLine(), out int input);

Console.WriteLine(input);

switch (input) {
    case 0:
        DeleteDataFromTable("Events");
        uploadEvents("Events");
        break;
    case 1:
        DeleteDataFromTable("Users");
        uploadVips("Users");
        break;
}

void uploadEvents(string tableName) {
    try {
        connection.Open();
        Console.WriteLine("Uploading events.csv ....");

        StreamReader stream = new(eventsCsv);
        while (!stream.EndOfStream) {
            string line = stream.ReadLine();
            string[] values = line.Split(';');

            try {
                string id = values[0];
                string title = values[1];
                string start = values[2];
                string end = values[3];
                string price = values[4];
                string description = values[5];

                SqlCommand command = new($"INSERT INTO {tableName} VALUES (@id, @title, @start, @end, @price, @description);", connection);

                command.Parameters.Add("@id", SqlDbType.VarChar);
                command.Parameters["@id"].Value = id;

                command.Parameters.Add("@title", SqlDbType.VarChar);
                command.Parameters["@title"].Value = title;

                DateTime.TryParseExact(start, "yyyy-MM-dd HH:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate);
                command.Parameters.Add("@start", SqlDbType.DateTime);
                command.Parameters["@start"].Value = startDate;

                DateTime.TryParseExact(end, "yyyy-MM-dd HH:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate);
                command.Parameters.Add("@end", SqlDbType.DateTime);
                command.Parameters["@end"].Value = endDate;

                decimal.TryParse(values[4], out decimal value);
                command.Parameters.Add("@price", SqlDbType.Decimal);
                command.Parameters["@price"].Value = value;

                command.Parameters.Add("@description", SqlDbType.Text);
                command.Parameters["@description"].Value = description;

                command.ExecuteNonQuery();


            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine("Uploading events.csv successfully");
    } catch (Exception ex) {
        Console.WriteLine(ex.Message);
    } finally {
        connection.Close();
    }
}

void uploadVips(string tableName) {    
    try {
        connection.Open();
        Console.WriteLine("Uploading vips.csv ....");

        StreamReader stream = new(vipsCsv);
        while (!stream.EndOfStream) {
            string line = stream.ReadLine();
            string[] values = line.Split(';');

            try {
                string firstName = values[0];
                string lastName = values[1];
                string email = values[2];
                string budget = values[3];

                SqlCommand command = new($"INSERT INTO {tableName} VALUES (@FirstName, @LastName, @Email, @DayPlans, @Budget);", connection);

                command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                command.Parameters["@FirstName"].Value = firstName;

                command.Parameters.Add("@LastName", SqlDbType.VarChar);
                command.Parameters["@LastName"].Value = lastName;

                command.Parameters.Add("@Email", SqlDbType.VarChar);
                command.Parameters["@Email"].Value = email;

                command.Parameters.Add("@Budget", SqlDbType.Decimal);
                command.Parameters["@Budget"].Value = budget;

                command.ExecuteNonQuery();


            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine("Uploading vips.csv successfully");
    } catch (Exception ex) {
        Console.WriteLine(ex.Message);
    } finally {
        connection.Close();
    }
}

void DeleteDataFromTable(string tableName) {
    try {
        connection.Open();

        SqlCommand command = new($"DELETE FROM {tableName}", connection);
        command.ExecuteNonQuery();

    } catch (Exception ex) {
        throw;
    } finally {
        connection.Close();
    }
}
